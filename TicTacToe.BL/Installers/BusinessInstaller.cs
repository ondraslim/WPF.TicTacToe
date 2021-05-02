using System;
using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using TicTacToe.BL.Facades.Common;
using TicTacToe.BL.Mappings;
using TicTacToe.Common;
using TicTacToe.Common.Extensions;
using TicTacToe.Common.IoC;
using TicTacToe.Infrastructure;

namespace TicTacToe.BL.Installers
{
    public class BusinessInstaller : IInstaller
    {
        public void Install(IServiceCollection serviceCollection)
        {
            ConfigureMapper(serviceCollection);

            serviceCollection.Scan(scan => scan
                .FromAssemblyOf<BusinessInstaller>()
                .AddClasses(classes => classes.AssignableTo<ISingletonService>())
                .AsSelfWithInterfaces()
                .WithSingletonLifetime()
                .AddClasses(classes => classes.AssignableTo<ITransientService>())
                .AsSelfWithInterfaces()
                .WithTransientLifetime()
                .AddClasses(classes => classes.AssignableTo<IFacade>())
                .AsSelfWithInterfaces()
                .WithTransientLifetime()
                .AddClasses(classes => classes.AssignableTo(typeof(IRepository<,>)))
                .AsSelfWithInterfaces()
                .WithTransientLifetime()
            );
        }

        protected void ConfigureMapper(IServiceCollection services)
        {
            var config = new MapperConfiguration(cfg =>
            {
                var mappings = GetType().Assembly.FindAllImplementations<IMapping>();
                foreach (var mapping in mappings)
                {
                    var instance = (Profile) Activator.CreateInstance(mapping);
                    cfg.AddProfile(instance);
                }
            });

            config.AssertConfigurationIsValid();

            var mapper = config.CreateMapper();
            services.AddSingleton(mapper);
        }
    }
}
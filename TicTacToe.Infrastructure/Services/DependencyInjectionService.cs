using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using TicTacToe.Infrastructure.Services.Interfaces;

namespace TicTacToe.Infrastructure.Services
{
    public class DependencyInjectionService : IDependencyInjectionService
    {
        private IContainer container;

        public void Build(IServiceCollection serviceCollection)
        {
            var containerBuilder = new ContainerBuilder();
            containerBuilder.Populate(serviceCollection);
            container = containerBuilder.Build();
        }

        public TService Resolve<TService>()
        {
            return container.Resolve<TService>();
        }

        public TService Resolve<TService>(params IoC.TypedParameter[] parameters)
        {
            if (parameters.Any())
            {
                var typedParameters = parameters
                    .Select(parameter => new Autofac.TypedParameter(parameter.Type, parameter.Value))
                    .ToList();
                
                return container.Resolve<TService>(typedParameters);
            }


            return container.Resolve<TService>();
        }

        public object Resolve(Type type)
        {
            return container.Resolve(type);
        }

        public object Resolve(Type type, params IoC.TypedParameter[] parameters)
        {
            if (parameters.Any())
            {
                var typedParameters = parameters
                    .Select(parameter => new Autofac.TypedParameter(parameter.Type, parameter.Value))
                    .ToList();
                return container.Resolve(type, typedParameters);
            }

            return container.Resolve(type);
        }

        public IEnumerable<TService> ResolveAll<TService>()
        {
            return container.Resolve<IEnumerable<TService>>();
        }
    }
}
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using TicTacToe.Infrastructure.IoC;

namespace TicTacToe.Infrastructure.Services.Interfaces
{
    public interface IDependencyInjectionService
    {
        void Build(IServiceCollection serviceCollection);
        TService Resolve<TService>();
        TService Resolve<TService>(params TypedParameter[] parameters);
        object Resolve(Type type);
        object Resolve(Type type, params TypedParameter[] parameters);
        IEnumerable<TService> ResolveAll<TService>();
    }
}
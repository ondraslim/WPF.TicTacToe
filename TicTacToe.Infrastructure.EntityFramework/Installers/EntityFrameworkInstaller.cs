using Microsoft.Extensions.DependencyInjection;
using TicTacToe.Infrastructure.EntityFramework.UnitOfWork;
using TicTacToe.Infrastructure.UnitOfWork.Interfaces;

namespace TicTacToe.Infrastructure.EntityFramework.Installers
{
    public class EntityFrameworkInstaller
    {
        public void Install(IServiceCollection serviceCollection)
        {
            serviceCollection.AddSingleton<IUnitOfWorkProvider, EntityFrameworkUnitOfWorkProvider>();
            serviceCollection.AddTransient(typeof(IRepository<,>), typeof(EntityFrameworkRepository<,>));
        }
    }
}
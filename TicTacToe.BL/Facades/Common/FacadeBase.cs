using TicTacToe.Infrastructure.UnitOfWork.Interfaces;

namespace TicTacToe.BL.Facades.Common
{
    public abstract class FacadeBase : IFacade
    {
        protected readonly IUnitOfWorkProvider UnitOfWorkProvider;

        protected FacadeBase(IUnitOfWorkProvider unitOfWorkProvider)
        {
            UnitOfWorkProvider = unitOfWorkProvider;

        }
    }
}
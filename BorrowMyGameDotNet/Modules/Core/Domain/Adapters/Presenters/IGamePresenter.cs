using BorrowMyGameDotNet.Modules.Core.Domain.Entities;

namespace BorrowMyGameDotNet.Core.Domain.Adapters.Presenters
{
    public interface IGamePresenter
    {
        GameOutput ToOutput(Game game);
    }
}
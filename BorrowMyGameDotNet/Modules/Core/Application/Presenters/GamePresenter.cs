using BorrowMyGameDotNet.Core.Domain.Adapters.Presenters;
using BorrowMyGameDotNet.Modules.Core.Domain.Entities;

namespace BorrowMyGameDotNet.Modules.Core.Application.Presenters
{
    public class GamePresenter : IGamePresenter
    {
        public GameOutput ToOutput(Game game)
        {
            return new GameOutput(
                game.Id.AsInt(),
                game.Title.AsString(),
                game.IsBorrowed.AsBool()
            );
        }
    }
}
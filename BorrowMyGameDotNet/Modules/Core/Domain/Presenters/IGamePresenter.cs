using System.Collections.Generic;
using BorrowMyGameDotNet.Modules.Core.Domain.Entities;
using BorrowMyGameDotNet.Modules.Core.Domain.Usecases.Game;

namespace BorrowMyGameDotNet.Modules.Core.Domain.Presenters
{
    public interface IGamePresenter
    {
        GameOutput ToOutput(Game game);
        IEnumerable<GameOutput> ToOutputs(IEnumerable<Game> games);
    }
}
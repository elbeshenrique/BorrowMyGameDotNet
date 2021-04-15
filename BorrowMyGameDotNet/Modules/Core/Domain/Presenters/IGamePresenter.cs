using System.Collections.Generic;
using BorrowMyGameDotNet.Modules.Core.Domain.Entities;

namespace BorrowMyGameDotNet.Modules.Core.Domain.Presenters
{
    public interface IGamePresenter
    {
        GameOutput ToOutput(Game game);
        IEnumerable<GameOutput> ToOutputs(IEnumerable<Game> games);
    }
}
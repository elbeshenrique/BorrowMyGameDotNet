using System.Collections.Generic;
using BorrowMyGameDotNet.Modules.Core.Domain.Entities;
using BorrowMyGameDotNet.Modules.Core.Domain.Presenters;
using BorrowMyGameDotNet.Modules.Core.Domain.Usecases.Game;

namespace BorrowMyGameDotNet.Modules.Core.Application.Presenters
{
    public class GamePresenter : IGamePresenter
    {
        public GameOutput ToOutput(Game game)
        {
            return new GameOutput
            {
                Id = game.Id,
                Title = game.Title,
                IsBorrowed = game.IsBorrowed
            };
        }

        public IEnumerable<GameOutput> ToOutputs(IEnumerable<Game> games)
        {
            var gameOutputs = new List<GameOutput>();

            foreach (var game in games)
            {
                var gameOutput = ToOutput(game);
                gameOutputs.Add(gameOutput);
            }

            return gameOutputs;
        }
    }
}
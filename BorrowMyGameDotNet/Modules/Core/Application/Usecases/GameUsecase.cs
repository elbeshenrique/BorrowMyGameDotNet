using System;
using System.Collections.Generic;
using BorrowMyGameDotNet.Modules.Core.Domain.Entities;
using BorrowMyGameDotNet.Modules.Core.Domain.Exceptions;
using BorrowMyGameDotNet.Modules.Core.Domain.Presenters;
using BorrowMyGameDotNet.Modules.Core.Domain.Repositories;
using BorrowMyGameDotNet.Modules.Core.Domain.Usecases;

namespace BorrowMyGameDotNet.Modules.Core.Application.Usecases
{
    public class GameUsecase : IGameUsecase
    {

        private readonly IGameRepository _repository;
        private readonly IGamePresenter _presenter;

        public GameUsecase(IGameRepository repository, IGamePresenter presenter)
        {
            _repository = repository;
            _presenter = presenter;
        }

        public IEnumerable<GameOutput> GetAll()
        {
            try
            {
                var games = _repository.GetAll();
                var gameOutputs = _presenter.ToOutputs(games);
                return gameOutputs;
            }
            catch (Exception exception)
            {
                throw new GameUsecaseException("Failure on getting games data.", exception);
            }
        }

        public GameOutput Create(GameInput gameInput)
        {
            try
            {
                ValidateGameInput(gameInput);

                var game = new Game
                {
                    Title = gameInput.Title,
                    IsBorrowed = gameInput.IsBorrowed
                };

                _repository.Create(game);
                var gameOutput = _presenter.ToOutput(game);
                return gameOutput;
            }
            catch (Exception exception)
            {
                throw new GameUsecaseException("Failure on creating game data.", exception);
            }
        }

        public GameOutput Update(int id, GameInput gameInput)
        {
            try
            {
                ValidateGameInput(gameInput);

                var game = _repository.Find(id);
                if (game == null)
                {
                    throw new Exception($"Game with id: {id} not found.");
                }

                game.Title = gameInput.Title;
                game.IsBorrowed = gameInput.IsBorrowed;
                _repository.Update(id, game);

                var gameOutput = _presenter.ToOutput(game);
                return gameOutput;
            }
            catch (Exception exception)
            {
                throw new GameUsecaseException("Failure on updating game data.", exception);
            }
        }

        private void ValidateGameInput(GameInput gameInput)
        {
            if (gameInput == null)
            {
                throw new Exception("Invalid game data.");
            }

            if (String.IsNullOrEmpty(gameInput.Title))
            {
                throw new Exception("Game title cannot be empty.");
            }
        }
    }
}
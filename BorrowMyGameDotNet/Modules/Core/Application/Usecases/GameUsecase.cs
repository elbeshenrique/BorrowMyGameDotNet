using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BorrowMyGameDotNet.Modules.Core.Domain.Entities;
using BorrowMyGameDotNet.Modules.Core.Domain.Exceptions;
using BorrowMyGameDotNet.Modules.Core.Domain.Presenters;
using BorrowMyGameDotNet.Modules.Core.Domain.Repositories;
using BorrowMyGameDotNet.Modules.Core.Domain.Usecases;

namespace BorrowMyGameDotNet.Modules.Core.Application.Usecases
{
    public class GameUsecase : IGameUsecase
    {
        private const string FailureGettingGameData = "Failure on getting games data.";
        private const string FailureCreatingGameData = "Failure on creating game data.";
        private const string FailureUpdatingGameData = "Failure on updating game data.";
        private const string GameNotFound = "Game with id: {0} not found.";
        private const string InvalidGameInput = "Invalid game input.";
        private const string EmptyGameTitle = "Game title cannot be empty.";

        private readonly IGameRepository repository;
        private readonly IGamePresenter presenter;

        public GameUsecase(IGameRepository repository, IGamePresenter presenter)
        {
            this.repository = repository;
            this.presenter = presenter;
        }

        public async Task<IEnumerable<GameOutput>> GetAll()
        {
            try
            {
                var games = await repository.GetAll();
                var gameOutputs = presenter.ToOutputs(games);
                return gameOutputs;
            }
            catch (Exception exception)
            {
                throw new GameUsecaseException(FailureGettingGameData, exception);
            }
        }

        public async Task<GameOutput> Find(int id)
        {
            try
            {
                var game = await repository.Find(id);
                if (game == null)
                {
                    throw new NotFoundException(String.Format(GameNotFound, id));
                }

                var gameOutput = presenter.ToOutput(game);
                return gameOutput;
            }
            catch (NotFoundException)
            {
                throw;
            }
            catch (Exception exception)
            {
                throw new GameUsecaseException(FailureCreatingGameData, exception);
            }
        }

        public async Task<GameOutput> Create(GameInput gameInput)
        {
            try
            {
                ValidateGameInput(gameInput);

                var game = new Game
                {
                    Title = gameInput.Title,
                    IsBorrowed = gameInput.IsBorrowed
                };

                await repository.Create(game);
                var gameOutput = presenter.ToOutput(game);
                return gameOutput;
            }
            catch (Exception exception)
            {
                throw new GameUsecaseException(FailureCreatingGameData, exception);
            }
        }

        public async Task Update(int id, GameInput gameInput)
        {
            try
            {
                ValidateGameInput(gameInput);

                var game = await repository.Find(id);
                if (game == null)
                {
                    throw new NotFoundException(String.Format(GameNotFound, id));
                }

                game.Title = gameInput.Title;
                game.IsBorrowed = gameInput.IsBorrowed;
                await repository.Update(id, game);
            }
            catch (Exception exception)
            {
                throw new GameUsecaseException(FailureUpdatingGameData, exception);
            }
        }

        public async Task UpdateIsBorrowed(int id, bool isBorrowed)
        {
            try
            {
                var game = await repository.Find(id);
                if (game == null)
                {
                    throw new NotFoundException(String.Format(GameNotFound, id));
                }

                game.IsBorrowed = isBorrowed;
                await repository.UpdateIsBorrowed(game, isBorrowed);
            }
            catch (Exception exception)
            {
                throw new GameUsecaseException(FailureUpdatingGameData, exception);
            }
        }

        private void ValidateGameInput(GameInput gameInput)
        {
            if (gameInput == null)
            {
                throw new InvalidInputException(InvalidGameInput);
            }

            if (String.IsNullOrEmpty(gameInput.Title))
            {
                throw new InvalidInputException(EmptyGameTitle);
            }
        }

    }
}
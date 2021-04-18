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
        private const string FailureGettingGameDataMessage = "Failure on getting game data.";
        private const string FailureCreatingGameDataMessage = "Failure on creating game data.";
        private const string FailureUpdatingGameDataMessage = "Failure on updating game data.";
        private const string GameNotFoundMessage = "Game with id: {0} not found.";
        private const string InvalidGameInputMessage = "Invalid game input.";
        private const string EmptyGameTitleMessage = "Game title cannot be empty.";

        private readonly IGameRepository repository;
        private readonly IGamePresenter presenter;

        public GameUsecase(IGameRepository repository, IGamePresenter presenter)
        {
            this.repository = repository;
            this.presenter = presenter;
        }

        public async Task<IEnumerable<GameOutput>> GetAllAsync()
        {
            try
            {
                var games = await repository.GetAllAsync();
                var gameOutputs = presenter.ToOutputs(games);
                return gameOutputs;
            }
            catch (Exception exception)
            {
                throw new GameUsecaseException(FailureGettingGameDataMessage, exception);
            }
        }

        public async Task<GameOutput> FindAsync(int id)
        {
            try
            {
                var game = await repository.FindAsync(id);
                if (game == null)
                {
                    throw new NotFoundException(String.Format(GameNotFoundMessage, id));
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
                throw new GameUsecaseException(FailureCreatingGameDataMessage, exception);
            }
        }

        public async Task<GameOutput> CreateAsync(GameInput gameInput)
        {
            try
            {
                ValidateGameInput(gameInput);

                var game = new Game
                {
                    Title = gameInput.Title,
                    IsBorrowed = gameInput.IsBorrowed
                };

                await repository.CreateAsync(game);
                var gameOutput = presenter.ToOutput(game);
                return gameOutput;
            }
            catch (Exception exception)
            {
                throw new GameUsecaseException(FailureCreatingGameDataMessage, exception);
            }
        }

        public async Task UpdateAsync(int id, GameInput gameInput)
        {
            try
            {
                ValidateGameInput(gameInput);

                var game = await repository.FindAsync(id);
                if (game == null)
                {
                    throw new NotFoundException(String.Format(GameNotFoundMessage, id));
                }

                game.Title = gameInput.Title;
                game.IsBorrowed = gameInput.IsBorrowed;
                await repository.UpdateAsync(id, game);
            }
            catch (Exception exception)
            {
                throw new GameUsecaseException(FailureUpdatingGameDataMessage, exception);
            }
        }

        public async Task UpdateIsBorrowedAsync(int id, bool isBorrowed)
        {
            try
            {
                var game = await repository.FindAsync(id);
                if (game == null)
                {
                    throw new NotFoundException(String.Format(GameNotFoundMessage, id));
                }

                game.IsBorrowed = isBorrowed;
                await repository.UpdateIsBorrowedAsync(game, isBorrowed);
            }
            catch (Exception exception)
            {
                throw new GameUsecaseException(FailureUpdatingGameDataMessage, exception);
            }
        }

        private void ValidateGameInput(GameInput gameInput)
        {
            if (gameInput == null)
            {
                throw new InvalidInputException(InvalidGameInputMessage);
            }

            if (String.IsNullOrEmpty(gameInput.Title))
            {
                throw new InvalidInputException(EmptyGameTitleMessage);
            }
        }

    }
}
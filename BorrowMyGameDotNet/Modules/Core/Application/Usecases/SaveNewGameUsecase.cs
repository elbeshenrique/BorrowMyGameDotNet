using System;
using BorrowMyGameDotNet.Modules.Core.Domain.Entities;
using BorrowMyGameDotNet.Modules.Core.Domain.Exceptions;
using BorrowMyGameDotNet.Modules.Core.Domain.Presenters;
using BorrowMyGameDotNet.Modules.Core.Domain.Repositories;
using BorrowMyGameDotNet.Modules.Core.Domain.Usecases;

namespace BorrowMyGameDotNet.Modules.Core.Application.Usecases
{
    public class SaveNewGameUsecase : ISaveNewGameUsecase
    {
        private readonly IGameRepository _gameRepository;
        private readonly IGamePresenter _gamePresenter;

        public SaveNewGameUsecase(IGameRepository gameRepository, IGamePresenter gamePresenter)
        {
            _gameRepository = gameRepository;
            _gamePresenter = gamePresenter;
        }

        public GameOutput Execute(GameInput gameInput)
        {
            try
            {
                var game = new Game
                {
                    Title = gameInput.Title,
                    IsBorrowed = gameInput.IsBorrowed
                };

                _gameRepository.Create(game);
                var gameOutput = _gamePresenter.ToOutput(game);
                return gameOutput;
            }
            catch (GameRepositoryException exception)
            {
                throw new SaveNewGameException(exception);
            }
            catch (Exception exception)
            {
                throw new SaveNewGameException(exception);
            }
        }
    }
}
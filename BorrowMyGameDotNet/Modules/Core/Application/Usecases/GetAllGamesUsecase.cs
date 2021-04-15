using System;
using System.Collections.Generic;
using BorrowMyGameDotNet.Modules.Core.Domain.Entities;
using BorrowMyGameDotNet.Modules.Core.Domain.Exceptions;
using BorrowMyGameDotNet.Modules.Core.Domain.Presenters;
using BorrowMyGameDotNet.Modules.Core.Domain.Repositories;
using BorrowMyGameDotNet.Modules.Core.Domain.Usecases;

namespace BorrowMyGameDotNet.Modules.Core.Application.Usecases
{
    public class GetAllGamesUsecase : IGetAllGamesUsecase
    {

        private readonly IGameRepository _repository;
        private readonly IGamePresenter _gamePresenter;

        public GetAllGamesUsecase(IGameRepository repository, IGamePresenter gamePresenter)
        {
            _repository = repository;
            _gamePresenter = gamePresenter;
        }

        public IEnumerable<GameOutput> Execute()
        {
            try
            {
                var games = _repository.GetAll();
                var gameOutputs = _gamePresenter.ToOutputs(games);
                return gameOutputs;
            }
            catch (Exception exception)
            {
                throw new GetAllGamesException(exception);
            }
        }
    }
}
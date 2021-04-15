using System;
using System.Collections.Generic;
using BorrowMyGameDotNet.Data;
using BorrowMyGameDotNet.Modules.Core.Domain.Entities;
using BorrowMyGameDotNet.Modules.Core.Domain.Exceptions;
using BorrowMyGameDotNet.Modules.Core.Domain.Presenters;
using BorrowMyGameDotNet.Modules.Core.Domain.Repositories;

namespace BorrowMyGameDotNet.Modules.Core.Infrastructure.Repositories
{
    public class GameRepository : IGameRepository
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IGamePresenter _gamePresenter;

        public GameRepository(ApplicationDbContext dbContext, IGamePresenter gamePresenter)
        {
            _dbContext = dbContext;
            _gamePresenter = gamePresenter;
        }

        public IEnumerable<Game> GetAll()
        {
            try
            {
                var games = _dbContext.Games;
                return games;
            }
            catch (Exception exception)
            {
                throw new GameRepositoryException(exception);
            }
        }

        public void Create(Game game)
        {
            try
            {
                _dbContext.Games.Add(game);
                _dbContext.SaveChanges();
            }
            catch (Exception exception)
            {
                throw new GameRepositoryException(exception);
            }
        }
    }
}
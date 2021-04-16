using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BorrowMyGameDotNet.Data;
using BorrowMyGameDotNet.Modules.Core.Domain.Entities;
using BorrowMyGameDotNet.Modules.Core.Domain.Exceptions;
using BorrowMyGameDotNet.Modules.Core.Domain.Presenters;
using BorrowMyGameDotNet.Modules.Core.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

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

        public async Task<IEnumerable<Game>> GetAll()
        {
            try
            {
                var games = await _dbContext.Games.ToListAsync();
                return games;
            }
            catch (Exception exception)
            {
                throw new GameRepositoryException(exception);
            }
        }

        public async Task Create(Game game)
        {
            try
            {
                _dbContext.Games.Add(game);
                await _dbContext.SaveChangesAsync();
            }
            catch (Exception exception)
            {
                throw new GameRepositoryException(exception);
            }
        }

        public async Task<Game> Find(int id)
        {
            try
            {
                var game = await _dbContext.Games.FindAsync(id);
                return game;
            }
            catch (Exception exception)
            {
                throw new GameRepositoryException(exception);
            }
        }

        public async Task Update(int id, Game game)
        {
            try
            {
                _dbContext.Games.Update(game);
                await _dbContext.SaveChangesAsync();
            }
            catch (Exception exception)
            {
                throw new GameRepositoryException(exception);
            }
        }

        public async Task UpdateIsBorrowed(Game game, bool isBorrowed)
        {
            try
            {
                var isBorrowedProperty = _dbContext.Entry(game).Property(g => g.IsBorrowed);
                isBorrowedProperty.IsModified = true;
                
                await _dbContext.SaveChangesAsync();
            }
            catch (Exception exception)
            {
                throw new GameRepositoryException(exception);
            }
        }
    }
}
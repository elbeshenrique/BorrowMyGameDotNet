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
    public class GameEFRepository : IGameRepository
    {
        private readonly ApplicationDbContext dbContext;
        private readonly IGamePresenter presenter;

        public GameEFRepository(ApplicationDbContext dbContext, IGamePresenter presenter)
        {
            this.dbContext = dbContext;
            this.presenter = presenter;
        }

        public async Task<IEnumerable<Game>> GetAll()
        {
            try
            {
                var games = await dbContext.Games.ToListAsync();
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
                dbContext.Games.Add(game);
                await dbContext.SaveChangesAsync();
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
                var game = await dbContext.Games.FindAsync(id);
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
                dbContext.Games.Update(game);
                await dbContext.SaveChangesAsync();
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
                var isBorrowedProperty = dbContext.Entry(game).Property(g => g.IsBorrowed);
                isBorrowedProperty.IsModified = true;
                
                await dbContext.SaveChangesAsync();
            }
            catch (Exception exception)
            {
                throw new GameRepositoryException(exception);
            }
        }
    }
}
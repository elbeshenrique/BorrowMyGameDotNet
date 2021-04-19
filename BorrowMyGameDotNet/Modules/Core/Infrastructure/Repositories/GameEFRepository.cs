using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BorrowMyGameDotNet.Data.Contexts;
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

        public GameEFRepository(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<IEnumerable<Game>> GetAllAsync()
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

        public async Task CreateAsync(Game game)
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

        public async Task<Game> FindAsync(int id)
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

        public async Task UpdateAsync(int id, Game game)
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

        public async Task UpdateIsBorrowedAsync(Game game, bool isBorrowed)
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

        public async Task DeleteAsync(Game game)
        {
            try
            {
                dbContext.Games.Remove(game);
                await dbContext.SaveChangesAsync();
            }
            catch (Exception exception)
            {
                throw new GameRepositoryException(exception);
            }
        }
    }
}
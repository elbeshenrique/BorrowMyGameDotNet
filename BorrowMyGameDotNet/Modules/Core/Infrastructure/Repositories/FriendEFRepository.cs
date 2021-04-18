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
    public class FriendEFRepository : IFriendRepository
    {
        private readonly ApplicationDbContext dbContext;
        private readonly IFriendPresenter presenter;

        public FriendEFRepository(ApplicationDbContext dbContext, IFriendPresenter presenter)
        {
            this.dbContext = dbContext;
            this.presenter = presenter;
        }

        public async Task<IEnumerable<Friend>> GetAllAsync()
        {
            try
            {
                var friends = await dbContext.Friends.ToListAsync();
                return friends;
            }
            catch (Exception exception)
            {
                throw new FriendRepositoryException(exception);
            }
        }

        public async Task CreateAsync(Friend friend)
        {
            try
            {
                dbContext.Friends.Add(friend);
                await dbContext.SaveChangesAsync();
            }
            catch (Exception exception)
            {
                throw new FriendRepositoryException(exception);
            }
        }

        public async Task<Friend> FindAsync(int id)
        {
            try
            {
                var friend = await dbContext.Friends.FindAsync(id);
                return friend;
            }
            catch (Exception exception)
            {
                throw new FriendRepositoryException(exception);
            }
        }

        public async Task UpdateAsync(int id, Friend friend)
        {
            try
            {
                dbContext.Friends.Update(friend);
                await dbContext.SaveChangesAsync();
            }
            catch (Exception exception)
            {
                throw new FriendRepositoryException(exception);
            }
        }
    }
}
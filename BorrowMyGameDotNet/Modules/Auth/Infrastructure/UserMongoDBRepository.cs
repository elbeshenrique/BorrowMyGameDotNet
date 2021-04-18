using System;
using System.Threading.Tasks;
using BorrowMyGameDotNet.Data.MongoDB;
using BorrowMyGameDotNet.Modules.Auth.Domain.Entities;
using BorrowMyGameDotNet.Modules.Auth.Domain.Exceptions;
using BorrowMyGameDotNet.Modules.Auth.Domain.Repositories;
using MongoDB.Driver;

namespace BorrowMyGameDotNet.Modules.Auth.Infrastructure
{
    public class UserMongoDBRepository : IUserRepository
    {
        private readonly IMongoCollection<User> usersCollection;

        public UserMongoDBRepository(MongoDBDatabase mongoDBDatabase)
        {
            usersCollection = mongoDBDatabase.GetUsersCollection();
        }

        public async Task<User> GetAsync(string email)
        {
            try
            {
                var asyncQuery = await usersCollection.FindAsync<User>(u => u.Email == email);
                var user = asyncQuery.FirstOrDefault();
                return user;
            }
            catch (Exception exception)
            {
                throw new UserRepositoryException(exception.Message, exception);
            }
        }

    }
}
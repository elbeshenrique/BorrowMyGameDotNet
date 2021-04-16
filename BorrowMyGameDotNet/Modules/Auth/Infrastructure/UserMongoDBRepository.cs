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
        private readonly IMongoCollection<User> users;

        public UserMongoDBRepository(IMongoDBDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);
            users = database.GetCollection<User>(settings.UsersCollectionName);
        }

        public async Task<User> Get(string email)
        {
            try
            {
                var user = (await users.FindAsync<User>(u => u.Email == email)).FirstOrDefault();
                return user;
            }
            catch (Exception exception)
            {
                throw new UserRepositoryException(exception.Message, exception);
            }
        }

    }
}
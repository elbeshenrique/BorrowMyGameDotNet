using BorrowMyGameDotNet.Modules.Auth.Domain.Entities;
using MongoDB.Driver;

namespace BorrowMyGameDotNet.Data.MongoDB
{
    public class MongoDBDatabase
    {
        public const string UsersCollectionName = "Users";

        public IMongoDatabase Database { get; }

        public MongoDBDatabase(IMongoDatabase database)
        {
            Database = database;
        }

        public IMongoCollection<User> GetUsersCollection()
        {
            return Database.GetCollection<User>(MongoDBDatabase.UsersCollectionName);
        }
    }
}
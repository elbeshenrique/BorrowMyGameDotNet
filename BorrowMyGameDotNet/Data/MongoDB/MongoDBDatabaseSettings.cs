namespace BorrowMyGameDotNet.Data.MongoDB
{
    public class MongoDBDatabaseSettings : IMongoDBDatabaseSettings
    {
        public string UsersCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }
}
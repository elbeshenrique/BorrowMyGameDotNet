namespace BorrowMyGameDotNet.Data.MongoDB
{
    public interface IMongoDBDatabaseSettings
    {
        string UsersCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}
using MongoDB.Driver;

public class MongoService
{
    private readonly IMongoDatabase _database;

    public MongoService(IConfiguration configuration)
    {
        var client = new MongoClient(configuration.GetConnectionString("MongoConnection"));
        _database = client.GetDatabase("COCDatabase");
    }

    public IMongoCollection<T> GetCollection<T>(string collectionName)
    {
        return _database.GetCollection<T>(collectionName);
    }
}
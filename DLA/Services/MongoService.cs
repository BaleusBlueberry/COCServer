using DLA.Interface;
using MongoDB.Driver;

namespace DLA.Servises
{
    public class MongoService : IMongoService
    {
        private readonly IMongoDatabase _database;
        private readonly IMongoDatabase _authDatabase;

        public MongoService(IConfiguration config)
        {
            var connectionString = config.GetConnectionString("DefaultConnection");

            // Connect to MongoDB client
            var client = new MongoClient(connectionString);

            // Get databases for COCDatabase and AuthDatabase
            _database = client.GetDatabase(config["DatabaseName"]);
            _authDatabase = client.GetDatabase(config["AuthDatabaseName"]);
        }

        // Method to access collections in the COCDatabase
        public IMongoCollection<T> GetCollection<T>(string name) =>
            _database.GetCollection<T>(name);

        // Method to access collections in AuthDataBase
        public IMongoCollection<T> GetAuthCollection<T>(string name) =>
            _authDatabase.GetCollection<T>(name);
    }
}

using DLA.Interface;
using MongoDB.Driver;

namespace DLA.Services
{
    public class MongoService : IMongoService
    {
        private readonly IMongoDatabase _database;

        public MongoService(IConfiguration config)
        {
            var connectionString = config.GetConnectionString("DefaultConnection");

            // Connect to MongoDB client
            var client = new MongoClient(connectionString);

            // Get databases for COCDatabase and AuthDatabase
            _database = client.GetDatabase(config["DatabaseName"]);
        }

        // Method to access collections in the COCDatabase
        public IMongoCollection<T> GetCollection<T>(string name) =>
            _database.GetCollection<T>(name);
    }
}

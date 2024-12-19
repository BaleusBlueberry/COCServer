using DLA.Interface;
using DLA.Models;
using Humanizer;
using MongoDB.Driver;

namespace DLA.Repository
{
    public class TownHallRepositoryMongo(IMongoService mongo) : MongoRepository<TownHallLevels>(mongo)
    {
        protected readonly IMongoCollection<TownHallLevels> _collection =
            mongo.GetCollection<TownHallLevels>(typeof(TownHallLevels).Name.Pluralize());
    }
}

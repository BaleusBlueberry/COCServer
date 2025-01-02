using DLA.Interface;
using DLA.Models.TownHallModels;
using Humanizer;
using MongoDB.Driver;

namespace DLA.Repository.TownHallRepository
{
    public class TownHallRepositoryMongo(IMongoService mongo) : MongoRepository<TownHallLevels>(mongo, "TownHalls")
    {
        protected readonly IMongoCollection<TownHallLevels> _collection =
            mongo.GetCollection<TownHallLevels>("TownHall");

    }
}

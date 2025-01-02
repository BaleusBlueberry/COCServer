using DLA.Interface;
using DLA.Models.BuildingModels.DefensiveBuildingsModels;
using DLA.Models.TownHallModels;
using MongoDB.Driver;

namespace DLA.Repository.BuildingsRepositories
{
    public class DefensiveBuildingsRepository(IMongoService mongo) : MongoRepository<DefensiveBuildingsModel>(mongo, "DefensiveBuildings")
    {
        protected readonly IMongoCollection<DefensiveBuildingsModel> defensiveBuildingsRepository =
            mongo.GetCollection<DefensiveBuildingsModel>("DefensiveBuildings");
    }
}

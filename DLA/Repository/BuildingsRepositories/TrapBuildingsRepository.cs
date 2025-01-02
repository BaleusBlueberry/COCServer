using DLA.Interface;
using DLA.Models.BuildingModels.DefensiveBuildingsModels;
using DLA.Models.BuildingModels.TrapBuildingsModels;
using DLA.Models.TownHallModels;
using MongoDB.Driver;

namespace DLA.Repository.BuildingsRepositories
{
    public class TrapBuildingsRepository(IMongoService mongo) : MongoRepository<TrapBuildingsModel>(mongo, "TrapBuildings")
    {
        protected readonly IMongoCollection<TrapBuildingsModel> _collection =
            mongo.GetCollection<TrapBuildingsModel>("TrapBuildings");
    }
}

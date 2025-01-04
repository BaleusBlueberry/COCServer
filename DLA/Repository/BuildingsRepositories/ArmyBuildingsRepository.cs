using DLA.Interface;
using DLA.Models.BuildingModels.ArmyBuildingsModels;
using MongoDB.Driver;

namespace DLA.Repository.BuildingsRepositories
{
    public class ArmyBuildingsRepository(IMongoService mongo) : MongoRepository<ArmyBuildingsModel>(mongo, "ArmyBuildings")
    {
        protected readonly IMongoCollection<ArmyBuildingsModel> _collection =
            mongo.GetCollection<ArmyBuildingsModel>("ArmyBuildings");
    }
}

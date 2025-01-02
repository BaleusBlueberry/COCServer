using DLA.Interface;
using DLA.Models.BuildingModels.OtherBuildingsModels;
using MongoDB.Driver;

namespace DLA.Repository.BuildingsRepositories
{
    public class OtherBuildingsRepository(IMongoService mongo) : MongoRepository<OtherBuildingsModel>(mongo, "OtherBuildings")
    {
        protected readonly IMongoCollection<OtherBuildingsModel> _collection =
            mongo.GetCollection<OtherBuildingsModel>("OtherBuildings");
    }
}

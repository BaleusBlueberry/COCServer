using DLA.Interface;
using DLA.Models.BuildingModels.ResourceBuildingsModels;
using MongoDB.Driver;

namespace DLA.Repository.BuildingsRepositories
{
    public class ResourceBuildingsRepository(IMongoService mongo) : MongoRepository<ResourceBuildingsModel>(mongo, "ResourceBuildings")
    {
        protected readonly IMongoCollection<ResourceBuildingsModel> _collection =
            mongo.GetCollection<ResourceBuildingsModel>("ResourceBuildings");
    }
}

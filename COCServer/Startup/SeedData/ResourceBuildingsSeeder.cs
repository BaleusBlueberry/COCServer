using DLA.Models.BuildingModels.ResourceBuildingsModels;
using DLA.Repository;

namespace COCServer.Startup.SeedData
{
    public class ResourceBuildingsSeeder : BaseSeeder<ResourceBuildingsModel>
    {
        public ResourceBuildingsSeeder(IRepository<ResourceBuildingsModel> repository, ILogger<ResourceBuildingsSeeder> logger)
            : base(repository, logger)
        {
        }
    }
}
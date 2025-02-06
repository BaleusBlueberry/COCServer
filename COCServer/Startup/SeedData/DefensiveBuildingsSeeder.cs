using DLA.Models.BuildingModels.DefensiveBuildingsModels;
using DLA.Repository.BuildingsRepositories;
using DLA.Repository;

namespace COCServer.Startup.SeedData
{
    public class DefensiveBuildingsSeeder : BaseSeeder<DefensiveBuildingsModel>
{
    public DefensiveBuildingsSeeder(IRepository<DefensiveBuildingsModel> repository, ILogger<DefensiveBuildingsSeeder> logger)
        : base(repository, logger)
    {
    }
}
}

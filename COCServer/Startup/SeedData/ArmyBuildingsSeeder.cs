using DLA.Models.BuildingModels.ArmyBuildingsModels;
using DLA.Repository;

namespace COCServer.Startup.SeedData
{
    public class ArmyBuildingsSeeder : BaseSeeder<ArmyBuildingsModel>
    {
        public ArmyBuildingsSeeder(IRepository<ArmyBuildingsModel> repository, ILogger<ArmyBuildingsSeeder> logger)
            : base(repository, logger)
        {
        }
    }
}
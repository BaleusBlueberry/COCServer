using DLA.Models.BuildingModels.TrapBuildingsModels;
using DLA.Repository;

namespace COCServer.Startup.SeedData
{
    public class TrapBuildingsSeeder : BaseSeeder<TrapBuildingsModel>
    {
        public TrapBuildingsSeeder(IRepository<TrapBuildingsModel> repository, ILogger<TrapBuildingsSeeder> logger)
            : base(repository, logger)
        {
        }
    }
}
using COCServer.Startup.SeedData;
using DLA.Models.TownHallModels;
using DLA.Repository;

public class TownHallSeeder : BaseSeeder<TownHallLevels>
{
    public TownHallSeeder(IRepository<TownHallLevels> repository, ILogger<TownHallSeeder> logger)
        : base(repository, logger)
    {
    }
}
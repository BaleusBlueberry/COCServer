using DLA.Models.TownHallModels;
using DLA.Repository;
using Newtonsoft.Json;

namespace COCServer.Startup.SeedData;

public class TownHallSeeder
{
    private readonly IRepository<TownHallLevels> _repository;
    private readonly ILogger<TownHallSeeder> _logger;

    public TownHallSeeder(IRepository<TownHallLevels> repository, ILogger<TownHallSeeder> logger)
    {
        _repository = repository;
        _logger = logger;
    }

    public async Task SeedDataAsync()
    {
        var townHallData = await _repository.GetAll();

        if (!townHallData.Any())
        {
            try
            {
                // keep this for testing
                //await _repository.DropCollectionAsync();
                //_logger.LogInformation("TownHallLevels collection dropped successfully.");

                string jsonFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Startup", "StartupData", "TownHallLevelSeed.json");
                if (!File.Exists(jsonFilePath))
                {
                    _logger.LogError($"JSON file not found at {jsonFilePath}");
                    return;
                }

                string jsonData = await File.ReadAllTextAsync(jsonFilePath);
                var townHallLevels = JsonConvert.DeserializeObject<List<TownHallLevels>>(jsonData);

                if (townHallLevels != null)
                {
                    foreach (var townHall in townHallLevels)
                    {
                        await _repository.Add(townHall);
                        _logger.LogInformation($"Seeded TownHall Level {townHall.Level}.");
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"An error occurred while seeding data: {ex.Message}");
            }
        }
        _logger.LogInformation("TownHallLevels is already seeded and exists");
    }
}


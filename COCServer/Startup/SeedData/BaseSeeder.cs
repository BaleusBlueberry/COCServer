using DLA.Models;
using DLA.Repository;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Newtonsoft.Json;

namespace COCServer.Startup.SeedData
{
    public abstract class BaseSeeder<T> where T : IEntity
    {
        private readonly IRepository<T> _repository;
        private readonly ILogger<BaseSeeder<T>> _logger;

        protected BaseSeeder(IRepository<T> repository, ILogger<BaseSeeder<T>> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        public async Task SeedDataAsync(string jsonFileName)
        {
            string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Startup", "StartupData", jsonFileName);
            var existingData = await _repository.GetAll();
            if (!existingData.Any())
            {
                try
                {
                    if (!File.Exists(filePath))
                    {
                        _logger.LogError($"JSON file not found at {filePath}");
                        return;
                    }

                    string jsonData = await File.ReadAllTextAsync(filePath);
                    var entities = JsonConvert.DeserializeObject<List<T>>(jsonData);

                    if (entities != null)
                    {
                        foreach (var entity in entities)
                        {
                            await _repository.Add(entity);
                            _logger.LogInformation($"Seeded {typeof(T).Name}.");
                        }
                    }
                }
                catch (Exception ex)
                {
                    _logger.LogError($"An error occurred while seeding data for {typeof(T).Name}: {ex.Message}");
                }
            }
            else
            {
                _logger.LogInformation($"{typeof(T).Name} is already seeded.");
            }
        }
    }

}

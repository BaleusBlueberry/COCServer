using DLA.Models.BuildingModels;
using DLA.Repository;
using Microsoft.AspNetCore.Mvc;

namespace DLA.Services
{
    public class BuildingService
    {
        private readonly ILogger<BuildingService> _logger;

        public BuildingService(ILogger<BuildingService> logger)
        {
            _logger = logger;
        }

        public async Task<ActionResult> GetBuildings<T>(IRepository<T> repository, string buildingTypeName) where T : BuildingModel
        {
            try
            {
                var buildings = await repository.GetAll();

                if (!buildings.Any())
                    return new NotFoundObjectResult($"No {buildingTypeName} found.");

                return new OkObjectResult(buildings); // 200 OK with data
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error retrieving {buildingTypeName}");
                return new StatusCodeResult(500); // Internal server error
            }
        }

        public async Task<ActionResult> GetBuildingById<T>(IRepository<T> repository, string id, string buildingType) where T : BuildingModel
        {
            if (string.IsNullOrWhiteSpace(id))
                return new BadRequestObjectResult("ID cannot be null or empty.");

            var building = await repository.GetById(id);

            if (building == null)
                return new NotFoundObjectResult($"{buildingType} not found with ID: {id}.");

            return new OkObjectResult(building);
        }

        public async Task<ActionResult> GetBuildingsByLevel<T>(IRepository<T> repository, int level, string buildingType) where T : BuildingModel
        {
            if (level < 1)
                return new BadRequestObjectResult("Level must be a positive integer.");

            var buildings = await repository.FindAll(b => b.Level == level);

            if (buildings == null || !buildings.Any())
                return new NotFoundObjectResult($"No {buildingType} found with Level {level}.");

            return new OkObjectResult(buildings);
        }

        public async Task<ActionResult> DeleteBuilding<T>(IRepository<T> repository, string id, string buildingType) where T : BuildingModel
        {
            var existingBuilding = await repository.FindOne(b => b.Id == id);
            if (existingBuilding == null)
                return new NotFoundObjectResult($"{buildingType} with ID {id} not found.");

            try
            {
                await repository.Delete(id);
                return new NoContentResult(); // 204 No Content
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error deleting {buildingType}");
                return new StatusCodeResult(500); // Internal server error
            }
        }
    }
}

using DLA.Models.BuildingModels;
using DLA.Models.BuildingModels.ArmyBuildingsModels;
using DLA.Models.BuildingModels.DefensiveBuildingsModels;
using DLA.Models.BuildingModels.ResourceBuildingsModels;
using DLA.Models.BuildingModels.TrapBuildingsModels;
using DLA.Models.TownHallModels;
using DLA.Repository;
using DLA.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace COCServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BuildingsController(
            BuildingService buildingService,
            ILogger<BuildingsController> _logger,
            IRepository<DefensiveBuildingsModel> defensiveBuildingsRepository,
            IRepository<ArmyBuildingsModel> armyBuildingsRepository,
            IRepository<ResourceBuildingsModel> resourceBuildingsRepository,
            IRepository<TrapBuildingsModel> trapBuildingsRepository) : ControllerBase
    {
        private readonly IRepository<TownHallLevels> _repository;

        // GET all
        [HttpGet("all")]
        public async Task<ActionResult> GetAll()
        {
            var def = await defensiveBuildingsRepository.GetAll();
            var army = await armyBuildingsRepository.GetAll();
            var resource = await resourceBuildingsRepository.GetAll();
            var trap = await trapBuildingsRepository.GetAll();

            var result = new
            {
                DefensiveBuildings = def,
                ArmyBuildings = army,
                ResourceBuildings = resource,
                TrapBuildings = trap
            };

            if (!result.DefensiveBuildings.Any() &&
                !result.ArmyBuildings.Any() &&
                !result.ResourceBuildings.Any() &&
                !result.TrapBuildings.Any())
            {
                return NotFound("No buildings found.");
            }

            return Ok(result);
        }

        //Get all for each type
        [HttpGet("DefensiveBuildings")]
        public async Task<ActionResult> GetDefensiveBuildings() =>
            await buildingService.GetBuildings(defensiveBuildingsRepository, "Defensive Buildings");

        [HttpGet("ArmyBuildings")]
        public async Task<ActionResult> GetArmyBuildings() =>
            await buildingService.GetBuildings(armyBuildingsRepository, "Army Buildings");

        [HttpGet("ResourceBuildings")]
        public async Task<ActionResult> GetResourceBuildings() =>
            await buildingService.GetBuildings(resourceBuildingsRepository, "Resource Buildings");

        [HttpGet("TrapBuildings")]
        public async Task<ActionResult> GetTrapBuildings() =>
            await buildingService.GetBuildings(trapBuildingsRepository, "Trap Buildings");

        //POST
        [HttpPost("DefensiveBuildings")]
        public async Task<ActionResult> CreateDefensiveBuildings(DefensiveBuildingsModel model) =>
            await CreateBuilding(defensiveBuildingsRepository, model, BuildingTypes.DefensiveBuildings, "Defensive Building");

        [HttpPost("ArmyBuildings")]
        public async Task<ActionResult> CreateArmyBuildings(ArmyBuildingsModel model) =>
            await CreateBuilding(armyBuildingsRepository, model, BuildingTypes.ArmyBuildings, "Army Building");

        [HttpPost("ResourceBuildings")]
        public async Task<ActionResult> CreateResourceBuildings(ResourceBuildingsModel model) =>
            await CreateBuilding(resourceBuildingsRepository, model, BuildingTypes.ResourceBuildings, "Resource Building");

        [HttpPost("TrapBuildings")]
        public async Task<ActionResult> CreateTrapBuildings(TrapBuildingsModel model) =>
            await CreateBuilding(trapBuildingsRepository, model, BuildingTypes.TrapBuildings, "Trap Building");


        //GET by id 
        [HttpGet("DefensiveBuildings/{id}")]
        public async Task<ActionResult> GetByIdDefensiveBuilding(string id) =>
            await buildingService.GetBuildingById(defensiveBuildingsRepository, id, "Defensive Building");

        [HttpGet("ArmyBuildings/{id}")]
        public async Task<ActionResult> GetByIdArmyBuildings(string id) =>
            await buildingService.GetBuildingById(armyBuildingsRepository, id, "Army Building");

        [HttpGet("ResourceBuildings/{id}")]
        public async Task<ActionResult> GetByIdResourceBuilding(string id) =>
            await buildingService.GetBuildingById(resourceBuildingsRepository, id, "Resource Building");

        [HttpGet("TrapBuildings/{id}")]
        public async Task<ActionResult> GetByIdTrapBuilding(string id) =>
            await buildingService.GetBuildingById(trapBuildingsRepository, id, "Trap Building");


        // GET by level
        [HttpGet("DefensiveBuildings/Level/{level}")]
        public async Task<ActionResult> GetByLevelDefensiveBuilding(int level) =>
            await buildingService.GetBuildingsByLevel(defensiveBuildingsRepository, level, "Defensive Buildings");

        [HttpGet("ArmyBuildings/Level/{level}")]
        public async Task<ActionResult> GetByLevelArmyBuildings(int level) =>
            await buildingService.GetBuildingsByLevel(armyBuildingsRepository, level, "Army Buildings");

        [HttpGet("ResourceBuildings/Level/{level}")]
        public async Task<ActionResult> GetByLevelResourceBuilding(int level) =>
            await buildingService.GetBuildingsByLevel(resourceBuildingsRepository, level, "Resource Buildings");

        [HttpGet("TrapBuildings/Level/{level}")]
        public async Task<ActionResult> GetByLevelTrapBuilding(int level) =>
            await buildingService.GetBuildingsByLevel(trapBuildingsRepository, level, "Trap Buildings");


        // PUT 
        [HttpPut("DefensiveBuildings/Edit/{id}")]
        public async Task<ActionResult> UpdateDefensiveBuildings(string id, [FromBody] DefensiveBuildingsModel model) =>
            await UpdateBuilding(defensiveBuildingsRepository, id, model, "Defensive Building");

        [HttpPut("ArmyBuildings/Edit/{id}")]
        public async Task<ActionResult> UpdateArmyBuilding(string id, [FromBody] ArmyBuildingsModel model) =>
            await UpdateBuilding(armyBuildingsRepository, id, model, "Army Building");

        [HttpPut("ResourceBuildings/Edit/{id}")]
        public async Task<ActionResult> UpdateResourceBuilding(string id, [FromBody] ResourceBuildingsModel model) =>
            await UpdateBuilding(resourceBuildingsRepository, id, model, "Resource Building");

        [HttpPut("TrapBuildings/Edit/{id}")]
        public async Task<ActionResult> UpdateTrapBuilding(string id, [FromBody] TrapBuildingsModel model) =>
            await UpdateBuilding(trapBuildingsRepository, id, model, "Trap Building");


        // DELETE 
        [HttpDelete("DefensiveBuildings/Delete/{id}")]
        public async Task<ActionResult> DeleteDefensiveBuilding(string id) =>
            await buildingService.DeleteBuilding(defensiveBuildingsRepository, id, "Defensive Building");

        [HttpDelete("ArmyBuildings/Delete/{id}")]
        public async Task<ActionResult> DeleteArmyBuilding(string id) =>
            await buildingService.DeleteBuilding(armyBuildingsRepository, id, "Army Building");

        [HttpDelete("ResourceBuildings/Delete/{id}")]
        public async Task<ActionResult> DeleteResourceBuilding(string id) =>
            await buildingService.DeleteBuilding(resourceBuildingsRepository, id, "Resource Building");

        [HttpDelete("TrapBuildings/Delete/{id}")]
        public async Task<ActionResult> DeleteTrapBuilding(string id) =>
            await buildingService.DeleteBuilding(trapBuildingsRepository, id, "Trap Building");


        private async Task<ActionResult> CreateBuilding<T>(IRepository<T> repository, T model, BuildingTypes buildingType, string buildingTypeName) where T : BuildingModel
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                // Check if a building with the same level already exists
                var alreadyExists = await repository.FindOne(b => b.Level == model.Level);
                if (alreadyExists != null)
                    return BadRequest($"{buildingTypeName} with Level {model.Level} already exists.");

                // Set the BuildingType and add to the repository
                model.BuildingType = buildingType;
                await repository.Add(model);

                return Created($"/{buildingTypeName.Replace(" ", "")}/{model.Id}", model); // Created 201
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error creating {buildingTypeName}");
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        private async Task<ActionResult> UpdateBuilding<T>(IRepository<T> repository, string id, T model, string buildingType) where T : BuildingModel
        {
            if (id != model.Id)
                return BadRequest("The ID in the URL does not match the ID in the payload.");

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var existingBuilding = await repository.FindOne(b => b.Id == id);
            if (existingBuilding == null)
                return NotFound($"{buildingType} with ID {id} not found.");

            try
            {
                await repository.Update(model);
                return NoContent(); // 204 No Content
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error updating {buildingType}");
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

    }
}

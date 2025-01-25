using System.ComponentModel.DataAnnotations;

namespace DLA.Models.BuildingModels.ResourceBuildingsModels
{
    public class ResourceBuildingsModel : BuildingModel
    {
        public ResourceBuildingsModel()
        {
            BuildingType = BuildingTypes.ResourceBuildings;
        }

        [Range(0, 10000000, ErrorMessage = "Gold Capacity Must be Between 0 and 10000000")]
        public required int StorageCapacityGold { get; set; }

        [Range(0, 10000000, ErrorMessage = "Elixir Capacity Must be Between 0 and 10000000")]
        public required int StorageCapacityElixir { get; set; }

        [Range(0, 400000, ErrorMessage = "Dark Elixir Capacity Must be Between 0 and 400000")]
        public required int StorageCapacityDarkElixir { get; set; }

        [Display(Name = "Production Rate: Per Hour")]
        [Range(0, 10000, ErrorMessage = "Production Rate Must be Between 0 and 10000")]
        public required int ProductionRate { get; set; }


    }
}

using System.ComponentModel.DataAnnotations;

namespace DLA.Models.BuildingModels.ResourceBuildingsModels
{
    public class ResourceBuildingsModel : BuildingModel
    {
        public ResourceBuildingsModel()
        {
            BuildingType = BuildingTypes.ResourceBuildings;
        }

        [Required]
        public required int StorageCapacity { get; set; }

        [Display(Name = "Production Rate: Per Hour")]
        public int ProductionRate { get; set; } = 0;
    }
}

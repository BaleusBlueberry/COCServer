using System.ComponentModel.DataAnnotations;

namespace DLA.Models.BuildingModels.DefensiveBuildingsModels
{
    public class DefensiveBuildingsModel : BuildingModel
    {

        [Required]
        public required BuildingRange BuildingRange { get; set; }

        [Required]
        public required DamageInfo DamageInfo { get; set; }

        [Required]
        public required Targets Targets { get; set; }
    }
}

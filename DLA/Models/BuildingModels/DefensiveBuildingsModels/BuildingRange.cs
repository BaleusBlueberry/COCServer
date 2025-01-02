using System.ComponentModel.DataAnnotations;

namespace DLA.Models.BuildingModels.DefensiveBuildingsModels
{
    public class BuildingRange
    {
        [Required]
        public required float MaxRange { get; set; }
        public float MinRange { get; set; } = 0;
    }
}
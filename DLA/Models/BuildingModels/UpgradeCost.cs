using System.ComponentModel.DataAnnotations;

namespace DLA.Models.BuildingModels
{
    public class UpgradeCost
    {
        [Required]
        public ResourceType ResourceType { get; set; }

        [Required]
        public int Cost { get; set; }
    }
}
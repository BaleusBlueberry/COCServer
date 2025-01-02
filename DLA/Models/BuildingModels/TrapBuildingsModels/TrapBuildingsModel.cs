using System.ComponentModel.DataAnnotations;
using DLA.Models.BuildingModels.DefensiveBuildingsModels;

namespace DLA.Models.BuildingModels.TrapBuildingsModels
{
    public class TrapBuildingsModel : BuildingModel
    {
        public TrapBuildingsModel()
        {
            BuildingType = BuildingTypes.TrapBuildings;
        }
        [Required]
        public required DamageTrapInfo DamageType { get; set; }

        [Required]
        public required float TriggerRadius { get; set; }

        [Required]
        public int SpawnedUnits { get; set; } = 0;

    }

    public class DamageTrapInfo
    {
        public DamageType DamageType { get; set; } = DamageType.None;
        public float DamageRadius { get; set; } = 0;
        public int Damage { get; set; } = 0;
    }
}

using System.ComponentModel.DataAnnotations;
using DLA.Models.BuildingModels.DefensiveBuildingsModels;

namespace DLA.Models.BuildingModels.TrapBuildingsModels
{
    public class TrapBuildingsModel : BuildingModel
    {
        [Required]
        public required DamageTrapInfo DamageType { get; set; }

        [Required]
        public required float TriggerRadius { get; set; }

        public int? SpawnedUnits { get; set; }

    }

    public class DamageTrapInfo
    {
        public DamageType DamageType { get; set; } = DamageType.None;
        public float DamageRadius { get; set; }
        public int Damage { get; set; }
    }
}

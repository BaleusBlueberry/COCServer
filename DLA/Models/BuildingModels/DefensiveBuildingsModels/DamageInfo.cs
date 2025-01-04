namespace DLA.Models.BuildingModels.DefensiveBuildingsModels
{
    public class DamageInfo
    {
        public float? DamagePerHit { get; set; }
        public int? DamagePerSecond { get; set; }
        public int? ShockwaveDamage { get; set; }
        public int? BurstsFire { get; set; }
        public int? DamageWhenDestroyed { get; set; }
        public float? PushStrength { get; set; }
        public required DamageType DamageType { get; set; }

    }
}
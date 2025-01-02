namespace DLA.Models.BuildingModels.DefensiveBuildingsModels
{
    public class DamageInfo
    {
        public float DamagePerHit { get; set; } = 0;
        public int DamagePerSecond { get; set; } = 0;
        public int ShockwaveDamage { get; set; } = 0;
        public int BurstsFire { get; set; } = 0;
        public int DamageWhenDestroyed { get; set; } = 0;
        public float PushStrength { get;set; } = 0;
        public required DamageType DamageType { get; set; }

    }
}
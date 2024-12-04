namespace DLA.Models.TownHallModels
{
    public class TrapBuildingsTownHall : IEntity
    {
        public int? Id { get; set; }
        public int Bomb { get; set; } = 0;

        public int SpringTrap { get; set; } = 0;

        public int AirBomb { get; set; } = 0;

        public int GiantBomb { get; set; } = 0;

        public int SeekingAirMine { get; set; } = 0;

        public int SkeletonTrap { get; set; } = 0;

        public int TornadoTrap { get; set; } = 0;

    }
}

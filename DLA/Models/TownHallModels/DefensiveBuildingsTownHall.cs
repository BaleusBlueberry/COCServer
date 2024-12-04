namespace DLA.Models.TownHallModels
{

    public class DefensiveBuildingsTownHall: IEntity
    {
        public int? Id { get; set; }
        public int Cannon { get; set; } = 0;

        public int ArcherTower { get; set; } = 0;

        public int BuilderHut { get; set; } = 0;

        public int Walls { get; set; } = 0;

        public int Scattershot { get; set; } = 0;

        public int Mortar { get; set; } = 0;

        public int AirDefense { get; set; } = 0;

        public int WizardTower { get; set; } = 0;

        public int AirSweeper { get; set; } = 0;

        public int HiddenTesla { get; set; } = 0;

        public int BombTower { get; set; } = 0;

        public int XBow { get; set; } = 0;

        public int InfernoTower { get; set; } = 0;

        public int EagleArtillery { get; set; } = 0;
    }
}

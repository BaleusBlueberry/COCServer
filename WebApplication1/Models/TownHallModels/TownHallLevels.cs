namespace WebApplication1.Models.TownHallModels
{
    public class TownHallLevels
    {
        required
        public OtherBuildingsTownHall OtherBuildings
        { get; set; }
        required
        public DefensiveBuildingsTownHall DefensiveBuildings
        { get; set; }
        required
        public TrapBuildingsTownHall TrapBuildings
        { get; set; }
        required
        public HeroesTownHall Herose
        { get; set; }
        required
        public LaboratoryTownHall LaboratoryUpgrades
        { get; set; }
        public ResourceBuildings ResourceBuildings { set; get; }
        required
        public string Picture
        { get; set; }
    }

    public class ResourceBuildings
    {
    }
}

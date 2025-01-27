namespace DLA.Models.UserData
{
    public class FavoriteBuildingsModel
    {
        public List<string> ArmyBuildings { get; set; } = new List<string>();
        public List<string> DefensiveBuildings { get; set; } = new List<string>();
        public List<string> ResourceBuildings { get; set; } = new List<string>();
        public List<string> TrapBuildings { get; set; } = new List<string>();
    }
}

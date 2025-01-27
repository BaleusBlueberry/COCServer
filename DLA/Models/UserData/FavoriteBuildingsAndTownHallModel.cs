namespace DLA.Models.UserData
{
    public class FavoriteBuildingsAndTownHallModel
    {
        public List<string> FavoriteTownHalls { get; set; } = new List<string>();
        public FavoriteBuildingsModel FavoriteBuildings { get; set; } = new FavoriteBuildingsModel();
    }
}

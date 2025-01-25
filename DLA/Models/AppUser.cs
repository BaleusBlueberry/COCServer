using AspNetCore.Identity.Mongo.Model;

namespace DLA.Models
{
    public class AppUser : MongoUser
    {
        public List<string> FavoriteBuildings { get; set; } = new List<string>();
        public List<string> FavoriteTownHalls { get; set; } = new List<string>();
    }
    public class AppRole : MongoRole
    {
    }
}
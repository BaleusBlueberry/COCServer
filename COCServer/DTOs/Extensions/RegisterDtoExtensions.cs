using DLA.Models;
using DLA.Models.UserData;

namespace COCServer.DTOs.Extensions
{
    public static class RegisterDtoExtensions
    {
        public static FavoriteBuildingsAndTownHallModel ToFavorites(this AppUser user)
        {
            return new FavoriteBuildingsAndTownHallModel
            {
                FavoriteTownHalls = user.FavoriteTownHalls,
                FavoriteBuildings = user.FavoriteBuildings
            };
        }
    }
}

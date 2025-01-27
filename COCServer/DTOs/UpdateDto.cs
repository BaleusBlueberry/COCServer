using DLA.Models.UserData;
using System.ComponentModel.DataAnnotations;

namespace COCServer.DTOs
{
    public class UpdateUserDto
    {
        [Required]
        public required string UserId { get; set; }

        [EmailAddress]
        public string? Email { get; set; }

        [MinLength(2), MaxLength(20)]
        public string? UserName { get; set; }

        [DataType(DataType.Password)]
        [MinLength(2), MaxLength(21)]
        public string? NewPassword { get; set; }

        [DataType(DataType.Password)]
        [MinLength(2), MaxLength(21)]
        public string? CurrentPassword { get; set; }
    }

    public class UpdateFavorites
    {
        [Required]
        public required string UserId { get; set; }

        public List<string> FavoriteTownHalls { get; set; } = new List<string>();
        public FavoriteBuildingsModel FavoriteBuildings { get; set; } = new FavoriteBuildingsModel();
    }
}

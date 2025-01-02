
using System.ComponentModel.DataAnnotations;
using DLA.Models.TownHallModels;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace DLA.Models.BuildingModels
{
    public class BuildingModel : IEntity
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        [Required]
        public required string Name { get; set; }

        [Required]
        [Range(1, 25, ErrorMessage = "Level Must be Between 1 and 25")]
        public required int Level { get; set; }

        [Required]
        [Display(Name = "Upgrade Time")]
        public required int UpgradeTimeSeconds { get; set; }

        [Required]
        [Range(1, 10000, ErrorMessage = "Hp Must be Between 1 and 10000")]
        public required int Hp { set; get; }

        [Required]
        [Display(Name = "Experience Gained")]
        [Range(1, 10000, ErrorMessage = "Experience Must be Between 1 and 10000")]
        public required int Experience { get; set; }

        [Required]
        [Display(Name = "Town Hall Level Required")]
        [Range(1, 17, ErrorMessage = "Experience Must be Between 1 and 10000")]
        public required int TownHallLevel { set; get; }

        public BuildingTypes? BuildingType { get; set; } = BuildingTypes.None;

        public string Picture { get; set; } =
            "https://static.wikia.nocookie.net/clashofclans/images/f/fa/Archer_Tower21.png";

        public required UpgradeCost UpgradeCost { get; set; }

    }
}

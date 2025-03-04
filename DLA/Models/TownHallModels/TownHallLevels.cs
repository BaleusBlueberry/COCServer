using System.ComponentModel.DataAnnotations;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace DLA.Models.TownHallModels
{
    public class TownHallLevels : IEntity
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        [Required]
        [Range(1, 17, ErrorMessage = "Level Must be Between 1 and 17")]
        public int Level { get; set; }
        public string Picture { get; set; } = string.Empty;

        [Required]
        public TownHallData Data { get; set; }
    }
}
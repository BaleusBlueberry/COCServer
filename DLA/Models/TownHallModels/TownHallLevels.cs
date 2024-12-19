using System.ComponentModel.DataAnnotations;
using DLA.Models.TownHallModels;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace DLA.Models
{
    public class TownHallLevels : IEntity
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        [Required]
        public int Level { get; set; }
        public string Picture { get; set; } = string.Empty;

        [Required]
        public TownHallData Data { get; set; }
    }
}
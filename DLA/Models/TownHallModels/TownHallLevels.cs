using System.ComponentModel.DataAnnotations;

namespace DLA.Models.TownHallModels
{
    public class TownHallLevels : IEntity
    {
        [Key]
        public int? Id { get; set; }

        [Required]
        public int Level { get; set; }
        public string Picture
        { get; set; } = string.Empty;

        [Required(ErrorMessage = "The Data field is required.")]
        public TownHallData Data { get; set; }
    }
}

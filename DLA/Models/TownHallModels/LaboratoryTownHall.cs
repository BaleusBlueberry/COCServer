using System.ComponentModel.DataAnnotations;

namespace DLA.Models.TownHallModels
{
    public class LaboratoryTownHall : IEntity
    {
        public int? Id { get; set; }
        [Required]
        public ElixirTownHall ElixirUpgrades
        { get; set; } = new ElixirTownHall();

        [Required]
            public DarkElixirTownHall DarkElixirUpgrades
        { get; set; } = new DarkElixirTownHall();

        [Required]
        public SiegeMachinesTownHall SiegeMachineUpgrades
        { get; set; } = new SiegeMachinesTownHall();
    }
}

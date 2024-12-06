

using System.ComponentModel.DataAnnotations;

namespace DLA.Models.TownHallModels
{
    public class TownHallData : IEntity
    {

        public int? Id { get; set; }
        [Required]
        public OtherBuildingsTownHall OtherBuildings
        { get; set; } = new OtherBuildingsTownHall();

        [Required]
        public DefensiveBuildingsTownHall DefensiveBuildings
        { get; set; } = new DefensiveBuildingsTownHall();

        [Required]
        public TrapBuildingsTownHall TrapBuildings
        { get; set; } = new TrapBuildingsTownHall();

        [Required]
        public HeroesTownHall Heroes
        { get; set; } = new HeroesTownHall();

        [Required]
        public LaboratoryTownHall LaboratoryUpgrades
        { get; set; } = new LaboratoryTownHall
        {
            DarkElixirUpgrades = new DarkElixirTownHall(),
            ElixirUpgrades = new ElixirTownHall(),
            SiegeMachineUpgrades = new SiegeMachinesTownHall(),
        };

        [Required(ErrorMessage = "The ResourceBuildings field is required.")]
        public ResourceBuildings ResourceBuildings { set; get; } = new ResourceBuildings();
    }
}

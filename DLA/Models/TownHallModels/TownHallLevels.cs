using System.ComponentModel.DataAnnotations;

namespace DLA.Models.TownHallModels
{
    public class TownHallLevels : IEntity
    {
        [Key]
        public int? Id { get; set; }

        [Required]
        public int Level { get; set; }

        required
        public OtherBuildingsTownHall OtherBuildings
        { get; set; } = new OtherBuildingsTownHall();

        required
            public DefensiveBuildingsTownHall DefensiveBuildings
        { get; set; } = new DefensiveBuildingsTownHall();

        required
            public TrapBuildingsTownHall TrapBuildings
        { get; set; } = new TrapBuildingsTownHall();

        required
            public HeroesTownHall Heroes
        { get; set; } = new HeroesTownHall();

        required
            public LaboratoryTownHall LaboratoryUpgrades
        { get; set; } = new LaboratoryTownHall
        {
            DarkElixirUpgrades = new DarkElixirTownHall(),
            ElixirUpgrades = new ElixirTownHall(),
            SiegeMachineUpgrades = new SiegeMachinesTownHall(),
        };

        public ResourceBuildings ResourceBuildings { set; get; } = new ResourceBuildings();
        required
        public string Picture
        { get; set; }
    }
}

using DLA.Models.TownHallModels;

namespace DLA.Models.BuildingModels.ArmyBuildingsModels
{
    public class ArmyBuildingsModel : BuildingModel
    {
        public string[]? Unlocks { get; set; }

        public int? Capacity { get; set; }
        public int? HeroSlots { get; set; }
        public HeroesTownHall? HeroUpgrades { get; set; }
    }
}

namespace WebApplication1.Models.TownHallModels
{
    public class LaboratoryTownHall
    {
        required
        public ElixirTownHall ElixirUpgrades
        { get; set; }
        required
        public DarkElixirTownHall DarkElixirUpgrades
        { get; set; }
        required
        public SiegeMachinesTownHall SiegeMachineUpgrades
        { get; set; }
    }
}

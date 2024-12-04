namespace DLA.Models.TownHallModels
{
    public class LaboratoryTownHall : IEntity
    {
        public int? Id { get; set; }
        required
        public ElixirTownHall ElixirUpgrades
        { get; set; } = new ElixirTownHall();

        required
            public DarkElixirTownHall DarkElixirUpgrades
        { get; set; } = new DarkElixirTownHall();

        required
            public SiegeMachinesTownHall SiegeMachineUpgrades
        { get; set; } = new SiegeMachinesTownHall();
    }
}

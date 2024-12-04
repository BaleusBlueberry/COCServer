namespace DLA.Models.TownHallModels;
public class SiegeMachinesTownHall : IEntity
{
    public int? Id { get; set; }
    public int WallWrecker { get; set; } = 0;
    public int BattleBlimp { get; set; } = 0;
    public int StoneSlammer { get; set; } = 0;
    public int SiegeBarracks { get; set; } = 0;
    public int LogLauncher { get; set; } = 0;
    public int FlameFlinger { get; set; } = 0;
    public int BattleDrill { get; set; } = 0;
}
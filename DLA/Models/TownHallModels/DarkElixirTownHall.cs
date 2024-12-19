using Microsoft.EntityFrameworkCore;

namespace DLA.Models.TownHallModels;

[Owned]
public class DarkElixirTownHall
{
    public int Minion { get; set; } = 0;
    public int HogRider { get; set; } = 0;
    public int Valkyrie { get; set; } = 0;
    public int Golem { get; set; } = 0;
    public int Witch { get; set; } = 0;
    public int LavaHound { get; set; } = 0;
    public int Bowler { get; set; } = 0;
    public int IceGolem { get; set; } = 0;
    public int Headhunter { get; set; } = 0;
    public int ApprenticeWarden { get; set; } = 0;
    public int Druid { get; set; } = 0;
    public int PoisonSpell { get; set; } = 0;
    public int EarthquakeSpell { get; set; } = 0;
    public int HasteSpell { get; set; } = 0;
    public int SkeletonSpell { get; set; } = 0;
    public int BatSpell { get; set; } = 0;
    public int OvergrowthSpell { get; set; } = 0;
}
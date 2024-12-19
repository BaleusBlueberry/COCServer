using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client.Extensions.Msal;

namespace DLA.Models.TownHallModels;
public class ResourceBuildings
{
    public int GoldMine { set; get; } = 0;
    public int ElixirCollector { set; get; } = 0;
    public int GoldStorage { set; get; } = 0;
    public int ElixirStorage { set; get; } = 0;
    public int DarkElixirDrill { set; get; } = 0;
    public int DarkElixirStorage { set; get; } = 0;
    public int ClanCastle { set; get; } = 0;

}
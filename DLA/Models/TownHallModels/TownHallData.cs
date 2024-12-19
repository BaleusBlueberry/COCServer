

using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace DLA.Models.TownHallModels;

public class TownHallData
{
    public OtherBuildingsTownHall OtherBuildings { get; set; } = new OtherBuildingsTownHall();
    public DefensiveBuildingsTownHall DefensiveBuildings { get; set; } = new DefensiveBuildingsTownHall();
    public TrapBuildingsTownHall TrapBuildings { get; set; } = new TrapBuildingsTownHall();
    public HeroesTownHall Heroes { get; set; } = new HeroesTownHall();
    public ResourceBuildings ResourceBuildings { get; set; } = new ResourceBuildings();
    public LaboratoryTownHall LaboratoryUpgrades { get; set; } = new LaboratoryTownHall();
}

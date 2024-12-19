using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace DLA.Models.TownHallModels;

public class LaboratoryTownHall
{
    public ElixirTownHall ElixirUpgrades
    { get; set; } = new ElixirTownHall();

    public DarkElixirTownHall DarkElixirUpgrades
    { get; set; } = new DarkElixirTownHall();

    public SiegeMachinesTownHall SiegeMachineUpgrades
    { get; set; } = new SiegeMachinesTownHall();
}


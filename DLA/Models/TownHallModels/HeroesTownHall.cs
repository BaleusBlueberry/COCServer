﻿namespace DLA.Models.TownHallModels
{
    public class HeroesTownHall : IEntity
    {
        public int? Id { get; set; }
        public int BarbarianKing { get; set; } = 0;
        public int ArcherQueen { get; set; } = 0;
        public int GrandWarden { get; set; } = 0;
        public int RoyalChampion { get; set; } = 0;
        public int MinionPrince { get; set; } = 0;

    }
}
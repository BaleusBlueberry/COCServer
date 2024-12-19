//using DAL.Models;
//using DLA.Models.TownHallModels;

//namespace COCServer.DTOs
//{
//    public class TownHallLevelToDto
//    {
//        public static TownHallLevelDto ToTownHallLevelDto(TownHallLevels townHall)
//        {
//            return new TownHallLevelDto
//            {
//                Id = townHall.Id,
//                Level = townHall.Level,
//                Picture = townHall.Picture,
//                Data = new TownHallData
//                {
//                    OtherBuildings = new OtherBuildingsTownHall
//                    {
//                        ArmyCamp = townHall.OtherBuildings.ArmyCamp,
//                        Barracks = townHall.OtherBuildings.Barracks,
//                        DarkBarracks = townHall.OtherBuildings.DarkBarracks,
//                        Laboratory = townHall.OtherBuildings.Laboratory,
//                        SpellFactory = townHall.OtherBuildings.SpellFactory,
//                        DarkSpellFactory = townHall.OtherBuildings.DarkSpellFactory,
//                        Blacksmith = townHall.OtherBuildings.Blacksmith,
//                        Workshop = townHall.OtherBuildings.Workshop,
//                        PetHouse = townHall.OtherBuildings.PetHouse,
//                        HeroHall = townHall.OtherBuildings.HeroHall,
//                        HelperHut = townHall.OtherBuildings.HelperHut,
//                        BOBsHut = townHall.OtherBuildings.BOBsHut
//                    },
//                    DefensiveBuildings = new DefensiveBuildingsTownHall
//                    {
//                        Cannon = townHall.DefensiveBuildings.Cannon,
//                        ArcherTower = townHall.DefensiveBuildings.ArcherTower,
//                        BuilderHut = townHall.DefensiveBuildings.BuilderHut,
//                        Walls = townHall.DefensiveBuildings.Walls,
//                        Mortar = townHall.DefensiveBuildings.Mortar,
//                        AirDefense = townHall.DefensiveBuildings.AirDefense,
//                        WizardTower = townHall.DefensiveBuildings.WizardTower,
//                        AirSweeper = townHall.DefensiveBuildings.AirSweeper,
//                        HiddenTesla = townHall.DefensiveBuildings.HiddenTesla,
//                        BombTower = townHall.DefensiveBuildings.BombTower,
//                        XBow = townHall.DefensiveBuildings.XBow,
//                        InfernoTower = townHall.DefensiveBuildings.InfernoTower,
//                        EagleArtillery = townHall.DefensiveBuildings.EagleArtillery,
//                        Scattershot = townHall.DefensiveBuildings.Scattershot,
//                        SpellTower = townHall.DefensiveBuildings.SpellTower,
//                        Monolith = townHall.DefensiveBuildings.Monolith,
//                        MultiArcherTower = townHall.DefensiveBuildings.MultiArcherTower,
//                        RicochetCannon = townHall.DefensiveBuildings.RicochetCannon,
//                        Firespitter = townHall.DefensiveBuildings.Firespitter
//                    },
//                    TrapBuildings = new TrapBuildingsTownHall
//                    {
//                        Bomb = townHall.TrapBuildings.Bomb,
//                        SpringTrap = townHall.TrapBuildings.SpringTrap,
//                        AirBomb = townHall.TrapBuildings.AirBomb,
//                        GiantBomb = townHall.TrapBuildings.GiantBomb,
//                        SeekingAirMine = townHall.TrapBuildings.SeekingAirMine,
//                        SkeletonTrap = townHall.TrapBuildings.SkeletonTrap,
//                        TornadoTrap = townHall.TrapBuildings.TornadoTrap
//                    },
//                    Heroes = new HeroesTownHall
//                    {
//                        BarbarianKing = townHall.Heroes.BarbarianKing,
//                        ArcherQueen = townHall.Heroes.ArcherQueen,
//                        GrandWarden = townHall.Heroes.GrandWarden,
//                        RoyalChampion = townHall.Heroes.RoyalChampion,
//                        MinionPrince = townHall.Heroes.MinionPrince
//                    },
//                    ResourceBuildings = new ResourceBuildings
//                    {
//                        GoldMine = townHall.ResourceBuildings.GoldMine,
//                        ElixirCollector = townHall.ResourceBuildings.ElixirCollector,
//                        GoldStorage = townHall.ResourceBuildings.GoldStorage,
//                        ElixirStorage = townHall.ResourceBuildings.ElixirStorage,
//                        DarkElixirDrill = townHall.ResourceBuildings.DarkElixirDrill,
//                        DarkElixirStorage = townHall.ResourceBuildings.DarkElixirStorage,
//                        ClanCastle = townHall.ResourceBuildings.ClanCastle
//                    },
//                    LaboratoryUpgrades = new LaboratoryTownHall
//                    {
//                        ElixirUpgrades = new ElixirTownHall
//                        {
//                            Barbarian = townHall.LaboratoryUpgrades.ElixirUpgrades.Barbarian,
//                            Archer = townHall.LaboratoryUpgrades.ElixirUpgrades.Archer,
//                            Giant = townHall.LaboratoryUpgrades.ElixirUpgrades.Giant,
//                            Goblin = townHall.LaboratoryUpgrades.ElixirUpgrades.Goblin,
//                            WallBreaker = townHall.LaboratoryUpgrades.ElixirUpgrades.WallBreaker,
//                            Balloon = townHall.LaboratoryUpgrades.ElixirUpgrades.Balloon,
//                            Wizard = townHall.LaboratoryUpgrades.ElixirUpgrades.Wizard,
//                            Healer = townHall.LaboratoryUpgrades.ElixirUpgrades.Healer,
//                            Dragon = townHall.LaboratoryUpgrades.ElixirUpgrades.Dragon,
//                            PEKKA = townHall.LaboratoryUpgrades.ElixirUpgrades.PEKKA,
//                            BabyDragon = townHall.LaboratoryUpgrades.ElixirUpgrades.BabyDragon,
//                            Miner = townHall.LaboratoryUpgrades.ElixirUpgrades.Miner,
//                            ElectroDragon = townHall.LaboratoryUpgrades.ElixirUpgrades.ElectroDragon,
//                            Yeti = townHall.LaboratoryUpgrades.ElixirUpgrades.Yeti,
//                            DragonRider = townHall.LaboratoryUpgrades.ElixirUpgrades.DragonRider,
//                            ElectroTitan = townHall.LaboratoryUpgrades.ElixirUpgrades.ElectroTitan,
//                            RootRider = townHall.LaboratoryUpgrades.ElixirUpgrades.RootRider,
//                            LightningSpell = townHall.LaboratoryUpgrades.ElixirUpgrades.LightningSpell,
//                            HealingSpell = townHall.LaboratoryUpgrades.ElixirUpgrades.HealingSpell,
//                            RageSpell = townHall.LaboratoryUpgrades.ElixirUpgrades.RageSpell,
//                            JumpSpell = townHall.LaboratoryUpgrades.ElixirUpgrades.JumpSpell,
//                            FreezeSpell = townHall.LaboratoryUpgrades.ElixirUpgrades.FreezeSpell,
//                            CloneSpell = townHall.LaboratoryUpgrades.ElixirUpgrades.CloneSpell,
//                            InvisibilitySpell = townHall.LaboratoryUpgrades.ElixirUpgrades.InvisibilitySpell,
//                            RecallSpell = townHall.LaboratoryUpgrades.ElixirUpgrades.RecallSpell
//                        },
//                        DarkElixirUpgrades = new DarkElixirTownHall
//                        {
//                            Minion = townHall.LaboratoryUpgrades.DarkElixirUpgrades.Minion,
//                            HogRider = townHall.LaboratoryUpgrades.DarkElixirUpgrades.HogRider,
//                            Valkyrie = townHall.LaboratoryUpgrades.DarkElixirUpgrades.Valkyrie,
//                            Golem = townHall.LaboratoryUpgrades.DarkElixirUpgrades.Golem,
//                            Witch = townHall.LaboratoryUpgrades.DarkElixirUpgrades.Witch,
//                            LavaHound = townHall.LaboratoryUpgrades.DarkElixirUpgrades.LavaHound,
//                            Bowler = townHall.LaboratoryUpgrades.DarkElixirUpgrades.Bowler,
//                            IceGolem = townHall.LaboratoryUpgrades.DarkElixirUpgrades.IceGolem,
//                            Headhunter = townHall.LaboratoryUpgrades.DarkElixirUpgrades.Headhunter,
//                            ApprenticeWarden = townHall.LaboratoryUpgrades.DarkElixirUpgrades.ApprenticeWarden,
//                            Druid = townHall.LaboratoryUpgrades.DarkElixirUpgrades.Druid,
//                            PoisonSpell = townHall.LaboratoryUpgrades.DarkElixirUpgrades.PoisonSpell,
//                            EarthquakeSpell = townHall.LaboratoryUpgrades.DarkElixirUpgrades.EarthquakeSpell,
//                            HasteSpell = townHall.LaboratoryUpgrades.DarkElixirUpgrades.HasteSpell,
//                            SkeletonSpell = townHall.LaboratoryUpgrades.DarkElixirUpgrades.SkeletonSpell,
//                            BatSpell = townHall.LaboratoryUpgrades.DarkElixirUpgrades.BatSpell,
//                            OvergrowthSpell = townHall.LaboratoryUpgrades.DarkElixirUpgrades.OvergrowthSpell
//                        },
//                        SiegeMachineUpgrades = new SiegeMachinesTownHall
//                        {
//                            WallWrecker = townHall.LaboratoryUpgrades.SiegeMachineUpgrades.WallWrecker,
//                            BattleBlimp = townHall.LaboratoryUpgrades.SiegeMachineUpgrades.BattleBlimp,
//                            StoneSlammer = townHall.LaboratoryUpgrades.SiegeMachineUpgrades.StoneSlammer,
//                            SiegeBarracks = townHall.LaboratoryUpgrades.SiegeMachineUpgrades.SiegeBarracks,
//                            LogLauncher = townHall.LaboratoryUpgrades.SiegeMachineUpgrades.LogLauncher,
//                            FlameFlinger = townHall.LaboratoryUpgrades.SiegeMachineUpgrades.FlameFlinger,
//                            BattleDrill = townHall.LaboratoryUpgrades.SiegeMachineUpgrades.BattleDrill
//                        }
//                    },

//                }
//            };
//        }

//    }
//}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DLA.Migrations
{
    /// <inheritdoc />
    public partial class InitD : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DarkElixirTownHall",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Minion = table.Column<int>(type: "int", nullable: false),
                    HogRider = table.Column<int>(type: "int", nullable: false),
                    Valkyrie = table.Column<int>(type: "int", nullable: false),
                    Golem = table.Column<int>(type: "int", nullable: false),
                    Witch = table.Column<int>(type: "int", nullable: false),
                    LavaHound = table.Column<int>(type: "int", nullable: false),
                    Bowler = table.Column<int>(type: "int", nullable: false),
                    IceGolem = table.Column<int>(type: "int", nullable: false),
                    Headhunter = table.Column<int>(type: "int", nullable: false),
                    ApprenticeWarden = table.Column<int>(type: "int", nullable: false),
                    Druid = table.Column<int>(type: "int", nullable: false),
                    PoisonSpell = table.Column<int>(type: "int", nullable: false),
                    EarthquakeSpell = table.Column<int>(type: "int", nullable: false),
                    HasteSpell = table.Column<int>(type: "int", nullable: false),
                    SkeletonSpell = table.Column<int>(type: "int", nullable: false),
                    BatSpell = table.Column<int>(type: "int", nullable: false),
                    OvergrowthSpell = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DarkElixirTownHall", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DefensiveBuildingsTownHall",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Cannon = table.Column<int>(type: "int", nullable: false),
                    ArcherTower = table.Column<int>(type: "int", nullable: false),
                    BuilderHut = table.Column<int>(type: "int", nullable: false),
                    Walls = table.Column<int>(type: "int", nullable: false),
                    Scattershot = table.Column<int>(type: "int", nullable: false),
                    Mortar = table.Column<int>(type: "int", nullable: false),
                    AirDefense = table.Column<int>(type: "int", nullable: false),
                    WizardTower = table.Column<int>(type: "int", nullable: false),
                    AirSweeper = table.Column<int>(type: "int", nullable: false),
                    HiddenTesla = table.Column<int>(type: "int", nullable: false),
                    BombTower = table.Column<int>(type: "int", nullable: false),
                    XBow = table.Column<int>(type: "int", nullable: false),
                    InfernoTower = table.Column<int>(type: "int", nullable: false),
                    EagleArtillery = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DefensiveBuildingsTownHall", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ElixirTownHall",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Barbarian = table.Column<int>(type: "int", nullable: false),
                    Archer = table.Column<int>(type: "int", nullable: false),
                    Giant = table.Column<int>(type: "int", nullable: false),
                    Goblin = table.Column<int>(type: "int", nullable: false),
                    WallBreaker = table.Column<int>(type: "int", nullable: false),
                    Balloon = table.Column<int>(type: "int", nullable: false),
                    Wizard = table.Column<int>(type: "int", nullable: false),
                    Healer = table.Column<int>(type: "int", nullable: false),
                    Dragon = table.Column<int>(type: "int", nullable: false),
                    PEKKA = table.Column<int>(type: "int", nullable: false),
                    BabyDragon = table.Column<int>(type: "int", nullable: false),
                    Miner = table.Column<int>(type: "int", nullable: false),
                    ElectroDragon = table.Column<int>(type: "int", nullable: false),
                    Yeti = table.Column<int>(type: "int", nullable: false),
                    DragonRider = table.Column<int>(type: "int", nullable: false),
                    ElectroTitan = table.Column<int>(type: "int", nullable: false),
                    RootRider = table.Column<int>(type: "int", nullable: false),
                    LightningSpell = table.Column<int>(type: "int", nullable: false),
                    HealingSpell = table.Column<int>(type: "int", nullable: false),
                    RageSpell = table.Column<int>(type: "int", nullable: false),
                    JumpSpell = table.Column<int>(type: "int", nullable: false),
                    FreezeSpell = table.Column<int>(type: "int", nullable: false),
                    CloneSpell = table.Column<int>(type: "int", nullable: false),
                    InvisibilitySpell = table.Column<int>(type: "int", nullable: false),
                    RecallSpell = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ElixirTownHall", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HeroesTownHall",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BarbarianKing = table.Column<int>(type: "int", nullable: false),
                    ArcherQueen = table.Column<int>(type: "int", nullable: false),
                    GrandWarden = table.Column<int>(type: "int", nullable: false),
                    RoyalChampion = table.Column<int>(type: "int", nullable: false),
                    MinionPrince = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HeroesTownHall", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OtherBuildingsTownHall",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ArmyCamp = table.Column<int>(type: "int", nullable: false),
                    Barracks = table.Column<int>(type: "int", nullable: false),
                    DarkBarracks = table.Column<int>(type: "int", nullable: false),
                    Laboratory = table.Column<int>(type: "int", nullable: false),
                    SpellFactory = table.Column<int>(type: "int", nullable: false),
                    DarkSpellFactory = table.Column<int>(type: "int", nullable: false),
                    Blacksmith = table.Column<int>(type: "int", nullable: false),
                    Workshop = table.Column<int>(type: "int", nullable: false),
                    PetHouse = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OtherBuildingsTownHall", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ResourceBuildings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResourceBuildings", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SiegeMachinesTownHall",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WallWrecker = table.Column<int>(type: "int", nullable: false),
                    BattleBlimp = table.Column<int>(type: "int", nullable: false),
                    StoneSlammer = table.Column<int>(type: "int", nullable: false),
                    SiegeBarracks = table.Column<int>(type: "int", nullable: false),
                    LogLauncher = table.Column<int>(type: "int", nullable: false),
                    FlameFlinger = table.Column<int>(type: "int", nullable: false),
                    BattleDrill = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SiegeMachinesTownHall", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TrapBuildingsTownHall",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Bomb = table.Column<int>(type: "int", nullable: false),
                    SpringTrap = table.Column<int>(type: "int", nullable: false),
                    AirBomb = table.Column<int>(type: "int", nullable: false),
                    GiantBomb = table.Column<int>(type: "int", nullable: false),
                    SeekingAirMine = table.Column<int>(type: "int", nullable: false),
                    SkeletonTrap = table.Column<int>(type: "int", nullable: false),
                    TornadoTrap = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrapBuildingsTownHall", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LaboratoryTownHall",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ElixirUpgradesId = table.Column<int>(type: "int", nullable: false),
                    DarkElixirUpgradesId = table.Column<int>(type: "int", nullable: false),
                    SiegeMachineUpgradesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LaboratoryTownHall", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LaboratoryTownHall_DarkElixirTownHall_DarkElixirUpgradesId",
                        column: x => x.DarkElixirUpgradesId,
                        principalTable: "DarkElixirTownHall",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LaboratoryTownHall_ElixirTownHall_ElixirUpgradesId",
                        column: x => x.ElixirUpgradesId,
                        principalTable: "ElixirTownHall",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LaboratoryTownHall_SiegeMachinesTownHall_SiegeMachineUpgradesId",
                        column: x => x.SiegeMachineUpgradesId,
                        principalTable: "SiegeMachinesTownHall",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TownHallLevels",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Level = table.Column<int>(type: "int", nullable: false),
                    OtherBuildingsId = table.Column<int>(type: "int", nullable: false),
                    DefensiveBuildingsId = table.Column<int>(type: "int", nullable: false),
                    TrapBuildingsId = table.Column<int>(type: "int", nullable: false),
                    HeroesId = table.Column<int>(type: "int", nullable: false),
                    LaboratoryUpgradesId = table.Column<int>(type: "int", nullable: false),
                    ResourceBuildingsId = table.Column<int>(type: "int", nullable: false),
                    Picture = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TownHallLevels", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TownHallLevels_DefensiveBuildingsTownHall_DefensiveBuildingsId",
                        column: x => x.DefensiveBuildingsId,
                        principalTable: "DefensiveBuildingsTownHall",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TownHallLevels_HeroesTownHall_HeroesId",
                        column: x => x.HeroesId,
                        principalTable: "HeroesTownHall",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TownHallLevels_LaboratoryTownHall_LaboratoryUpgradesId",
                        column: x => x.LaboratoryUpgradesId,
                        principalTable: "LaboratoryTownHall",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TownHallLevels_OtherBuildingsTownHall_OtherBuildingsId",
                        column: x => x.OtherBuildingsId,
                        principalTable: "OtherBuildingsTownHall",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TownHallLevels_ResourceBuildings_ResourceBuildingsId",
                        column: x => x.ResourceBuildingsId,
                        principalTable: "ResourceBuildings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TownHallLevels_TrapBuildingsTownHall_TrapBuildingsId",
                        column: x => x.TrapBuildingsId,
                        principalTable: "TrapBuildingsTownHall",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LaboratoryTownHall_DarkElixirUpgradesId",
                table: "LaboratoryTownHall",
                column: "DarkElixirUpgradesId");

            migrationBuilder.CreateIndex(
                name: "IX_LaboratoryTownHall_ElixirUpgradesId",
                table: "LaboratoryTownHall",
                column: "ElixirUpgradesId");

            migrationBuilder.CreateIndex(
                name: "IX_LaboratoryTownHall_SiegeMachineUpgradesId",
                table: "LaboratoryTownHall",
                column: "SiegeMachineUpgradesId");

            migrationBuilder.CreateIndex(
                name: "IX_TownHallLevels_DefensiveBuildingsId",
                table: "TownHallLevels",
                column: "DefensiveBuildingsId");

            migrationBuilder.CreateIndex(
                name: "IX_TownHallLevels_HeroesId",
                table: "TownHallLevels",
                column: "HeroesId");

            migrationBuilder.CreateIndex(
                name: "IX_TownHallLevels_LaboratoryUpgradesId",
                table: "TownHallLevels",
                column: "LaboratoryUpgradesId");

            migrationBuilder.CreateIndex(
                name: "IX_TownHallLevels_OtherBuildingsId",
                table: "TownHallLevels",
                column: "OtherBuildingsId");

            migrationBuilder.CreateIndex(
                name: "IX_TownHallLevels_ResourceBuildingsId",
                table: "TownHallLevels",
                column: "ResourceBuildingsId");

            migrationBuilder.CreateIndex(
                name: "IX_TownHallLevels_TrapBuildingsId",
                table: "TownHallLevels",
                column: "TrapBuildingsId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TownHallLevels");

            migrationBuilder.DropTable(
                name: "DefensiveBuildingsTownHall");

            migrationBuilder.DropTable(
                name: "HeroesTownHall");

            migrationBuilder.DropTable(
                name: "LaboratoryTownHall");

            migrationBuilder.DropTable(
                name: "OtherBuildingsTownHall");

            migrationBuilder.DropTable(
                name: "ResourceBuildings");

            migrationBuilder.DropTable(
                name: "TrapBuildingsTownHall");

            migrationBuilder.DropTable(
                name: "DarkElixirTownHall");

            migrationBuilder.DropTable(
                name: "ElixirTownHall");

            migrationBuilder.DropTable(
                name: "SiegeMachinesTownHall");
        }
    }
}

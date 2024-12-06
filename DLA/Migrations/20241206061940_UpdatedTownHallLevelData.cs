using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DLA.Migrations
{
    /// <inheritdoc />
    public partial class UpdatedTownHallLevelData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TownHallLevels_DefensiveBuildingsTownHall_DefensiveBuildingsId",
                table: "TownHallLevels");

            migrationBuilder.DropForeignKey(
                name: "FK_TownHallLevels_HeroesTownHall_HeroesId",
                table: "TownHallLevels");

            migrationBuilder.DropForeignKey(
                name: "FK_TownHallLevels_LaboratoryTownHall_LaboratoryUpgradesId",
                table: "TownHallLevels");

            migrationBuilder.DropForeignKey(
                name: "FK_TownHallLevels_OtherBuildingsTownHall_OtherBuildingsId",
                table: "TownHallLevels");

            migrationBuilder.DropForeignKey(
                name: "FK_TownHallLevels_ResourceBuildings_ResourceBuildingsId",
                table: "TownHallLevels");

            migrationBuilder.DropForeignKey(
                name: "FK_TownHallLevels_TrapBuildingsTownHall_TrapBuildingsId",
                table: "TownHallLevels");

            migrationBuilder.DropIndex(
                name: "IX_TownHallLevels_DefensiveBuildingsId",
                table: "TownHallLevels");

            migrationBuilder.DropIndex(
                name: "IX_TownHallLevels_HeroesId",
                table: "TownHallLevels");

            migrationBuilder.DropIndex(
                name: "IX_TownHallLevels_LaboratoryUpgradesId",
                table: "TownHallLevels");

            migrationBuilder.DropIndex(
                name: "IX_TownHallLevels_OtherBuildingsId",
                table: "TownHallLevels");

            migrationBuilder.DropIndex(
                name: "IX_TownHallLevels_ResourceBuildingsId",
                table: "TownHallLevels");

            migrationBuilder.DropColumn(
                name: "DefensiveBuildingsId",
                table: "TownHallLevels");

            migrationBuilder.DropColumn(
                name: "HeroesId",
                table: "TownHallLevels");

            migrationBuilder.DropColumn(
                name: "LaboratoryUpgradesId",
                table: "TownHallLevels");

            migrationBuilder.DropColumn(
                name: "OtherBuildingsId",
                table: "TownHallLevels");

            migrationBuilder.DropColumn(
                name: "ResourceBuildingsId",
                table: "TownHallLevels");

            migrationBuilder.RenameColumn(
                name: "TrapBuildingsId",
                table: "TownHallLevels",
                newName: "DataId");

            migrationBuilder.RenameIndex(
                name: "IX_TownHallLevels_TrapBuildingsId",
                table: "TownHallLevels",
                newName: "IX_TownHallLevels_DataId");

            migrationBuilder.CreateTable(
                name: "TownHallData",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OtherBuildingsId = table.Column<int>(type: "int", nullable: false),
                    DefensiveBuildingsId = table.Column<int>(type: "int", nullable: false),
                    TrapBuildingsId = table.Column<int>(type: "int", nullable: false),
                    HeroesId = table.Column<int>(type: "int", nullable: false),
                    LaboratoryUpgradesId = table.Column<int>(type: "int", nullable: false),
                    ResourceBuildingsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TownHallData", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TownHallData_DefensiveBuildingsTownHall_DefensiveBuildingsId",
                        column: x => x.DefensiveBuildingsId,
                        principalTable: "DefensiveBuildingsTownHall",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TownHallData_HeroesTownHall_HeroesId",
                        column: x => x.HeroesId,
                        principalTable: "HeroesTownHall",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TownHallData_LaboratoryTownHall_LaboratoryUpgradesId",
                        column: x => x.LaboratoryUpgradesId,
                        principalTable: "LaboratoryTownHall",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TownHallData_OtherBuildingsTownHall_OtherBuildingsId",
                        column: x => x.OtherBuildingsId,
                        principalTable: "OtherBuildingsTownHall",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TownHallData_ResourceBuildings_ResourceBuildingsId",
                        column: x => x.ResourceBuildingsId,
                        principalTable: "ResourceBuildings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TownHallData_TrapBuildingsTownHall_TrapBuildingsId",
                        column: x => x.TrapBuildingsId,
                        principalTable: "TrapBuildingsTownHall",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TownHallData_DefensiveBuildingsId",
                table: "TownHallData",
                column: "DefensiveBuildingsId");

            migrationBuilder.CreateIndex(
                name: "IX_TownHallData_HeroesId",
                table: "TownHallData",
                column: "HeroesId");

            migrationBuilder.CreateIndex(
                name: "IX_TownHallData_LaboratoryUpgradesId",
                table: "TownHallData",
                column: "LaboratoryUpgradesId");

            migrationBuilder.CreateIndex(
                name: "IX_TownHallData_OtherBuildingsId",
                table: "TownHallData",
                column: "OtherBuildingsId");

            migrationBuilder.CreateIndex(
                name: "IX_TownHallData_ResourceBuildingsId",
                table: "TownHallData",
                column: "ResourceBuildingsId");

            migrationBuilder.CreateIndex(
                name: "IX_TownHallData_TrapBuildingsId",
                table: "TownHallData",
                column: "TrapBuildingsId");

            migrationBuilder.AddForeignKey(
                name: "FK_TownHallLevels_TownHallData_DataId",
                table: "TownHallLevels",
                column: "DataId",
                principalTable: "TownHallData",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TownHallLevels_TownHallData_DataId",
                table: "TownHallLevels");

            migrationBuilder.DropTable(
                name: "TownHallData");

            migrationBuilder.RenameColumn(
                name: "DataId",
                table: "TownHallLevels",
                newName: "TrapBuildingsId");

            migrationBuilder.RenameIndex(
                name: "IX_TownHallLevels_DataId",
                table: "TownHallLevels",
                newName: "IX_TownHallLevels_TrapBuildingsId");

            migrationBuilder.AddColumn<int>(
                name: "DefensiveBuildingsId",
                table: "TownHallLevels",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "HeroesId",
                table: "TownHallLevels",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "LaboratoryUpgradesId",
                table: "TownHallLevels",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "OtherBuildingsId",
                table: "TownHallLevels",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ResourceBuildingsId",
                table: "TownHallLevels",
                type: "int",
                nullable: false,
                defaultValue: 0);

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

            migrationBuilder.AddForeignKey(
                name: "FK_TownHallLevels_DefensiveBuildingsTownHall_DefensiveBuildingsId",
                table: "TownHallLevels",
                column: "DefensiveBuildingsId",
                principalTable: "DefensiveBuildingsTownHall",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TownHallLevels_HeroesTownHall_HeroesId",
                table: "TownHallLevels",
                column: "HeroesId",
                principalTable: "HeroesTownHall",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TownHallLevels_LaboratoryTownHall_LaboratoryUpgradesId",
                table: "TownHallLevels",
                column: "LaboratoryUpgradesId",
                principalTable: "LaboratoryTownHall",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TownHallLevels_OtherBuildingsTownHall_OtherBuildingsId",
                table: "TownHallLevels",
                column: "OtherBuildingsId",
                principalTable: "OtherBuildingsTownHall",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TownHallLevels_ResourceBuildings_ResourceBuildingsId",
                table: "TownHallLevels",
                column: "ResourceBuildingsId",
                principalTable: "ResourceBuildings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TownHallLevels_TrapBuildingsTownHall_TrapBuildingsId",
                table: "TownHallLevels",
                column: "TrapBuildingsId",
                principalTable: "TrapBuildingsTownHall",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

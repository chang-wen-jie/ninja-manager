using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace NinjaManager.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Equipment",
                columns: table => new
                {
                    EquipmentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    GoldValue = table.Column<int>(type: "int", nullable: false),
                    Category = table.Column<int>(type: "int", nullable: false),
                    Strength = table.Column<int>(type: "int", nullable: false),
                    Intelligence = table.Column<int>(type: "int", nullable: false),
                    Agility = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Equipment", x => x.EquipmentId);
                });

            migrationBuilder.CreateTable(
                name: "Ninjas",
                columns: table => new
                {
                    NinjaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Gold = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ninjas", x => x.NinjaId);
                });

            migrationBuilder.CreateTable(
                name: "EquipmentModelNinjaModel",
                columns: table => new
                {
                    InventoryEquipmentId = table.Column<int>(type: "int", nullable: false),
                    NinjasNinjaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EquipmentModelNinjaModel", x => new { x.InventoryEquipmentId, x.NinjasNinjaId });
                    table.ForeignKey(
                        name: "FK_EquipmentModelNinjaModel_Equipment_InventoryEquipmentId",
                        column: x => x.InventoryEquipmentId,
                        principalTable: "Equipment",
                        principalColumn: "EquipmentId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EquipmentModelNinjaModel_Ninjas_NinjasNinjaId",
                        column: x => x.NinjasNinjaId,
                        principalTable: "Ninjas",
                        principalColumn: "NinjaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Inventories",
                columns: table => new
                {
                    InventoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NinjaId = table.Column<int>(type: "int", nullable: false),
                    EquipmentId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inventories", x => x.InventoryId);
                    table.ForeignKey(
                        name: "FK_Inventories_Equipment_EquipmentId",
                        column: x => x.EquipmentId,
                        principalTable: "Equipment",
                        principalColumn: "EquipmentId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Inventories_Ninjas_NinjaId",
                        column: x => x.NinjaId,
                        principalTable: "Ninjas",
                        principalColumn: "NinjaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Equipment",
                columns: new[] { "EquipmentId", "Agility", "Category", "GoldValue", "Intelligence", "Name", "Strength" },
                values: new object[,]
                {
                    { 1, 0, 0, 10, 0, "Headband", 1 },
                    { 2, 0, 2, 20, 1, "Jacket", 2 },
                    { 3, 1, 3, 5, 0, "Shuriken", 0 },
                    { 4, 0, 3, 8, 1, "Kunai", 0 },
                    { 5, 2, 2, 15, 0, "Weighted Clothes", 3 },
                    { 6, 3, 5, 12, 0, "Ninja Sandals", 0 },
                    { 7, 0, 1, 25, 3, "Necklace of Wisdom", 0 },
                    { 8, 0, 4, 30, 0, "Ring of Strength", 4 },
                    { 9, 0, 3, 50, 5, "Scroll of Healing", 0 },
                    { 10, 0, 3, 100, 0, "Blade of Destiny", 10 }
                });

            migrationBuilder.InsertData(
                table: "Ninjas",
                columns: new[] { "NinjaId", "Gold", "Name" },
                values: new object[,]
                {
                    { 1, 100, "Naruto Uzumaki" },
                    { 2, 150, "Sasuke Uchiha" },
                    { 3, 120, "Sakura Haruno" },
                    { 4, 200, "Kakashi Hatake" },
                    { 5, 90, "Rock Lee" },
                    { 6, 110, "Neji Hyuga" },
                    { 7, 130, "Tenten" },
                    { 8, 250, "Orochimaru" },
                    { 9, 160, "Hinata Hyuga" },
                    { 10, 140, "Shino Aburame" }
                });

            migrationBuilder.InsertData(
                table: "Inventories",
                columns: new[] { "InventoryId", "EquipmentId", "NinjaId" },
                values: new object[,]
                {
                    { 1, 1, 1 },
                    { 2, 2, 1 },
                    { 3, 3, 1 },
                    { 4, 4, 1 },
                    { 5, 1, 2 },
                    { 6, 5, 2 },
                    { 7, 6, 2 },
                    { 8, 2, 3 },
                    { 9, 7, 3 },
                    { 10, 2, 4 },
                    { 11, 8, 4 },
                    { 12, 1, 5 },
                    { 13, 3, 5 },
                    { 14, 9, 5 },
                    { 15, 1, 6 },
                    { 16, 6, 6 },
                    { 17, 5, 6 },
                    { 18, 4, 7 },
                    { 19, 2, 7 },
                    { 20, 10, 8 },
                    { 21, 1, 9 },
                    { 22, 7, 9 },
                    { 23, 1, 10 },
                    { 24, 2, 10 },
                    { 25, 3, 10 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_EquipmentModelNinjaModel_NinjasNinjaId",
                table: "EquipmentModelNinjaModel",
                column: "NinjasNinjaId");

            migrationBuilder.CreateIndex(
                name: "IX_Inventories_EquipmentId",
                table: "Inventories",
                column: "EquipmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Inventories_NinjaId",
                table: "Inventories",
                column: "NinjaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EquipmentModelNinjaModel");

            migrationBuilder.DropTable(
                name: "Inventories");

            migrationBuilder.DropTable(
                name: "Equipment");

            migrationBuilder.DropTable(
                name: "Ninjas");
        }
    }
}

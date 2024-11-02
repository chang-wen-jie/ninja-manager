using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace NinjaManager.Data.Migrations
{
    /// <inheritdoc />
    public partial class FinalTestMigration : Migration
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
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
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
                    { 2, 1, 0, 50, 0, "Steel Helmet", 3 },
                    { 3, 0, 0, 100, 2, "Golden Crown", 5 },
                    { 4, 0, 2, 20, 1, "Jacket", 2 },
                    { 5, 2, 2, 15, 0, "Weighted Clothes", 3 },
                    { 6, 1, 2, 80, 0, "Dragon Armor", 8 },
                    { 7, 1, 3, 5, 0, "Shuriken", 0 },
                    { 8, 0, 3, 8, 1, "Kunai", 0 },
                    { 9, 0, 3, 100, 0, "Blade of Destiny", 10 },
                    { 10, 3, 5, 12, 0, "Ninja Sandals", 0 },
                    { 11, 1, 5, 30, 0, "Steel Boots", 2 },
                    { 12, 5, 5, 60, 0, "Boots of Swiftness", 1 },
                    { 13, 0, 1, 25, 3, "Necklace of Wisdom", 0 },
                    { 14, 1, 1, 40, 1, "Amulet of Power", 2 },
                    { 15, 2, 1, 70, 5, "Silver Chain", 0 },
                    { 16, 0, 4, 30, 0, "Ring of Strength", 4 },
                    { 17, 0, 4, 35, 4, "Ring of Intelligence", 0 },
                    { 18, 4, 4, 50, 1, "Ring of Speed", 0 }
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
                name: "Inventories");

            migrationBuilder.DropTable(
                name: "Equipment");

            migrationBuilder.DropTable(
                name: "Ninjas");
        }
    }
}

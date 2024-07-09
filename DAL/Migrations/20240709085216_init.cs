using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BirthDate = table.Column<DateOnly>(type: "date", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "cellars",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Family = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Manufacturer = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Temperature = table.Column<int>(type: "int", nullable: true),
                    CellarUserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cellars", x => x.Id);
                    table.ForeignKey(
                        name: "FK_cellars_Users_CellarUserId",
                        column: x => x.CellarUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "drawers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    number = table.Column<int>(type: "int", nullable: false),
                    CellarId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_drawers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_drawers_cellars_CellarId",
                        column: x => x.CellarId,
                        principalTable: "cellars",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "bottles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Color = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VintageYear = table.Column<int>(type: "int", nullable: true),
                    YearsOfKeep = table.Column<int>(type: "int", nullable: true),
                    DomainName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PeakInDate = table.Column<DateOnly>(type: "date", nullable: true),
                    PeakOutDate = table.Column<DateOnly>(type: "date", nullable: true),
                    GrapeVariety = table.Column<int>(type: "int", nullable: true),
                    Tava = table.Column<int>(type: "int", nullable: true),
                    Capacity = table.Column<int>(type: "int", nullable: true),
                    WineMakerName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VintageName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Aroma = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<int>(type: "int", nullable: true),
                    PurchaseDate = table.Column<DateOnly>(type: "date", nullable: true),
                    RelatedMeals = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DrawerPosition = table.Column<int>(type: "int", nullable: true),
                    DrawerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_bottles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_bottles_drawers_DrawerId",
                        column: x => x.DrawerId,
                        principalTable: "drawers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_bottles_DrawerId",
                table: "bottles",
                column: "DrawerId");

            migrationBuilder.CreateIndex(
                name: "IX_cellars_CellarUserId",
                table: "cellars",
                column: "CellarUserId");

            migrationBuilder.CreateIndex(
                name: "IX_drawers_CellarId",
                table: "drawers",
                column: "CellarId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "bottles");

            migrationBuilder.DropTable(
                name: "drawers");

            migrationBuilder.DropTable(
                name: "cellars");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}

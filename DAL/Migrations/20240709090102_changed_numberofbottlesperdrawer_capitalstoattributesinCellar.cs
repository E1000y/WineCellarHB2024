using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class changed_numberofbottlesperdrawer_capitalstoattributesinCellar : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "number",
                table: "Drawers",
                newName: "Number");

            migrationBuilder.AddColumn<int>(
                name: "NbOfBottlesPerDrawer",
                table: "Drawers",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NbOfBottlesPerDrawer",
                table: "Drawers");

            migrationBuilder.RenameColumn(
                name: "Number",
                table: "Drawers",
                newName: "number");
        }
    }
}

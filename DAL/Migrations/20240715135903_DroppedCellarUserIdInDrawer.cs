using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class DroppedCellarUserIdInDrawer : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Drawers_AspNetUsers_CellarUserId",
                table: "Drawers");

            migrationBuilder.DropIndex(
                name: "IX_Drawers_CellarUserId",
                table: "Drawers");

            migrationBuilder.DropColumn(
                name: "CellarUserId",
                table: "Drawers");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CellarUserId",
                table: "Drawers",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Drawers_CellarUserId",
                table: "Drawers",
                column: "CellarUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Drawers_AspNetUsers_CellarUserId",
                table: "Drawers",
                column: "CellarUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}

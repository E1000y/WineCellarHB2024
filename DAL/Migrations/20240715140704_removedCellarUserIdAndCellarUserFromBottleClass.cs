using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class removedCellarUserIdAndCellarUserFromBottleClass : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bottles_AspNetUsers_CellarUserId",
                table: "Bottles");

            migrationBuilder.DropIndex(
                name: "IX_Bottles_CellarUserId",
                table: "Bottles");

            migrationBuilder.DropColumn(
                name: "CellarUserId",
                table: "Bottles");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CellarUserId",
                table: "Bottles",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Bottles_CellarUserId",
                table: "Bottles",
                column: "CellarUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Bottles_AspNetUsers_CellarUserId",
                table: "Bottles",
                column: "CellarUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}

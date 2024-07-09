using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class changing_DBSetstoPascalCase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_bottles_drawers_DrawerId",
                table: "bottles");

            migrationBuilder.DropForeignKey(
                name: "FK_cellars_Users_CellarUserId",
                table: "cellars");

            migrationBuilder.DropForeignKey(
                name: "FK_drawers_cellars_CellarId",
                table: "drawers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_drawers",
                table: "drawers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_cellars",
                table: "cellars");

            migrationBuilder.DropPrimaryKey(
                name: "PK_bottles",
                table: "bottles");

            migrationBuilder.RenameTable(
                name: "drawers",
                newName: "Drawers");

            migrationBuilder.RenameTable(
                name: "cellars",
                newName: "Cellars");

            migrationBuilder.RenameTable(
                name: "bottles",
                newName: "Bottles");

            migrationBuilder.RenameIndex(
                name: "IX_drawers_CellarId",
                table: "Drawers",
                newName: "IX_Drawers_CellarId");

            migrationBuilder.RenameIndex(
                name: "IX_cellars_CellarUserId",
                table: "Cellars",
                newName: "IX_Cellars_CellarUserId");

            migrationBuilder.RenameIndex(
                name: "IX_bottles_DrawerId",
                table: "Bottles",
                newName: "IX_Bottles_DrawerId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Drawers",
                table: "Drawers",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Cellars",
                table: "Cellars",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Bottles",
                table: "Bottles",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Bottles_Drawers_DrawerId",
                table: "Bottles",
                column: "DrawerId",
                principalTable: "Drawers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Cellars_Users_CellarUserId",
                table: "Cellars",
                column: "CellarUserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Drawers_Cellars_CellarId",
                table: "Drawers",
                column: "CellarId",
                principalTable: "Cellars",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bottles_Drawers_DrawerId",
                table: "Bottles");

            migrationBuilder.DropForeignKey(
                name: "FK_Cellars_Users_CellarUserId",
                table: "Cellars");

            migrationBuilder.DropForeignKey(
                name: "FK_Drawers_Cellars_CellarId",
                table: "Drawers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Drawers",
                table: "Drawers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Cellars",
                table: "Cellars");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Bottles",
                table: "Bottles");

            migrationBuilder.RenameTable(
                name: "Drawers",
                newName: "drawers");

            migrationBuilder.RenameTable(
                name: "Cellars",
                newName: "cellars");

            migrationBuilder.RenameTable(
                name: "Bottles",
                newName: "bottles");

            migrationBuilder.RenameIndex(
                name: "IX_Drawers_CellarId",
                table: "drawers",
                newName: "IX_drawers_CellarId");

            migrationBuilder.RenameIndex(
                name: "IX_Cellars_CellarUserId",
                table: "cellars",
                newName: "IX_cellars_CellarUserId");

            migrationBuilder.RenameIndex(
                name: "IX_Bottles_DrawerId",
                table: "bottles",
                newName: "IX_bottles_DrawerId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_drawers",
                table: "drawers",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_cellars",
                table: "cellars",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_bottles",
                table: "bottles",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_bottles_drawers_DrawerId",
                table: "bottles",
                column: "DrawerId",
                principalTable: "drawers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_cellars_Users_CellarUserId",
                table: "cellars",
                column: "CellarUserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_drawers_cellars_CellarId",
                table: "drawers",
                column: "CellarId",
                principalTable: "cellars",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebCarApplication.Migrations
{
    /// <inheritdoc />
    public partial class CorrectionRelationFinition : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Finitions_Modeles_ModeleId",
                table: "Finitions");

            migrationBuilder.DropIndex(
                name: "IX_ModeleFinitions_ModeleId",
                table: "ModeleFinitions");

            migrationBuilder.DropIndex(
                name: "IX_Finitions_ModeleId",
                table: "Finitions");

            migrationBuilder.DropColumn(
                name: "ModeleId",
                table: "Finitions");

            migrationBuilder.CreateIndex(
                name: "IX_ModeleFinitions_ModeleId_FinitionId",
                table: "ModeleFinitions",
                columns: new[] { "ModeleId", "FinitionId" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_ModeleFinitions_ModeleId_FinitionId",
                table: "ModeleFinitions");

            migrationBuilder.AddColumn<int>(
                name: "ModeleId",
                table: "Finitions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_ModeleFinitions_ModeleId",
                table: "ModeleFinitions",
                column: "ModeleId");

            migrationBuilder.CreateIndex(
                name: "IX_Finitions_ModeleId",
                table: "Finitions",
                column: "ModeleId");

            migrationBuilder.AddForeignKey(
                name: "FK_Finitions_Modeles_ModeleId",
                table: "Finitions",
                column: "ModeleId",
                principalTable: "Modeles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

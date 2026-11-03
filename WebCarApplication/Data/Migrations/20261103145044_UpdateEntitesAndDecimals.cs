using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebCarApplication.Data.Migrations
{
    /// <inheritdoc />
    public partial class UpdateEntitesAndDecimals : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ReparationVoiture");

            migrationBuilder.AlterColumn<decimal>(
                name: "PrixAchat",
                table: "Voitures",
                type: "decimal(18,2)",
                precision: 18,
                scale: 2,
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Voitures",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateVente",
                table: "Voitures",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<int>(
                name: "CodeVin",
                table: "Voitures",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<decimal>(
                name: "CoutReparation",
                table: "Reparations",
                type: "decimal(18,2)",
                precision: 18,
                scale: 2,
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<int>(
                name: "VoitureId",
                table: "Reparations",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Reparations_VoitureId",
                table: "Reparations",
                column: "VoitureId");

            migrationBuilder.AddForeignKey(
                name: "FK_Reparations_Voitures_VoitureId",
                table: "Reparations",
                column: "VoitureId",
                principalTable: "Voitures",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reparations_Voitures_VoitureId",
                table: "Reparations");

            migrationBuilder.DropIndex(
                name: "IX_Reparations_VoitureId",
                table: "Reparations");

            migrationBuilder.DropColumn(
                name: "CoutReparation",
                table: "Reparations");

            migrationBuilder.DropColumn(
                name: "VoitureId",
                table: "Reparations");

            migrationBuilder.AlterColumn<int>(
                name: "PrixAchat",
                table: "Voitures",
                type: "int",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)",
                oldPrecision: 18,
                oldScale: 2);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Voitures",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateVente",
                table: "Voitures",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CodeVin",
                table: "Voitures",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "ReparationVoiture",
                columns: table => new
                {
                    ReparationsId = table.Column<int>(type: "int", nullable: false),
                    VoituresId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReparationVoiture", x => new { x.ReparationsId, x.VoituresId });
                    table.ForeignKey(
                        name: "FK_ReparationVoiture_Reparations_ReparationsId",
                        column: x => x.ReparationsId,
                        principalTable: "Reparations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ReparationVoiture_Voitures_VoituresId",
                        column: x => x.VoituresId,
                        principalTable: "Voitures",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ReparationVoiture_VoituresId",
                table: "ReparationVoiture",
                column: "VoituresId");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebCarApplication.Migrations
{
    /// <inheritdoc />
    public partial class AjoutCodeVinTexteEtDisponibilite : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "CodeVin",
                table: "Voitures",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Disponible",
                table: "Voitures",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Disponible",
                table: "Voitures");

            migrationBuilder.AlterColumn<int>(
                name: "CodeVin",
                table: "Voitures",
                type: "int",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }
    }
}

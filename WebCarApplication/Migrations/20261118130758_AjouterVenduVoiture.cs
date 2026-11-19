using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebCarApplication.Migrations
{
    /// <inheritdoc />
    public partial class AjouterVenduVoiture : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Vendu",
                table: "Voitures",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Vendu",
                table: "Voitures");
        }
    }
}

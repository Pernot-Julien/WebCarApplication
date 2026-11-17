using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebCarApplication.Migrations
{
    /// <inheritdoc />
    public partial class AjoutParametresApplication : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ParametresApplication",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MargeBenefice = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ParametresApplication", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "ParametresApplication",
                columns: new[] { "Id", "MargeBenefice" },
                values: new object[] { 1, 500m });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ParametresApplication");
        }
    }
}

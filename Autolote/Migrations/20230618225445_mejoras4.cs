using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Autolote.Migrations
{
    /// <inheritdoc />
    public partial class mejoras4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SaldoInsoluto",
                table: "RegistrosVentas");

            migrationBuilder.AddColumn<bool>(
                name: "Vendido",
                table: "Vehiculos",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "TipoDePago",
                table: "RegistrosVentas",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Vendido",
                table: "Vehiculos");

            migrationBuilder.DropColumn(
                name: "TipoDePago",
                table: "RegistrosVentas");

            migrationBuilder.AddColumn<decimal>(
                name: "SaldoInsoluto",
                table: "RegistrosVentas",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Autolote.Migrations
{
    /// <inheritdoc />
    public partial class mejoras3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte[]>(
                name: "Imagen",
                table: "Vehiculos",
                type: "varbinary(max)",
                nullable: false,
                defaultValue: new byte[0]);

            migrationBuilder.AddColumn<decimal>(
                name: "SaldoInsoluto",
                table: "RegistrosVentas",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Imagen",
                table: "Vehiculos");

            migrationBuilder.DropColumn(
                name: "SaldoInsoluto",
                table: "RegistrosVentas");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Autolote.Migrations
{
    /// <inheritdoc />
    public partial class Mejoras : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RegistrosVentas_Clientes_ClienteId",
                table: "RegistrosVentas");

            migrationBuilder.DropIndex(
                name: "IX_RegistrosVentas_ClienteId",
                table: "RegistrosVentas");

            migrationBuilder.DropColumn(
                name: "ClienteId",
                table: "RegistrosVentas");

            migrationBuilder.AlterColumn<string>(
                name: "CedulaId",
                table: "RegistrosVentas",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_RegistrosVentas_CedulaId",
                table: "RegistrosVentas",
                column: "CedulaId");

            migrationBuilder.AddForeignKey(
                name: "FK_RegistrosVentas_Clientes_CedulaId",
                table: "RegistrosVentas",
                column: "CedulaId",
                principalTable: "Clientes",
                principalColumn: "CedulaId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RegistrosVentas_Clientes_CedulaId",
                table: "RegistrosVentas");

            migrationBuilder.DropIndex(
                name: "IX_RegistrosVentas_CedulaId",
                table: "RegistrosVentas");

            migrationBuilder.AlterColumn<string>(
                name: "CedulaId",
                table: "RegistrosVentas",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<string>(
                name: "ClienteId",
                table: "RegistrosVentas",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_RegistrosVentas_ClienteId",
                table: "RegistrosVentas",
                column: "ClienteId");

            migrationBuilder.AddForeignKey(
                name: "FK_RegistrosVentas_Clientes_ClienteId",
                table: "RegistrosVentas",
                column: "ClienteId",
                principalTable: "Clientes",
                principalColumn: "CedulaId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

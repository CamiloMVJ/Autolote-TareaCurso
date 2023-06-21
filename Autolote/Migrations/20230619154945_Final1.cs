using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Autolote.Migrations
{
    /// <inheritdoc />
    public partial class Final1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Motor",
                table: "Vehiculos",
                newName: "Modelo");

            migrationBuilder.UpdateData(
                table: "Vehiculos",
                keyColumn: "VehiculoId",
                keyValue: 1,
                columns: new[] { "Descripcion", "Modelo" },
                values: new object[] { "2.8 Turbo Diesel con intercoler de 5 velocidades", "Toyota Prado TXL AUT TELA" });

            migrationBuilder.UpdateData(
                table: "Vehiculos",
                keyColumn: "VehiculoId",
                keyValue: 2,
                columns: new[] { "Descripcion", "Modelo" },
                values: new object[] { "1NR-FE con 4 cilindros 16 valvulas DOHC Potencia Máxima:98HP", "Toyota Yaris" });

            migrationBuilder.UpdateData(
                table: "Vehiculos",
                keyColumn: "VehiculoId",
                keyValue: 3,
                columns: new[] { "Descripcion", "Modelo" },
                values: new object[] { "M20A-FKS con 4 cilindros, Automatico de 6 velocidades Inyección eletrónica", "Toyota RAV4 " });

            migrationBuilder.UpdateData(
                table: "Vehiculos",
                keyColumn: "VehiculoId",
                keyValue: 4,
                columns: new[] { "Descripcion", "Modelo" },
                values: new object[] { "3.6l V6, potencia 308hp, torque de 366Nm, tracción (AWD) sistema de emisiones Tier 3", "Chevrolet Blazer" });

            migrationBuilder.UpdateData(
                table: "Vehiculos",
                keyColumn: "VehiculoId",
                keyValue: 5,
                columns: new[] { "Descripcion", "Modelo" },
                values: new object[] { "xDrive 60 cambio automático sistema de propulsión eléctrico, tipo de tracción xDrive", "BMW i7 " });

            migrationBuilder.UpdateData(
                table: "Vehiculos",
                keyColumn: "VehiculoId",
                keyValue: 6,
                columns: new[] { "Descripcion", "Modelo" },
                values: new object[] { "turbo 2.8L con 200Hp y 500Nm de torque, tracción 4x4, tanque de gasolina 76L", "Chevrolet Colorado" });

            migrationBuilder.UpdateData(
                table: "Vehiculos",
                keyColumn: "VehiculoId",
                keyValue: 7,
                columns: new[] { "Descripcion", "Modelo" },
                values: new object[] { "2ZR-FXE, 4 Cilindros, 1,798cc, potencia 120hp, torque de 142Nm", "Toyota Corolla Across Híbrido" });

            migrationBuilder.UpdateData(
                table: "Vehiculos",
                keyColumn: "VehiculoId",
                keyValue: 8,
                columns: new[] { "Descripcion", "Modelo" },
                values: new object[] { "cambio automático sistema de propulsión Diesel, tipo de tracción sDrive", "BMW XSDrive" });

            migrationBuilder.UpdateData(
                table: "Vehiculos",
                keyColumn: "VehiculoId",
                keyValue: 9,
                columns: new[] { "Descripcion", "Modelo" },
                values: new object[] { "3 cilindros en línea DOH 12 válvulas y DCVVT, Inyección gasolina cambio mécanico", "KIA Picanto" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Modelo",
                table: "Vehiculos",
                newName: "Motor");

            migrationBuilder.UpdateData(
                table: "Vehiculos",
                keyColumn: "VehiculoId",
                keyValue: 1,
                columns: new[] { "Descripcion", "Motor" },
                values: new object[] { "Toyota Prado TXL AUT TELA", "2.8 Turbo Diesel con intercoler de 5 velocidades" });

            migrationBuilder.UpdateData(
                table: "Vehiculos",
                keyColumn: "VehiculoId",
                keyValue: 2,
                columns: new[] { "Descripcion", "Motor" },
                values: new object[] { "Toyota Yaris", "1NR-FE con 4 cilindros 16 valvulas DOHC Potencia Máxima:98HP" });

            migrationBuilder.UpdateData(
                table: "Vehiculos",
                keyColumn: "VehiculoId",
                keyValue: 3,
                columns: new[] { "Descripcion", "Motor" },
                values: new object[] { "Toyota RAV4 ", "M20A-FKS con 4 cilindros, Automatico de 6 velocidades Inyección eletrónica" });

            migrationBuilder.UpdateData(
                table: "Vehiculos",
                keyColumn: "VehiculoId",
                keyValue: 4,
                columns: new[] { "Descripcion", "Motor" },
                values: new object[] { "Chevrolet Blazer", "3.6l V6, potencia 308hp, torque de 366Nm, tracción (AWD) sistema de emisiones Tier 3" });

            migrationBuilder.UpdateData(
                table: "Vehiculos",
                keyColumn: "VehiculoId",
                keyValue: 5,
                columns: new[] { "Descripcion", "Motor" },
                values: new object[] { "BMW i7 ", "xDrive 60 cambio automático sistema de propulsión eléctrico, tipo de tracción xDrive" });

            migrationBuilder.UpdateData(
                table: "Vehiculos",
                keyColumn: "VehiculoId",
                keyValue: 6,
                columns: new[] { "Descripcion", "Motor" },
                values: new object[] { "Chevrolet Colorado", "turbo 2.8L con 200Hp y 500Nm de torque, tracción 4x4, tanque de gasolina 76L" });

            migrationBuilder.UpdateData(
                table: "Vehiculos",
                keyColumn: "VehiculoId",
                keyValue: 7,
                columns: new[] { "Descripcion", "Motor" },
                values: new object[] { "Toyota Corolla Across Híbrido", "2ZR-FXE, 4 Cilindros, 1,798cc, potencia 120hp, torque de 142Nm" });

            migrationBuilder.UpdateData(
                table: "Vehiculos",
                keyColumn: "VehiculoId",
                keyValue: 8,
                columns: new[] { "Descripcion", "Motor" },
                values: new object[] { "BMW XSDrive", "cambio automático sistema de propulsión Diesel, tipo de tracción sDrive" });

            migrationBuilder.UpdateData(
                table: "Vehiculos",
                keyColumn: "VehiculoId",
                keyValue: 9,
                columns: new[] { "Descripcion", "Motor" },
                values: new object[] { "KIA Picanto", "3 cilindros en línea DOH 12 válvulas y DCVVT, Inyección gasolina cambio mécanico" });
        }
    }
}

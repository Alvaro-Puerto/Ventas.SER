using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ventas.SER.Migrations
{
    /// <inheritdoc />
    public partial class ClienteCascadoMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Factura_Clientes_ClienteId",
                table: "Factura");

            migrationBuilder.DropForeignKey(
                name: "FK_FacturaDetalle_Factura_FacturaId",
                table: "FacturaDetalle");

            migrationBuilder.AlterColumn<int>(
                name: "FacturaId",
                table: "FacturaDetalle",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Factura_Clientes_ClienteId",
                table: "Factura",
                column: "ClienteId",
                principalTable: "Clientes",
                principalColumn: "ClienteId");

            migrationBuilder.AddForeignKey(
                name: "FK_FacturaDetalle_Factura_FacturaId",
                table: "FacturaDetalle",
                column: "FacturaId",
                principalTable: "Factura",
                principalColumn: "FacturaId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Factura_Clientes_ClienteId",
                table: "Factura");

            migrationBuilder.DropForeignKey(
                name: "FK_FacturaDetalle_Factura_FacturaId",
                table: "FacturaDetalle");

            migrationBuilder.AlterColumn<int>(
                name: "FacturaId",
                table: "FacturaDetalle",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Factura_Clientes_ClienteId",
                table: "Factura",
                column: "ClienteId",
                principalTable: "Clientes",
                principalColumn: "ClienteId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FacturaDetalle_Factura_FacturaId",
                table: "FacturaDetalle",
                column: "FacturaId",
                principalTable: "Factura",
                principalColumn: "FacturaId");
        }
    }
}

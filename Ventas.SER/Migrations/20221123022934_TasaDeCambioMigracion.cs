using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ventas.SER.Migrations
{
    /// <inheritdoc />
    public partial class TasaDeCambioMigracion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TasaCambios",
                columns: table => new
                {
                    TasaCambioId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Fecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Monto = table.Column<float>(type: "real", nullable: false),
                    FechaHoraCreacion = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TasaCambios", x => x.TasaCambioId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TasaCambios_Fecha",
                table: "TasaCambios",
                column: "Fecha",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TasaCambios");
        }
    }
}

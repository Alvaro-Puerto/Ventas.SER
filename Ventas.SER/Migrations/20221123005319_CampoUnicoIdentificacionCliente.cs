﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ventas.SER.Migrations
{
    /// <inheritdoc />
    public partial class CampoUnicoIdentificacionCliente : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Clientes_Identificacion",
                table: "Clientes",
                column: "Identificacion",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Clientes_Identificacion",
                table: "Clientes");
        }
    }
}

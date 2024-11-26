﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DCProyectoPersMVC.Migrations
{
    /// <inheritdoc />
    public partial class Inicial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DCBebida",
                columns: table => new
                {
                    DC_BebidaID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DC_Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DC_Precio = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DC_Tipo = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DCBebida", x => x.DC_BebidaID);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DCBebida");
        }
    }
}

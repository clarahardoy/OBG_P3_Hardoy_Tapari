using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Agencia.LogicaAccesoDatos.Migrations
{
    /// <inheritdoc />
    public partial class MigracionUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "_activo",
                table: "Usuarios",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "AgenciaOrigenId",
                table: "Envios",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "DestinoId",
                table: "Envios",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "Envios",
                type: "nvarchar(13)",
                maxLength: 13,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "_fechaEntrega",
                table: "Envios",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "_fechaInicio",
                table: "Envios",
                type: "datetime2",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Envios_AgenciaOrigenId",
                table: "Envios",
                column: "AgenciaOrigenId");

            migrationBuilder.CreateIndex(
                name: "IX_Envios_DestinoId",
                table: "Envios",
                column: "DestinoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Envios_Sucursales_AgenciaOrigenId",
                table: "Envios",
                column: "AgenciaOrigenId",
                principalTable: "Sucursales",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Envios_Sucursales_DestinoId",
                table: "Envios",
                column: "DestinoId",
                principalTable: "Sucursales",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Envios_Sucursales_AgenciaOrigenId",
                table: "Envios");

            migrationBuilder.DropForeignKey(
                name: "FK_Envios_Sucursales_DestinoId",
                table: "Envios");

            migrationBuilder.DropIndex(
                name: "IX_Envios_AgenciaOrigenId",
                table: "Envios");

            migrationBuilder.DropIndex(
                name: "IX_Envios_DestinoId",
                table: "Envios");

            migrationBuilder.DropColumn(
                name: "_activo",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "AgenciaOrigenId",
                table: "Envios");

            migrationBuilder.DropColumn(
                name: "DestinoId",
                table: "Envios");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "Envios");

            migrationBuilder.DropColumn(
                name: "_fechaEntrega",
                table: "Envios");

            migrationBuilder.DropColumn(
                name: "_fechaInicio",
                table: "Envios");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Agencia.LogicaAccesoDatos.Migrations
{
    /// <inheritdoc />
    public partial class UltimaMigracion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "Envios");

            migrationBuilder.AddColumn<string>(
                name: "TipoEnvio",
                table: "Envios",
                type: "nvarchar(8)",
                maxLength: 8,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "_direccionDestino__calle",
                table: "Envios",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "_direccionDestino__ciudad",
                table: "Envios",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "_direccionDestino__codigoPostal",
                table: "Envios",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "_direccionDestino__departamento",
                table: "Envios",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "_entregaEficiente",
                table: "Envios",
                type: "bit",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TipoEnvio",
                table: "Envios");

            migrationBuilder.DropColumn(
                name: "_direccionDestino__calle",
                table: "Envios");

            migrationBuilder.DropColumn(
                name: "_direccionDestino__ciudad",
                table: "Envios");

            migrationBuilder.DropColumn(
                name: "_direccionDestino__codigoPostal",
                table: "Envios");

            migrationBuilder.DropColumn(
                name: "_direccionDestino__departamento",
                table: "Envios");

            migrationBuilder.DropColumn(
                name: "_entregaEficiente",
                table: "Envios");

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "Envios",
                type: "nvarchar(13)",
                maxLength: 13,
                nullable: false,
                defaultValue: "");
        }
    }
}

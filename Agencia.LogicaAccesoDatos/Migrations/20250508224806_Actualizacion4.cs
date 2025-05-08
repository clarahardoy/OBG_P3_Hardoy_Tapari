using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Agencia.LogicaAccesoDatos.Migrations
{
    /// <inheritdoc />
    public partial class Actualizacion4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "_nroTracking",
                table: "Envios",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "_nroTracking",
                table: "Envios",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }
    }
}

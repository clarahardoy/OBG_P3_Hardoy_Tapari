using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Agencia.LogicaAccesoDatos.Migrations
{
    /// <inheritdoc />
    public partial class CorrecionErrores2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "EntregaEficiente",
                table: "Envios",
                type: "varchar(5)",
                unicode: false,
                maxLength: 5,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "EntregaEficiente",
                table: "Envios",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(5)",
                oldUnicode: false,
                oldMaxLength: 5,
                oldNullable: true);
        }
    }
}

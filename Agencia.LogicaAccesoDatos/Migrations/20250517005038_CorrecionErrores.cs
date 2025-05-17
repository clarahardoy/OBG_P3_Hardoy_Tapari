using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Agencia.LogicaAccesoDatos.Migrations
{
    /// <inheritdoc />
    public partial class CorrecionErrores : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comentarios_Usuarios__empleadoAutorId",
                table: "Comentarios");

            migrationBuilder.DropForeignKey(
                name: "FK_Envios_Sucursales_DestinoId",
                table: "Envios");

            migrationBuilder.DropColumn(
                name: "_activo",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "_entregaEficiente",
                table: "Envios");

            migrationBuilder.RenameColumn(
                name: "_rol",
                table: "Usuarios",
                newName: "Rol");

            migrationBuilder.RenameColumn(
                name: "_password",
                table: "Usuarios",
                newName: "Password");

            migrationBuilder.RenameColumn(
                name: "_nombreCompleto__nombre",
                table: "Usuarios",
                newName: "NombreCompleto_Nombre");

            migrationBuilder.RenameColumn(
                name: "_nombreCompleto__apellido",
                table: "Usuarios",
                newName: "NombreCompleto_Apellido");

            migrationBuilder.RenameColumn(
                name: "_email",
                table: "Usuarios",
                newName: "Email");

            migrationBuilder.RenameColumn(
                name: "_ubicacion__longitud",
                table: "Sucursales",
                newName: "Ubicacion_Longitud");

            migrationBuilder.RenameColumn(
                name: "_ubicacion__latitud",
                table: "Sucursales",
                newName: "Ubicacion_Latitud");

            migrationBuilder.RenameColumn(
                name: "_nombre",
                table: "Sucursales",
                newName: "Nombre");

            migrationBuilder.RenameColumn(
                name: "_direccionPostal",
                table: "Sucursales",
                newName: "DireccionPostal");

            migrationBuilder.RenameColumn(
                name: "_peso",
                table: "Envios",
                newName: "Peso");

            migrationBuilder.RenameColumn(
                name: "_nroTracking",
                table: "Envios",
                newName: "NroTracking");

            migrationBuilder.RenameColumn(
                name: "_fechaInicio",
                table: "Envios",
                newName: "FechaInicio");

            migrationBuilder.RenameColumn(
                name: "_fechaEntrega",
                table: "Envios",
                newName: "FechaEntrega");

            migrationBuilder.RenameColumn(
                name: "_estado",
                table: "Envios",
                newName: "Estado");

            migrationBuilder.RenameColumn(
                name: "_direccionDestino__departamento",
                table: "Envios",
                newName: "EntregaEficiente");

            migrationBuilder.RenameColumn(
                name: "_direccionDestino__codigoPostal",
                table: "Envios",
                newName: "DireccionDestino_Departamento");

            migrationBuilder.RenameColumn(
                name: "_direccionDestino__ciudad",
                table: "Envios",
                newName: "DireccionDestino_CodigoPostal");

            migrationBuilder.RenameColumn(
                name: "_direccionDestino__calle",
                table: "Envios",
                newName: "DireccionDestino_Ciudad");

            migrationBuilder.RenameColumn(
                name: "DestinoId",
                table: "Envios",
                newName: "AgenciaDestinoId");

            migrationBuilder.RenameIndex(
                name: "IX_Envios_DestinoId",
                table: "Envios",
                newName: "IX_Envios_AgenciaDestinoId");

            migrationBuilder.RenameColumn(
                name: "_fecha",
                table: "Comentarios",
                newName: "Fecha");

            migrationBuilder.RenameColumn(
                name: "_empleadoAutorId",
                table: "Comentarios",
                newName: "EmpleadoAutorId");

            migrationBuilder.RenameColumn(
                name: "_descripcion",
                table: "Comentarios",
                newName: "Descripcion");

            migrationBuilder.RenameIndex(
                name: "IX_Comentarios__empleadoAutorId",
                table: "Comentarios",
                newName: "IX_Comentarios_EmpleadoAutorId");

            migrationBuilder.AddColumn<string>(
                name: "Activo",
                table: "Usuarios",
                type: "varchar(5)",
                unicode: false,
                maxLength: 5,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "DireccionDestino_Calle",
                table: "Envios",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Comentarios_Usuarios_EmpleadoAutorId",
                table: "Comentarios",
                column: "EmpleadoAutorId",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Envios_Sucursales_AgenciaDestinoId",
                table: "Envios",
                column: "AgenciaDestinoId",
                principalTable: "Sucursales",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comentarios_Usuarios_EmpleadoAutorId",
                table: "Comentarios");

            migrationBuilder.DropForeignKey(
                name: "FK_Envios_Sucursales_AgenciaDestinoId",
                table: "Envios");

            migrationBuilder.DropColumn(
                name: "Activo",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "DireccionDestino_Calle",
                table: "Envios");

            migrationBuilder.RenameColumn(
                name: "Rol",
                table: "Usuarios",
                newName: "_rol");

            migrationBuilder.RenameColumn(
                name: "Password",
                table: "Usuarios",
                newName: "_password");

            migrationBuilder.RenameColumn(
                name: "NombreCompleto_Nombre",
                table: "Usuarios",
                newName: "_nombreCompleto__nombre");

            migrationBuilder.RenameColumn(
                name: "NombreCompleto_Apellido",
                table: "Usuarios",
                newName: "_nombreCompleto__apellido");

            migrationBuilder.RenameColumn(
                name: "Email",
                table: "Usuarios",
                newName: "_email");

            migrationBuilder.RenameColumn(
                name: "Ubicacion_Longitud",
                table: "Sucursales",
                newName: "_ubicacion__longitud");

            migrationBuilder.RenameColumn(
                name: "Ubicacion_Latitud",
                table: "Sucursales",
                newName: "_ubicacion__latitud");

            migrationBuilder.RenameColumn(
                name: "Nombre",
                table: "Sucursales",
                newName: "_nombre");

            migrationBuilder.RenameColumn(
                name: "DireccionPostal",
                table: "Sucursales",
                newName: "_direccionPostal");

            migrationBuilder.RenameColumn(
                name: "Peso",
                table: "Envios",
                newName: "_peso");

            migrationBuilder.RenameColumn(
                name: "NroTracking",
                table: "Envios",
                newName: "_nroTracking");

            migrationBuilder.RenameColumn(
                name: "FechaInicio",
                table: "Envios",
                newName: "_fechaInicio");

            migrationBuilder.RenameColumn(
                name: "FechaEntrega",
                table: "Envios",
                newName: "_fechaEntrega");

            migrationBuilder.RenameColumn(
                name: "Estado",
                table: "Envios",
                newName: "_estado");

            migrationBuilder.RenameColumn(
                name: "EntregaEficiente",
                table: "Envios",
                newName: "_direccionDestino__departamento");

            migrationBuilder.RenameColumn(
                name: "DireccionDestino_Departamento",
                table: "Envios",
                newName: "_direccionDestino__codigoPostal");

            migrationBuilder.RenameColumn(
                name: "DireccionDestino_CodigoPostal",
                table: "Envios",
                newName: "_direccionDestino__ciudad");

            migrationBuilder.RenameColumn(
                name: "DireccionDestino_Ciudad",
                table: "Envios",
                newName: "_direccionDestino__calle");

            migrationBuilder.RenameColumn(
                name: "AgenciaDestinoId",
                table: "Envios",
                newName: "DestinoId");

            migrationBuilder.RenameIndex(
                name: "IX_Envios_AgenciaDestinoId",
                table: "Envios",
                newName: "IX_Envios_DestinoId");

            migrationBuilder.RenameColumn(
                name: "Fecha",
                table: "Comentarios",
                newName: "_fecha");

            migrationBuilder.RenameColumn(
                name: "EmpleadoAutorId",
                table: "Comentarios",
                newName: "_empleadoAutorId");

            migrationBuilder.RenameColumn(
                name: "Descripcion",
                table: "Comentarios",
                newName: "_descripcion");

            migrationBuilder.RenameIndex(
                name: "IX_Comentarios_EmpleadoAutorId",
                table: "Comentarios",
                newName: "IX_Comentarios__empleadoAutorId");

            migrationBuilder.AddColumn<bool>(
                name: "_activo",
                table: "Usuarios",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "_entregaEficiente",
                table: "Envios",
                type: "bit",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Comentarios_Usuarios__empleadoAutorId",
                table: "Comentarios",
                column: "_empleadoAutorId",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Envios_Sucursales_DestinoId",
                table: "Envios",
                column: "DestinoId",
                principalTable: "Sucursales",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

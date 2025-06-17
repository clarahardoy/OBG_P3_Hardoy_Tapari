
using Agencia.LogicaAccesoDatos;
using Agencia.LogicaAccesoDatos.Repositorios;
using Agencia.LogicaAplicacion.CasosUso.CUAgencia;
using Agencia.LogicaAplicacion.CasosUso.CUEnvio;
using Agencia.LogicaAplicacion.CasosUso.CUUsuario;
using Agencia.LogicaAplicacion.ICasosUso.ICUAgencia;
using Agencia.LogicaAplicacion.ICasosUso.ICUEnvio;
using Agencia.LogicaAplicacion.ICasosUso.ICUUsuario;
using Agencia.LogicaNegocio.InterfacesRepositorios;
using Microsoft.EntityFrameworkCore;

namespace Agencia.WebAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

            builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(connectionString));

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            //DI - REPOSITORIOS :
            builder.Services.AddScoped<IRepositorioAuditoria, RepositorioAuditoria>();
            builder.Services.AddScoped<IRepositorioComentario, RepositorioComentario>();
            builder.Services.AddScoped<IRepositorioEnvio, RepositorioEnvio>();
            builder.Services.AddScoped<IRepositorioSucursal, RepositorioSucursal>();
            builder.Services.AddScoped<IRepositorioUsuario, RepositorioUsuario>();

            //DI - Casos de Uso : 

            // Comentario : 
            builder.Services.AddScoped<ICUAgregarSeguimiento, CUAgregarSeguimiento>();

            // Envio : 
            builder.Services.AddScoped<ICUAltaEnvio, CUAltaEnvio>();
            builder.Services.AddScoped<ICUFinalizarEnvio, CUFinalizarEnvio>();
            builder.Services.AddScoped<ICUObtenerEnvio, CUObtenerEnvio>();
            builder.Services.AddScoped<ICUObtenerEnvioNroTracking, CUObtenerEnvioNroTracking>();
            builder.Services.AddScoped<ICUObtenerEnviosDeClienteOrdFecha, CUObtenerEnviosDeClienteOrdFecha>();
            builder.Services.AddScoped<ICUObtenerEnviosEnProceso, CUObtenerEnviosEnProceso>();
            builder.Services.AddScoped<ICUObtenerEnviosPorFechasDeCliente, CUObtenerEnviosPorFechasDeCliente>();

            // Sucursal:
            builder.Services.AddScoped<ICUObtenerSucursal, CUObtenerSucursal>();
            builder.Services.AddScoped<ICUObtenerSucursales, CUObtenerSucursales>();

            // Usuario :
            builder.Services.AddScoped<ICUActualizarContrasenia, CUActualizarContrasenia>();
            builder.Services.AddScoped<ICUActualizarFuncionario, CUActualizarFuncionario>();
            builder.Services.AddScoped<ICUAltaUsuario, CUAltaUsuario>();
            builder.Services.AddScoped<ICUDesactivarFuncionario, CUDesactivarFuncionario>();
            builder.Services.AddScoped<ICULogin, CULogin>();
            builder.Services.AddScoped<ICUObtenerFuncionarios, CUObtenerFuncionarios>();
            builder.Services.AddScoped<ICUObtenerUsuario, CUObtenerUsuario>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}

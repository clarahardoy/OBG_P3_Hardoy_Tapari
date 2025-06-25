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
using Microsoft.OpenApi.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace Agencia.WebAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Base de datos :
            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
            builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(connectionString));

            // API :
            builder.Services.AddControllers()
                            .AddJsonOptions(opt =>
                            {
                                opt.JsonSerializerOptions.DefaultIgnoreCondition =
                                    System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull;
                            });

            builder.Services.AddEndpointsApiExplorer();

            // Swagger / OpenAPI :
            builder.Services.AddSwaggerGen(cfg =>
            {
                cfg.SwaggerDoc("v1", new OpenApiInfo { Title = "Agencia API", Version = "v1" });

                // “Authorize”
                var scheme = new OpenApiSecurityScheme
                {
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.Http,
                    Scheme = "bearer",
                    BearerFormat = "JWT",
                    Description = "Coloca **solo** el token (sin la palabra Bearer)."
                };
                cfg.AddSecurityDefinition("Bearer", scheme);
                cfg.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    [scheme] = Array.Empty<string>()
                });
            });

            // Autenticación y Autorización (JWT) :
            builder.Services
                   .AddAuthentication(options =>
                   {
                       options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                       options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                   })
                   .AddJwtBearer(options =>
                   {
                       options.TokenValidationParameters = new TokenValidationParameters
                       {
                           ValidateIssuer = false,
                           ValidateAudience = false,
                           ValidateLifetime = true,
                           ValidateIssuerSigningKey = true,
                           IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JwtKey"]))
                       };
                   });

            builder.Services.AddAuthorization();

            // DI - Repsoitorios :
            builder.Services.AddScoped<IRepositorioAuditoria, RepositorioAuditoria>();
            builder.Services.AddScoped<IRepositorioComentario, RepositorioComentario>();
            builder.Services.AddScoped<IRepositorioEnvio, RepositorioEnvio>();
            builder.Services.AddScoped<IRepositorioSucursal, RepositorioSucursal>();
            builder.Services.AddScoped<IRepositorioUsuario, RepositorioUsuario>();

            // DI- Casos de Uso

            // Comentario :
            builder.Services.AddScoped<ICUAgregarSeguimiento, CUAgregarSeguimiento>();

            // Envío :
            builder.Services.AddScoped<ICUAltaEnvio, CUAltaEnvio>();
            builder.Services.AddScoped<ICUFinalizarEnvio, CUFinalizarEnvio>();
            builder.Services.AddScoped<ICUObtenerEnvio, CUObtenerEnvio>();
            builder.Services.AddScoped<ICUObtenerEnvioNroTracking, CUObtenerEnvioNroTracking>();
            builder.Services.AddScoped<ICUObtenerEnviosDeClienteOrdFecha, CUObtenerEnviosDeClienteOrdFecha>();
            builder.Services.AddScoped<ICUObtenerEnviosEnProceso, CUObtenerEnviosEnProceso>();
            builder.Services.AddScoped<ICUObtenerEnviosPorComentario, CUObtenerEnviosPorComentario>();
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

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}
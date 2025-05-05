using Agencia.LogicaNegocio.InterfacesRepositorios;
using Agencia.LogicaAccesoDatos.Repositorios;
using Agencia.LogicaAccesoDatos;
using Agencia.LogicaAplicacion.ICasosUso.ICUUsuario;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Agencia.LogicaAplicacion.CasosUso.CUUsuario;
using Agencia.LogicaAplicacion.ICasosUso.ICUAgencia;
using Agencia.LogicaAplicacion.CasosUso.CUAgencia;
using Agencia.LogicaAplicacion.ICasosUso.ICUEnvio;
using Agencia.LogicaAplicacion.CasosUso.CUEnvio;


var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(connectionString));

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddSession(); // THIS IS THE ADDED CODE

//DI - REPOS
builder.Services.AddScoped<IRepositorioAuditoria, RepositorioAuditoria>();
builder.Services.AddScoped<IRepositorioComentario, RepositorioComentario>();
builder.Services.AddScoped<IRepositorioEnvio, RepositorioEnvio>();
builder.Services.AddScoped<IRepositorioSucursal, RepositorioSucursal>();
builder.Services.AddScoped<IRepositorioUsuario, RepositorioUsuario>();

//DI - CU
builder.Services.AddScoped<ICUActualizarFuncionario, CUActualizarFuncionario>();
builder.Services.AddScoped<ICUAltaUsuario, CUAltaUsuario>();
builder.Services.AddScoped<ICUAltaEnvio, CUAltaEnvio>();
builder.Services.AddScoped<ICUDesactivarFuncionario, CUDesactivarFuncionario>();
builder.Services.AddScoped<ICULogin, CULogin>();
builder.Services.AddScoped<ICUObtenerFuncionarios, CUObtenerFuncionarios>();
builder.Services.AddScoped<ICUObtenerUsuario, CUObtenerUsuario>();
builder.Services.AddScoped<ICUObtenerSucursales, CUObtenerSucursales>();
builder.Services.AddScoped<ICUObtenerEnviosEnProceso, CUObtenerEnviosEnProceso>();
builder.Services.AddScoped<ICUFinalizarEnvio, CUFinalizarEnvio>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.UseSession();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Usuario}/{action=Login}/{id?}");

app.Run();

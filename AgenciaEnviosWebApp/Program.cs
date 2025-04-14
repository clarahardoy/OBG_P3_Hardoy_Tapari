using Agencia.LogicaNegocio.InterfacesRepositorios;
using Agencia.LogicaAccesoDatos.Repositorios;
using Agencia.LogicaAccesoDatos;
using Agencia.LogicaAplicacion.ICasosUso.ICUUsuario;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;


var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(connectionString));

// Add services to the container.
builder.Services.AddControllersWithViews();

//DI - REPOS
// TODO builder.Services.AddScoped<IRepositorioAgencia, RepositorioAgencia>();
builder.Services.AddScoped<IRepositorioComentario, RepositorioComentario>();
builder.Services.AddScoped<IRepositorioEnvio, RepositorioEnvio>();
builder.Services.AddScoped<IRepositorioUsuario, RepositorioUsuario>();
// TO DO: resolver inyeccion de dependecia

builder.Services.AddScoped<ICULogin, ICULogin>();
builder.Services.AddScoped<ICUAltaUsuario, ICUAltaUsuario>();


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

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

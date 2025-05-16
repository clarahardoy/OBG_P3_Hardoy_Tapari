using Agencia.LogicaNegocio.Entidades;
using Agencia.LogicaNegocio.Enumerados.AuditoriaEnums;
using Agencia.LogicaNegocio.Enumerados.EnvioEnums;
using Agencia.LogicaNegocio.Enumerados.UsuarioEnums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agencia.LogicaAccesoDatos
{
    public class ApplicationDbContext : DbContext
    {
        // Constructor:
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        // Entidades de sistema > Tablas:
        public DbSet<Auditoria> Auditorias { get; set; }
        public DbSet<Comentario> Comentarios { get; set; }
        public DbSet<Envio> Envios { get; set; }
        public DbSet<Sucursal> Sucursales { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Envio>()
                .HasOne(v => v._empleado)
                .WithMany()
                .HasForeignKey(v => v.EmpleadoId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Envio>()
                .HasOne(v => v._cliente)
                .WithMany()
                .HasForeignKey(v => v.ClienteId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Envio>()
                .HasOne(v => v._agenciaOrigen)
                .WithMany()
                .HasForeignKey(v => v.AgenciaOrigenId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<EnvioComun>()
                .HasOne(v => v._destino)
                .WithMany()
                .HasForeignKey(v => v.DestinoId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Envio>()
                .HasDiscriminator<string>("TipoEnvio")
                .HasValue<EnvioComun>("Comun")
                .HasValue<EnvioUrgente>("Urgente");

            modelBuilder.Entity<Auditoria>()
                .Property(a => a.Accion)
                .HasConversion(new EnumToStringConverter<Acciones>())
                .HasMaxLength(20)
                .IsUnicode();

            modelBuilder.Entity<Envio>()
                .Property(a => a._estado)
                .HasConversion(new EnumToStringConverter<EstadoEnvio>())
                .HasMaxLength(20)
                .IsUnicode();

            modelBuilder.Entity<Usuario>()
                .Property(a => a._rol)
                .HasConversion(new EnumToStringConverter<RolUsuario>())
                .HasMaxLength(20)
                .IsUnicode();

        }
    }
}
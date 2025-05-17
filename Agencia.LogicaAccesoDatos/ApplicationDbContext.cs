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
                .HasOne(v => v.Empleado)
                .WithMany()
                .HasForeignKey(v => v.EmpleadoId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Envio>()
                .HasOne(v => v.Cliente)
                .WithMany()
                .HasForeignKey(v => v.ClienteId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Envio>()
                .HasOne(v => v.AgenciaOrigen)
                .WithMany()
                .HasForeignKey(v => v.AgenciaOrigenId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<EnvioComun>()
                .HasOne(v => v.AgenciaDestino)
                .WithMany()
                .HasForeignKey(v => v.AgenciaDestinoId)
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
                .Property(a => a.Estado)
                .HasConversion(new EnumToStringConverter<EstadoEnvio>())
                .HasMaxLength(20)
                .IsUnicode();

            modelBuilder.Entity<Usuario>()
                .Property(a => a.Rol)
                .HasConversion(new EnumToStringConverter<RolUsuario>())
                .HasMaxLength(20)
                .IsUnicode();

            modelBuilder.Entity<Usuario>()
                .Property(u => u.Activo)
                .HasConversion(v => v.ToString(),
                                v => bool.Parse(v))
                .HasMaxLength(5)
                .IsUnicode(false);

            modelBuilder.Entity<EnvioUrgente>()
                .Property(e => e.EntregaEficiente)
                .HasConversion(v => v.HasValue ? v.Value.ToString() : null,
                                v => v != null ? bool.Parse(v) : (bool?)null)
                .HasMaxLength(5)
                .IsUnicode(false);
        }
    }
}
﻿using Agencia.LogicaNegocio.Entidades;
using Microsoft.EntityFrameworkCore;
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

        // public DbSet<Agencia> Agencias { get; set; }
        public DbSet<Auditoria> Auditorias { get; set; }
        public DbSet<Comentario> Comentarios { get; set; }
        public DbSet<Envio> Envios { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
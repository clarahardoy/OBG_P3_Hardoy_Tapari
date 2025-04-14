﻿// <auto-generated />
using System;
using System.Collections.Generic;
using Agencia.LogicaAccesoDatos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Agencia.LogicaAccesoDatos.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.15")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Agencia.LogicaNegocio.Entidades.Auditoria", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("Accion")
                        .HasColumnType("int");

                    b.Property<string>("Entidad")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EntidadId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("datetime2");

                    b.Property<string>("Observaciones")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Resultado")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("UsuarioId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Auditorias");
                });

            modelBuilder.Entity("Agencia.LogicaNegocio.Entidades.Comentario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("EnvioId")
                        .HasColumnType("int");

                    b.Property<string>("_descripcion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("_empleadoAutorId")
                        .HasColumnType("int");

                    b.Property<DateTime>("_fecha")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("EnvioId");

                    b.HasIndex("_empleadoAutorId");

                    b.ToTable("Comentarios");
                });

            modelBuilder.Entity("Agencia.LogicaNegocio.Entidades.Envio", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("ClienteId")
                        .HasColumnType("int");

                    b.Property<int>("EmpleadoId")
                        .HasColumnType("int");

                    b.Property<int>("_estado")
                        .HasColumnType("int");

                    b.Property<int>("_nroTracking")
                        .HasColumnType("int");

                    b.Property<double>("_peso")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("ClienteId");

                    b.HasIndex("EmpleadoId");

                    b.ToTable("Envios");
                });

            modelBuilder.Entity("Agencia.LogicaNegocio.Entidades.Usuario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("_email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("_password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("_rol")
                        .HasColumnType("int");

                    b.ComplexProperty<Dictionary<string, object>>("_nombreCompleto", "Agencia.LogicaNegocio.Entidades.Usuario._nombreCompleto#NombreCompleto", b1 =>
                        {
                            b1.IsRequired();

                            b1.Property<string>("_apellido")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("_nombre")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");
                        });

                    b.HasKey("Id");

                    b.ToTable("Usuarios");
                });

            modelBuilder.Entity("Agencia.LogicaNegocio.Entidades.Comentario", b =>
                {
                    b.HasOne("Agencia.LogicaNegocio.Entidades.Envio", null)
                        .WithMany("_seguimiento")
                        .HasForeignKey("EnvioId");

                    b.HasOne("Agencia.LogicaNegocio.Entidades.Usuario", "_empleadoAutor")
                        .WithMany()
                        .HasForeignKey("_empleadoAutorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("_empleadoAutor");
                });

            modelBuilder.Entity("Agencia.LogicaNegocio.Entidades.Envio", b =>
                {
                    b.HasOne("Agencia.LogicaNegocio.Entidades.Usuario", "_cliente")
                        .WithMany()
                        .HasForeignKey("ClienteId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Agencia.LogicaNegocio.Entidades.Usuario", "_empleado")
                        .WithMany()
                        .HasForeignKey("EmpleadoId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("_cliente");

                    b.Navigation("_empleado");
                });

            modelBuilder.Entity("Agencia.LogicaNegocio.Entidades.Envio", b =>
                {
                    b.Navigation("_seguimiento");
                });
#pragma warning restore 612, 618
        }
    }
}

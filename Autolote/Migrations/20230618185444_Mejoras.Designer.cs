﻿// <auto-generated />
using System;
using Autolote.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Autolote.Migrations
{
    [DbContext(typeof(AutoloteContext))]
    [Migration("20230618185444_Mejoras")]
    partial class Mejoras
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Autolote.Models.Cliente", b =>
                {
                    b.Property<string>("CedulaId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Direccion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NombreCliente")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NumeroTelfono")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CedulaId");

                    b.ToTable("Clientes");
                });

            modelBuilder.Entity("Autolote.Models.RegistroVenta", b =>
                {
                    b.Property<int>("RegistroId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("RegistroId"));

                    b.Property<int>("AñosDelContrato")
                        .HasColumnType("int");

                    b.Property<string>("Capitalizacion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CedulaId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ClienteNombre")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal?>("Cuota")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal?>("Monto")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("TasaInteres")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("VehiculoId")
                        .HasColumnType("int");

                    b.HasKey("RegistroId");

                    b.HasIndex("CedulaId");

                    b.HasIndex("VehiculoId");

                    b.ToTable("RegistrosVentas");
                });

            modelBuilder.Entity("Autolote.Models.Vehiculo", b =>
                {
                    b.Property<int>("VehiculoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("VehiculoId"));

                    b.Property<int>("AñoFab")
                        .HasColumnType("int");

                    b.Property<string>("Chasis")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Color")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Estado")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Marca")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Precio")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("VehiculoId");

                    b.ToTable("Vehiculos");
                });

            modelBuilder.Entity("Autolote.Models.RegistroVenta", b =>
                {
                    b.HasOne("Autolote.Models.Cliente", "Cliente")
                        .WithMany()
                        .HasForeignKey("CedulaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Autolote.Models.Vehiculo", "Carro")
                        .WithMany()
                        .HasForeignKey("VehiculoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Carro");

                    b.Navigation("Cliente");
                });
#pragma warning restore 612, 618
        }
    }
}

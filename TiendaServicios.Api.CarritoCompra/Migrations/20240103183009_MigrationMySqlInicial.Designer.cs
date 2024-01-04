﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TiendaServicios.Api.CarritoCompra.Persistencia;

#nullable disable

namespace TiendaServicios.Api.CarritoCompra.Migrations
{
    [DbContext(typeof(ContextCarrito))]
    [Migration("20240103183009_MigrationMySqlInicial")]
    partial class MigrationMySqlInicial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.25")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("TiendaServicios.Api.CarritoCompra.Modelo.CarritoSesion", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime?>("FechaCreacion")
                        .HasColumnType("datetime(6)");

                    b.HasKey("Id");

                    b.ToTable("CarritoSesion");
                });

            modelBuilder.Entity("TiendaServicios.Api.CarritoCompra.Modelo.CarritoSesionDetalle", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime?>("FechaCreacion")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("IdCarritoSesion")
                        .HasColumnType("int");

                    b.Property<string>("Producto")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("IdCarritoSesion");

                    b.ToTable("CarritoSesionDetalle");
                });

            modelBuilder.Entity("TiendaServicios.Api.CarritoCompra.Modelo.CarritoSesionDetalle", b =>
                {
                    b.HasOne("TiendaServicios.Api.CarritoCompra.Modelo.CarritoSesion", "CarritoSesion")
                        .WithMany("ListaDetalle")
                        .HasForeignKey("IdCarritoSesion")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CarritoSesion");
                });

            modelBuilder.Entity("TiendaServicios.Api.CarritoCompra.Modelo.CarritoSesion", b =>
                {
                    b.Navigation("ListaDetalle");
                });
#pragma warning restore 612, 618
        }
    }
}
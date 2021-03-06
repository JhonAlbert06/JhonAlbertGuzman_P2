// <auto-generated />
using System;
using JhonAlbertGuzman_P2.DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace JhonAlbertGuzman_P2.Migrations
{
    [DbContext(typeof(Contexto))]
    partial class ContextoModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.3");

            modelBuilder.Entity("JhonAlbertGuzman_P2.Entidades.Productos", b =>
                {
                    b.Property<int>("ProductoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<double>("Costo")
                        .HasColumnType("REAL");

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<double>("Existencia")
                        .HasColumnType("REAL");

                    b.Property<DateTime?>("Fecha")
                        .HasColumnType("TEXT");

                    b.Property<double>("Ganancia")
                        .HasColumnType("REAL");

                    b.Property<double>("Peso")
                        .HasColumnType("REAL");

                    b.Property<double>("Precio")
                        .HasColumnType("REAL");

                    b.Property<double>("ValorInventario")
                        .HasColumnType("REAL");

                    b.HasKey("ProductoId");

                    b.ToTable("Productos");
                });

            modelBuilder.Entity("JhonAlbertGuzman_P2.Entidades.ProductosDetalle", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<double>("Cantidad")
                        .HasColumnType("REAL");

                    b.Property<double>("Costo")
                        .HasColumnType("REAL");

                    b.Property<DateTime?>("Fecha")
                        .HasColumnType("TEXT");

                    b.Property<double>("Ganancia")
                        .HasColumnType("REAL");

                    b.Property<double>("Precio")
                        .HasColumnType("REAL");

                    b.Property<string>("Presentacion")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("ProductoId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("ProductoId");

                    b.ToTable("ProductosDetalle");
                });

            modelBuilder.Entity("JhonAlbertGuzman_P2.Entidades.ProductosEmpaque", b =>
                {
                    b.Property<int>("EmpaqueId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("Cantidad")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Concepto")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("Fecha")
                        .HasColumnType("TEXT");

                    b.HasKey("EmpaqueId");

                    b.ToTable("ProductosEmpaque");
                });

            modelBuilder.Entity("JhonAlbertGuzman_P2.Entidades.Utilizados", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("Cantidad")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int?>("EmpaqueId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("ProductoId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("UtilizadoId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("EmpaqueId");

                    b.HasIndex("ProductoId");

                    b.ToTable("Utilizados");
                });

            modelBuilder.Entity("JhonAlbertGuzman_P2.Entidades.ProductosDetalle", b =>
                {
                    b.HasOne("JhonAlbertGuzman_P2.Entidades.Productos", null)
                        .WithMany("Detalle")
                        .HasForeignKey("ProductoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("JhonAlbertGuzman_P2.Entidades.Utilizados", b =>
                {
                    b.HasOne("JhonAlbertGuzman_P2.Entidades.ProductosEmpaque", null)
                        .WithMany("Utilizados")
                        .HasForeignKey("EmpaqueId");

                    b.HasOne("JhonAlbertGuzman_P2.Entidades.Productos", "producto")
                        .WithMany()
                        .HasForeignKey("ProductoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("producto");
                });

            modelBuilder.Entity("JhonAlbertGuzman_P2.Entidades.Productos", b =>
                {
                    b.Navigation("Detalle");
                });

            modelBuilder.Entity("JhonAlbertGuzman_P2.Entidades.ProductosEmpaque", b =>
                {
                    b.Navigation("Utilizados");
                });
#pragma warning restore 612, 618
        }
    }
}

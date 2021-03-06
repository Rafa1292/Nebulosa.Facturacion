// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Nebulosa.Facturacion.Repositorio;

#nullable disable

namespace Nebulosa.Facturacion.Repositorio.Migrations
{
    [DbContext(typeof(Contexto))]
    partial class ContextoModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Nebulosa.Facturacion.AccesoADatos.CategoriasDeProducto.CategoriaDeProducto", b =>
                {
                    b.Property<int>("CategoriaDeProductoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CategoriaDeProductoId"), 1L, 1);

                    b.Property<bool>("Borrado")
                        .HasColumnType("bit");

                    b.Property<DateTime>("FechaDeActualizacion")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("FechaDeCreacion")
                        .HasColumnType("datetime2");

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UsuarioQueActualiza")
                        .HasColumnType("int");

                    b.Property<int>("UsuarioQueCrea")
                        .HasColumnType("int");

                    b.HasKey("CategoriaDeProductoId");

                    b.ToTable("CategoriasDeProducto");
                });

            modelBuilder.Entity("Nebulosa.Facturacion.AccesoADatos.Usuarios.Usuario", b =>
                {
                    b.Property<int>("UsuarioId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UsuarioId"), 1L, 1);

                    b.Property<string>("Contraseña")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Correo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FacebookId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("FechaDeActualizacion")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("FechaDeCreacion")
                        .HasColumnType("datetime2");

                    b.Property<string>("GoogleId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UsuarioId");

                    b.ToTable("Usuarios");
                });
#pragma warning restore 612, 618
        }
    }
}

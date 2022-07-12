using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Nebulosa.Facturacion.AccesoADatos.CategoriasDeProducto;
using Nebulosa.Facturacion.AccesoADatos.Usuarios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nebulosa.Facturacion.Repositorio
{
    public class Contexto : DbContext
    {
        public Contexto()
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=nebulosadb;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");

        }

        public DbSet<CategoriaDeProducto> CategoriasDeProducto { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            foreach (var relationship in builder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }

            builder.Entity<CategoriaDeProducto>()
                .HasIndex(c => c.Nombre)
                .IsUnique(true);

            builder.Entity<Usuario>()
                .HasIndex(c => c.Correo)
                .IsUnique(true);
        }
    }
}

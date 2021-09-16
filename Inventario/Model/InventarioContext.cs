using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Inventario.Model
{
    public class InventarioContext : DbContext
    {
        public DbSet<Producto> producto { get; set; }
        public DbSet<Marca> marca { get; set; }
        public DbSet<Presentacion> presentacion { get; set; }
        public DbSet<Proveedor> proveedor { get; set; }
        public DbSet<Zona> zona { get; set; }


        public InventarioContext(DbContextOptions<InventarioContext> options)
           : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Producto>().ToTable("producto");
            modelBuilder.Entity<Marca>().ToTable("marca");
            modelBuilder.Entity<Presentacion>().ToTable("presentacion");
            modelBuilder.Entity<Proveedor>().ToTable("proveedor");
            modelBuilder.Entity<Zona>().ToTable("zona");

        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Tienda.Domain.Entities;

namespace Tienda.Infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Producto> Products => Set<Producto>();

        public AppDbContext(DbContextOptions<AppDbContext> opts) : base(opts) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Producto>(eb =>
            {
                eb.HasKey(p => p.Id);
                eb.Property(p => p.Nombre).IsRequired().HasMaxLength(100);
                eb.Property(p => p.Descripcion).HasMaxLength(500);
                eb.Property(p => p.Precio).IsRequired().HasColumnType("decimal(18,2)");
                eb.Property(p => p.Imagen).HasMaxLength(200);
            });
        }
    }
}

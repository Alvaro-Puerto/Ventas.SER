using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;
using Ventas.SER.Models;

namespace Ventas.SER.Context
{
    public class VentaContexto : DbContext
    {
        public virtual DbSet<Cliente> Clientes { get; set; }

        public virtual DbSet<TasaCambio> TasaCambios { get; set; }

        public virtual DbSet<Producto> Productos { get; set; }
        
        public virtual DbSet<Factura> Factura { get; set; } 

        public  DbSet<FacturaDetalle> FacturaDetalle { get; set; }

        public VentaContexto(DbContextOptions<VentaContexto> opcional) : base(opcional)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder
           .Entity<Cliente>()
           .HasMany(e => e.Facturas)
           .WithOne(e => e.Cliente)
           .OnDelete(DeleteBehavior.ClientCascade);

            modelBuilder
             .Entity<Factura>()
             .HasMany(e => e.FacturaDetalles)
             .WithOne(f => f.Factura)
             .OnDelete(DeleteBehavior.ClientCascade);

            modelBuilder
            .Entity<FacturaDetalle>()
            .HasOne(f => f.Factura)
            .WithMany(e => e.FacturaDetalles)
            .OnDelete(DeleteBehavior.ClientNoAction);
            

        }
    }
}

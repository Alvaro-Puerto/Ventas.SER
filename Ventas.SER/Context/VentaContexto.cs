using Microsoft.EntityFrameworkCore;
using Ventas.SER.Models;

namespace Ventas.SER.Context
{
    public class VentaContexto : DbContext
    {
        public virtual DbSet<Cliente> Clientes { get; set; }

        public virtual DbSet<TasaCambio> TasaCambios { get; set; }


        public VentaContexto(DbContextOptions<VentaContexto> opcional) : base(opcional)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}

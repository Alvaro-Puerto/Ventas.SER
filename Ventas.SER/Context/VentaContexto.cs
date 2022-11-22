using Microsoft.EntityFrameworkCore;

namespace Ventas.SER.Context
{
    public class VentaContexto : DbContext
    {
        public VentaContexto(DbContextOptions<VentaContexto> opcional) : base(opcional)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}

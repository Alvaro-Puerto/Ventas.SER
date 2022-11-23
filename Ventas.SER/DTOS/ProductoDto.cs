using System.ComponentModel.DataAnnotations;

namespace Ventas.SER.DTOS
{
    public class ProductoDto
    {
      
        public int ProductoId { get; set; }
        public string SKU { get; set; }
        public string Descripcion { get; set; }
        public float Precio { get; set; }
        public float PrecioDol { get; set; }
        public float TasaCambio { get; set; }

        public void CalcularPrecioDolar(float Ts)
        {
            TasaCambio = Ts;
            PrecioDol = Precio / TasaCambio;

        }
        
    }
}

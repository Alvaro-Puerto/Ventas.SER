using System.ComponentModel.DataAnnotations;
using Ventas.SER.Context;

namespace Ventas.SER.Models
{
    public class FacturaDetalle
    {
        [Key]
        public int FacturaDetalleId { get; set; }

        public int ProductoId { get; set; }

        public Producto Producto { get; set; }

        [Required(ErrorMessage = "La cantidad es requeridad")]
        public int Cantidad { get; set; }

        public float Precio { get; set; }

        public float IVA { get; set; }

        public float Subtotal { get; set; }

        public int FacturaId { get; set; }

        public Factura Factura { get; set; }

        public void RecalcularCosto(Producto producto)
        {
            
                Precio = producto.Precio;
                IVA = (float)((Precio * Cantidad) * 0.15);
                Subtotal = (Precio * Cantidad) + IVA;
            
        }


    }
}

using System.ComponentModel.DataAnnotations;
using Ventas.SER.Models;

namespace Ventas.SER.DTOS
{
    public class FacturaDetalleDto
    {
        [Key]
        public int FacturaDetalleId { get; set; }

        public string SKU { get; set; }

        public string Producto { get; set; }

        public int Cantidad { get; set; }

        public float Precio { get; set; }

        public float IVA { get; set; }

        public float Subtotal { get; set; }

        public float SubtotalDol { get; set; }

        public float TasaCambio { get; set; }


    }
}

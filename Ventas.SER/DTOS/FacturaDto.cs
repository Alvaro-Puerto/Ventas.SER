using System.ComponentModel.DataAnnotations;
using Ventas.SER.Context;
using Ventas.SER.Models;

namespace Ventas.SER.DTOS
{
    public class FacturaDto
    {
        public int FacturaId { get; set; }

        public DateTime Fecha { get; set; }

        public string NombreCompleto { get; set; }

        public string Identificacion { get; set; }

        public float TotalLoc { get; set; }
        
        public float TotalDol { get; set; }

      

        public ICollection<FacturaDetalleDto> FacturaDetalles { get; set; }

        public  List<FacturaDetalleDto> ObtenerDetalle(VentaContexto db, int IdFactura)
        {
            VentaContexto _db = db;
            var lineas = new List<FacturaDetalleDto>();

            lineas = (from p in _db.FacturaDetalle
                     join e in _db.Productos
                     on p.ProductoId equals e.ProductoId
                     join ts in _db.TasaCambios 
                     on DateTime.Now.Date equals ts.Fecha.Date
                     where p.FacturaId== IdFactura
                     select new FacturaDetalleDto
                     {
                         SKU = e.SKU,
                         Producto = e.Descripcion,
                         Cantidad = p.Cantidad,
                         Precio = p.Precio,
                         IVA = p.IVA,
                         Subtotal = p.Subtotal,
                         SubtotalDol = p.Subtotal / ts.Monto,
                         TasaCambio = ts.Monto

                     }).ToList();

            return lineas;

        }
    }
}

using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata;
using Ventas.SER.Context;
using Ventas.SER.DTOS;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Ventas.SER.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReporteController : ControllerBase
    {

        private readonly VentaContexto _db;

        public ReporteController(VentaContexto db)
        {
            _db = db;
        }

        [HttpPost("{id}")]
        public async Task<IActionResult> Get(int id,ReporteDto filtro)
        {
           
             var reporte = (from p in _db.Factura
             join e in _db.Clientes
             on p.ClienteId equals e.ClienteId
             join dl in _db.FacturaDetalle
             on p.FacturaId equals dl.FacturaId
             join pr in _db.Productos
             on dl.ProductoId equals pr.ProductoId
             join ts in _db.TasaCambios
             on p.Fecha.Date equals ts.Fecha.Date
             where p.Fecha.Month == id
                select new ReporteDto
                {
                    NombresCompletos = e.NombresCompletos(),
                    Identificacion = e.Identificacion,
                    Producto = pr.Descripcion,
                    SKU = pr.SKU,
                    CostoLoc = dl.Subtotal,
                    CostoDol = dl.Subtotal / ts.Monto,
                    Mes = p.Fecha.Month,
                    Anyo = p.Fecha.Year
                }
             
             ).ToList();


          
            if (!String.IsNullOrEmpty(filtro.NombresCompletos))
            {
                reporte = reporte.Where(rpt => rpt.NombresCompletos.Contains(filtro.NombresCompletos)).ToList();
            }

            if (!String.IsNullOrEmpty(filtro.Identificacion))
            {
                reporte = reporte.Where(rpt => rpt.NombresCompletos.Contains(filtro.Identificacion)).ToList();
            }

            if (!String.IsNullOrEmpty(filtro.SKU))
            {
                reporte = reporte.Where(rpt => rpt.SKU.Contains(filtro.SKU)).ToList();
            }

            if (!String.IsNullOrEmpty(filtro.Producto))
            {
                reporte = reporte.Where(rpt => rpt.Producto.Contains(filtro.Producto)).ToList();
            }

            if (filtro.Mes != 0)
            {
                reporte = reporte.Where(rpt => rpt.Mes.Equals(filtro.Mes)).ToList();
            }

            if (filtro.Anyo != 0)
            {
                reporte = reporte.Where(rpt => rpt.Equals(filtro.Anyo)).ToList();
            }

            return Ok(reporte);
        }

       
    }
}

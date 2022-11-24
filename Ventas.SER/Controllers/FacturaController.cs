using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Ventas.SER.Context;
using Ventas.SER.DTOS;
using Ventas.SER.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Ventas.SER.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FacturaController : ControllerBase
    {

        private readonly VentaContexto _db;
        private readonly IMapper _mapper;

        public FacturaController(VentaContexto db, IMapper mapper) 
        {
            _db = db;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
             var facturaDto = new List<FacturaDto>();
             facturaDto = (from p in _db.Factura
                          join e in _db.Clientes
                          on p.ClienteId equals e.ClienteId
                          select new FacturaDto
                          {
                              FacturaId = p.FacturaId,
                              NombreCompleto = e.NombresCompletos(),
                              Fecha = p.Fecha.Date,
                              Identificacion = e.Identificacion,
                             
                          }).ToList();

            facturaDto.ForEach(item => {
                    item.FacturaDetalles = item.ObtenerDetalle(_db, item.FacturaId);
                    item.TotalLoc = item.FacturaDetalles.Sum(fd => fd.Subtotal);
                    item.TotalDol = item.FacturaDetalles.Sum(fd => fd.SubtotalDol);
            });

            return Ok(facturaDto);
        }

       
        [HttpGet("{parametro}")]
        public async Task<IActionResult> Get(string parametro)
        {
            var facturaDto = new List<FacturaDto>();
            facturaDto = (from p in _db.Factura
                          join e in _db.Clientes
                          on p.ClienteId equals e.ClienteId
                          where e.Nombres.Contains(parametro)
                           || p.FacturaId.ToString() == parametro

                          select new FacturaDto
                          {
                              FacturaId = p.FacturaId,
                              NombreCompleto = e.NombresCompletos(),
                              Fecha = p.Fecha.Date,
                              Identificacion = e.Identificacion,

                          }).ToList();

            facturaDto.ForEach(item => {
                item.FacturaDetalles = item.ObtenerDetalle(_db, item.FacturaId);
                item.TotalLoc = item.FacturaDetalles.Sum(fd => fd.Subtotal);
                item.TotalDol = item.FacturaDetalles.Sum(fd => fd.SubtotalDol);
            });

            return Ok(facturaDto);
        }

       
        [HttpPost]
        public async Task<IActionResult> Post(FacturaInsertarDto FacturaDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.SelectMany(err => err.Value.Errors));
            }

            var cliente = await _db.Clientes.FindAsync(FacturaDto.ClienteId);

            if (cliente == null)
            {
                return NotFound("No existe el cliente");
            }
            

            var factura = new Factura();

            var detalles = _mapper.Map<List<FacturaDetalle>>(FacturaDto.FacturaDetalles);
            
            detalles.ForEach( dt => dt.RecalcularCosto( _db.Productos.Find(dt.ProductoId)));

            factura.Fecha = FacturaDto.Fecha;
            factura.Cliente = cliente;
            factura.FacturaDetalles = detalles;
            await _db.Factura.AddAsync(factura);

             _db.SaveChanges();

            return Ok(factura);
        }

    }
}

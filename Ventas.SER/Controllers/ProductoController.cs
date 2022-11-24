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
    public class ProductoController : ControllerBase
    {

        private readonly VentaContexto _db;
        private readonly IMapper _mapper;

        public  ProductoController(VentaContexto db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var tasaCambio = await _db.TasaCambios
                                     .Where(ts => ts.Fecha.Date == DateTime.Now.Date)
                                     .FirstOrDefaultAsync();

            if (tasaCambio == null)
           {
                return BadRequest("No existe tasa de cambio registrada ha esta fecha");
           }

            var productos = await _db.Productos.ToListAsync();
            var productosDtos = _mapper.Map<List<ProductoDto>>(productos);

            productosDtos.ForEach(x => x.CalcularPrecioDolar(tasaCambio.Monto));
           
            return Ok(productosDtos);
        }

       
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {

            var tasaCambio = await _db.TasaCambios
                                    .Where(ts => ts.Fecha.Date == DateTime.Now.Date)
                                    .FirstOrDefaultAsync();
            if (tasaCambio == null)
            {
                return BadRequest("No existe tasa de cambio registrada ha esta fecha");
            }

           

            var producto = new Producto();

            producto = await _db.Productos.Where(p => p.ProductoId == id).FirstOrDefaultAsync();
            var productoDto = _mapper.Map<ProductoDto>(producto);
            productoDto.CalcularPrecioDolar(tasaCambio.Monto);
            
            return Ok(productoDto);
        }

       
        [HttpPost]
        public async Task<IActionResult> Post(Producto producto)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.SelectMany(err => err.Value.Errors));
            }

            var result = await _db.Productos.AddAsync(producto);
            _ = _db.SaveChangesAsync();

            return Ok(result);
        }

      
        [HttpPut()]
        public async Task<IActionResult> Put(Producto ProductoObj)
        {
            
            var producto = new Producto();

            producto = await _db.Productos.Where(p => p.ProductoId == ProductoObj.ProductoId)
                                          .AsNoTracking().FirstOrDefaultAsync();

            if (producto == null)
            {
                return BadRequest("No existe un registro con ese id");
            }

            producto = _mapper.Map<Producto>(ProductoObj);

            _db.Productos.Update(producto);
            _db.SaveChangesAsync();

            return Ok();
        }

      
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var producto = new Producto();

            producto = await _db.Productos.FindAsync(id);

            _db.Remove(producto);
            _db.SaveChangesAsync();

            return Ok();
        }

        [Route("~/api/Producto/Buscar/{parametro}")]
        [HttpGet]
        public async Task<IActionResult> Buscar(string parametro)
        {
            var tasaCambio = await _db.TasaCambios
                                    .Where(ts => ts.Fecha.Date == DateTime.Now.Date)
                                    .FirstOrDefaultAsync();

            if (tasaCambio == null)
            {
                return BadRequest("No existe tasa de cambio a la fecha");
            }

            List<Producto> productos= new List<Producto>();
            productos = await _db.Productos
                                 .Where(x => x.SKU.Contains(parametro) || x.Descripcion.Contains(parametro))
                                 .ToListAsync();

            var productosDtos = _mapper.Map<List<ProductoDto>>(productos);

            productosDtos.ForEach(x => x.CalcularPrecioDolar(tasaCambio.Monto));

            return Ok(productosDtos);
        }

       
    }
}

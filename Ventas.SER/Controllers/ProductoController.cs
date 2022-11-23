using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Ventas.SER.Context;
using Ventas.SER.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Ventas.SER.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoController : ControllerBase
    {

        private readonly VentaContexto _db;

        public  ProductoController(VentaContexto db)
        {
            _db = db;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            
            var productos = await _db.Productos.ToListAsync();

            return Ok(productos);
        }

       
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            Producto producto = new Producto();

            producto = await _db.Productos.FindAsync(id); 

            return Ok(producto);
        }

       
        [HttpPost]
        public async Task<IActionResult> Post(Producto producto)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.SelectMany(err => err.Value.Errors));
            }

            var result = await _db.Productos.AddAsync(producto);
            _db.SaveChangesAsync();

            return Ok(result);
        }

      
        [HttpPut("{id}")]
        public void Put(int id, Producto productoObj)
        {
            Producto producto = new Producto();

            producto = _db.Productos.Find(id);

            producto.Precio = productoObj.Precio;
            producto.Descripcion = productoObj.Descripcion;
            
            _db.Productos.Update(producto);
            _db.SaveChangesAsync();
        }

      
        [HttpDelete("{id}")]
        public async void Delete(int id)
        {
            Producto producto = new Producto();

            producto = await _db.Productos.FindAsync(id);

            _db.Remove(producto);
            _db.SaveChangesAsync();
        }
    }
}

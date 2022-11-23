using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Ventas.SER.Context;
using Ventas.SER.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Ventas.SER.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TasaCambioController : ControllerBase
    {

        private readonly VentaContexto _db;

        public TasaCambioController(VentaContexto db) { 
            _db = db;
        }

        [HttpGet]
        public async Task<IEnumerable<TasaCambio>> Get()
        {
            List<TasaCambio> tasaCambios = new List<TasaCambio>();

            tasaCambios = await _db.TasaCambios.ToListAsync();

            return tasaCambios;
        }

       
        [HttpGet("{fecha}")]
        public async Task<TasaCambio> Get(DateTime fecha)
        {
            TasaCambio tasaCambio = new TasaCambio();

            tasaCambio = await _db.TasaCambios.Where(x => x.Fecha == fecha).FirstOrDefaultAsync();
            
            return tasaCambio;
        }


        [HttpPost]
        public async Task<IActionResult> Post(TasaCambio tasaCambio)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState.SelectMany(err => err.Value.Errors));
            }

            _db.TasaCambios.AddAsync(tasaCambio);
            _db.SaveChangesAsync();

            return Ok();
        }

       
        [HttpPut("{id}")]
        public async void Put(int id, TasaCambio tasaCambio)
        {
            TasaCambio tasaCambioR = new TasaCambio();

            tasaCambioR = await _db.TasaCambios.FindAsync(id);

            if(tasaCambioR == null)
            {
                
            }

            tasaCambioR.Fecha = tasaCambio.Fecha;
            tasaCambioR.Monto = tasaCambio.Monto;

            var result =  _db.TasaCambios.Update(tasaCambioR);
            _db.SaveChangesAsync();
        }
        
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            TasaCambio tasaCambio = new TasaCambio();

            tasaCambio = await _db.TasaCambios.FindAsync(id);

            _db.TasaCambios.Remove(tasaCambio);
            _db.SaveChangesAsync();

            return Ok();

        }

        [Route("~/api/TasaCambio/Mes/{month}")]
        [HttpGet()]
        public async Task<IEnumerable<TasaCambio>> Month(int month)
        {
            List<TasaCambio> tasaCambios = new List<TasaCambio>();  
            tasaCambios = await _db.TasaCambios.Where(ts => ts.Fecha.Month == month).ToListAsync();

            return tasaCambios;
        }

       
    }
}

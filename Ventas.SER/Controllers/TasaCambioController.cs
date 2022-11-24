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
    public class TasaCambioController : ControllerBase
    {

        private readonly VentaContexto _db;
        private readonly IMapper _mapper;

        public TasaCambioController(VentaContexto db, IMapper mapper) { 
            _db = db;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var tasaCambios = new List<TasaCambio>();

            tasaCambios = await _db.TasaCambios.ToListAsync();
            var tasaCambioDtos = _mapper.Map<List<TasaCambioDto>>(tasaCambios);
            return Ok(tasaCambioDtos);
        }

       
        [HttpGet("{fecha}")]
        public async Task<IActionResult> Get(DateTime fecha)
        {
            var tasaCambio = new TasaCambio();

            tasaCambio = await _db.TasaCambios.Where(x => x.Fecha.Date == fecha.Date).FirstOrDefaultAsync();
            
            return Ok(tasaCambio);
        }


        [HttpPost]
        public async Task<IActionResult> Post(TasaCambio tasaCambio)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState.SelectMany(err => err.Value.Errors));
            }

            _ = await _db.TasaCambios.AddAsync(tasaCambio);
            _db.SaveChangesAsync();

            return Ok(tasaCambio);
        }

       
        [HttpPut]
        public async Task<IActionResult> Put(TasaCambio tasaCambio)
        {
            var tasaCambioR = new TasaCambio();

            tasaCambioR = await _db.TasaCambios.Where(ts => ts.TasaCambioId == tasaCambio.TasaCambioId)
                                               .AsNoTracking().FirstAsync();
            if(tasaCambioR == null)
            {
                return BadRequest("No existe ese registro con ese Id");
            }

            tasaCambioR = _mapper.Map<TasaCambio>(tasaCambio);

            var result =  _db.TasaCambios.Update(tasaCambioR);
            _db.SaveChangesAsync();

            return Ok(tasaCambioR);
        }
        
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var tasaCambio = new TasaCambio();

            tasaCambio = await _db.TasaCambios.FindAsync(id);

            var result = _db.TasaCambios.Remove(tasaCambio);
            _db.SaveChangesAsync();

            return Ok(tasaCambio);

        }

        [Route("~/api/TasaCambio/Mes/{month}")]
        [HttpGet()]
        public async Task<IActionResult> Month(int month)
        {
            var tasaCambios = new List<TasaCambio>();  
            tasaCambios = await _db.TasaCambios.Where(ts => ts.Fecha.Month == month).ToListAsync();

            return Ok(tasaCambios);
        }

       
    }
}

using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Ventas.SER.Context;
using Ventas.SER.DTOS;
using Ventas.SER.Models;


namespace Ventas.SER.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {

        private readonly VentaContexto _db;
        private readonly IMapper _mapper;
        
        public ClienteController(VentaContexto db, IMapper mapper) {
            _db = db;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var clientes = new List<Cliente>();

            clientes = await _db.Clientes.ToListAsync();

            return Ok(clientes);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var cliente = new Cliente();

            cliente = await _db.Clientes.FindAsync(id);

            return Ok(cliente);
        }

     
        [HttpPost]
        public async Task<IActionResult> Post(Cliente cliente)
        {
          
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.SelectMany(err => err.Value.Errors));
            } 

            try
            {
                var result = await _db.Clientes.AddAsync(cliente);
                _db.SaveChangesAsync();

                return Ok(cliente);
            } catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Cliente cliente)
        {
            var clienteA = new Cliente();

            clienteA = await _db.Clientes.Where(c => c.ClienteId == id).AsNoTracking().FirstOrDefaultAsync();

            if(clienteA == null)
            {
                return BadRequest();
            }

            clienteA = _mapper.Map<Cliente>(cliente);
            
            _db.Clientes.Update(clienteA);
            _db.SaveChangesAsync();

            return Ok(cliente);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var cliente = new Cliente();
            cliente = await _db.Clientes.Where(c => c.ClienteId == id).FirstOrDefaultAsync();
            _db.Clientes.Remove(cliente);
            _db.SaveChangesAsync();

            return Ok();

        }

        [HttpGet("~/api/Cliente/Buscar/{parametro}")]
        public async Task<IActionResult> Get(string parametro)
        {
            var clientes = new List<Cliente>();

            clientes = await _db.Clientes.Where(c => c.Nombres.Contains(parametro) ||
                                                     c.Identificacion.Contains(parametro))
                                                    .ToListAsync();

            return Ok(clientes);
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Ventas.SER.Context;
using Ventas.SER.Models;


namespace Ventas.SER.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {

        private readonly VentaContexto _db;

        public ClienteController(VentaContexto db) {
            _db = db;
        }

        [HttpGet]
        public async Task<IEnumerable<Cliente>> Get()
        {
            List<Cliente> clientes = new List<Cliente>();

            clientes = await _db.Clientes.ToListAsync();

            return clientes;
        }

        [HttpGet("{id}")]
        public async Task<Cliente> Get(int id)
        {
            Cliente cliente = new Cliente();

            cliente = await _db.Clientes.FindAsync(id);

            return cliente;
        }

     
        [HttpPost]
        public async Task<IActionResult> Post(Cliente cliente)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.SelectMany(err => err.Value.Errors));
            } 

            var result = _db.Clientes.AddAsync(cliente);
            _db.SaveChangesAsync();

            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Cliente cliente)
        {
            var clienteA = new Cliente();

            clienteA = await _db.Clientes.FindAsync(id);

            if(clienteA == null)
            {
                return BadRequest();
            }

            clienteA.Nombres = cliente.Nombres;
            clienteA.Apellidos = cliente.Apellidos;
            clienteA.Telefono = cliente.Telefono;
            clienteA.Identificacion = cliente.Identificacion;
            clienteA.Direccion = cliente.Direccion;
            
            _db.Clientes.Update(clienteA);
            _db.SaveChangesAsync();

            return Ok(clienteA);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            Cliente cliente = new Cliente();
            cliente = await _db.Clientes.FindAsync(id);
            _db.Clientes.Remove(cliente);
            _db.SaveChangesAsync();

            return Ok();

        }
    }
}

using Api_Rest_en_C_.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace Api_Rest_en_C_.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ClienteController : Controller
    {
       private readonly BdBusinessContext _context;
       public ClienteController(BdBusinessContext ctx)
        {
            _context = ctx;
        }
        [HttpGet("Listar Clientes")]
        public ActionResult<List<Cliente>> ListarClientes()
        {

            return _context.Clientes.ToList();
        }

        [HttpGet("BuscarCliente/{id}")]

        public ActionResult<Cliente> BuscarCliente(int id)
        {

            return _context.Clientes.FirstOrDefault(e => e.IdCliente == id);
        }

        [HttpPost("CrearCliente")]
        public IActionResult CrearCliente([FromBody] Cliente nuevoCliente)
        {
            if (nuevoCliente == null)
            {
                return BadRequest("Los datos del cliente son inválidos.");
            }

            _context.Clientes.Add(nuevoCliente); 
            _context.SaveChanges();

            return CreatedAtAction(nameof(ListarClientes), new { id = nuevoCliente.IdCliente }, nuevoCliente);
        }

        [HttpPut("ActualizarCliente/{id}")]
        public IActionResult ActualizarCliente(int id, [FromBody] Cliente clienteActualizado)
        {
            if (clienteActualizado == null || id != clienteActualizado.IdCliente)
            {
                return BadRequest("El ID del cliente no coincide o los datos son inválidos.");
            }

            var clienteExistente = _context.Clientes.Find(id);
            if (clienteExistente == null)
            {
                return NotFound($"No se encontró el cliente con ID {id}.");
            }

            clienteExistente.Nombre = clienteActualizado.Nombre;
 
            _context.SaveChanges();

            return NoContent();
        }
    }
}

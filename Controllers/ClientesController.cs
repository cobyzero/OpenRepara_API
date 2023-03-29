using Microsoft.AspNetCore.Mvc;
using OpenRepara_API.Models;
using System.Text;
using System.Text.Json;

namespace OpenRepara_API.Controllers
{
    [ApiController]
    [Route("api")]
    public class ClientesController : Controller
    {
        OpenReparaContext _context;

        public ClientesController(OpenReparaContext context)
        {
            _context = context;
        }


        [HttpGet("getClientes")]
        public List<Cliente> getClientes()
        {
            return _context.Clientes.ToList();
        }

        [HttpPut("putCliente")]
        public async Task putCliente()
        { 
            try
            {
                using (StreamReader stream = new StreamReader(Request.Body, Encoding.UTF8))
                {
                    Cliente? cliente = JsonSerializer.Deserialize<Cliente>(await stream.ReadToEndAsync());

                    _context.Clientes.Update(cliente!);

                    await _context.SaveChangesAsync();
                }
            }
            catch (Exception)
            {

                throw;
            }

        }

        [HttpGet("getClienteForCode")]
        public List<Cliente>getClienteForCode(string code)
        {

            try
            {
                return _context.Clientes.Where((t) => t.Code == code).ToList();
            }
            catch (Exception)
            {

                throw;
            }

        }

        [HttpDelete("deleteCliente")]
        public async Task deleteCliente()
        {

            try
            {
                using (var stream = new StreamReader(Request.Body, Encoding.UTF8))
                {
                    Cliente? cliente = JsonSerializer.Deserialize<Cliente>(await stream.ReadToEndAsync());

                    _context.Clientes.Remove(cliente!);

                    await _context.SaveChangesAsync();
                }
            }
            catch (Exception)
            {

                throw;
            }

        }
    }
}

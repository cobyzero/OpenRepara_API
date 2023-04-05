using Microsoft.AspNetCore.Mvc;
using OpenRepara_API.Models;
using System.Text;
using System.Text.Json;

namespace OpenRepara_API.Controllers
{
    [ApiController]
    [Route("api")]
    public class ClientController : Controller
    {
        OpenReparaContext _context;

        public ClientController(OpenReparaContext context)
        {
            _context = context;
        }


        [HttpGet("getClient")]
        public List<Client> getClientes()
        {
            return _context.Clients.ToList();
        }

        [HttpPut("putClient")]
        public async Task putCliente()
        { 
            try
            {
                using (StreamReader stream = new StreamReader(Request.Body, Encoding.UTF8))
                {
                    Client? cliente = JsonSerializer.Deserialize<Client>(await stream.ReadToEndAsync());

                    _context.Clients.Update(cliente!);

                    await _context.SaveChangesAsync();
                }
            }
            catch (Exception)
            {

                throw;
            }

        }

        [HttpGet("getClientForCode")]
        public List<Client> getClienteForCode(string code)
        {

            try
            {
                return _context.Clients.Where((t) => t.Code == code).ToList();
            }
            catch (Exception)
            {

                throw;
            }

        }

        [HttpDelete("deleteClient")]
        public async Task deleteCliente()
        {

            try
            {
                using (var stream = new StreamReader(Request.Body, Encoding.UTF8))
                {
                    Client? cliente = JsonSerializer.Deserialize<Client>(await stream.ReadToEndAsync());

                    _context.Clients.Remove(cliente!);

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

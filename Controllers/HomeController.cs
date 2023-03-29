using Microsoft.AspNetCore.Mvc;
using OpenRepara_API.Models;

namespace OpenRepara_API.Controllers
{
    [ApiController]
    [Route("api")]
    public class HomeController : Controller
    {
        OpenReparaContext _context;

        public HomeController(OpenReparaContext context)
        {
            _context = context;
        }

        [HttpGet("getData")]
        public List<double> getData() {

            List<double> data = new List<double>();

            try
            {
                data.Add(_context.Clientes.ToList().Count());
                data.Add(_context.Inventarios.ToList().Count());
                data.Add(_context.Ordenes.ToList().Count());

                double precio = 0;
                foreach (var item in _context.Ventas.ToList())
                {
                    precio += item.Price;
                }
                data.Add(precio);
                return data;
            }
            catch (Exception)
            { 
                return new List<double>();
            }
        
        }
    }
}

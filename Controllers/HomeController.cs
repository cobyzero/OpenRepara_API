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

        [HttpGet("getHome")]
        public List<double> getHome() {

            List<double> data = new List<double>();

            try
            {
                data.Add(_context.Clients.ToList().Count());
                data.Add(_context.Inventories.ToList().Count());
                data.Add(_context.Orders.ToList().Count());

                double price = 0;
                foreach (var item in _context.Sales.ToList())
                {
                    price += item.PriceService;
                }
                data.Add(price);
                return data;
            }
            catch (Exception)
            { 
                return new List<double>();
            }
        
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using OpenRepara_API.Models;

namespace OpenRepara_API.Controllers
{
    [ApiController]
    [Route("api")]
    public class SaleController : Controller
    {
         OpenReparaContext _context;

        public SaleController(OpenReparaContext context) {
            _context = context;
        }

        [HttpGet("getSale")]
        public List<Sale> getSale()
        {
            return _context.Sales.ToList();
        }
    }
}

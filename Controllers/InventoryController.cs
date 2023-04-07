using Microsoft.AspNetCore.Mvc;
using OpenRepara_API.Models;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

namespace OpenRepara_API.Controllers
{
    [ApiController]
    [Route("api")]
    public class InventoryController : Controller
    {
        OpenReparaContext _context;

        public InventoryController(OpenReparaContext context)
        {
            _context = context;
        }


        [HttpGet("getInventory")]
        public List<Inventory>GetInventarios()
        {
            return _context.Inventories.ToList();
        }

        [HttpGet("getInventoryForCode")]
        public List<Inventory> getInventoryForCode(string code)
        {
            List<Inventory> data = new List<Inventory>();
            try
            {
                data = _context.Inventories.Where((t) => t.Code == code).ToList();

                if (data.Count > 0) return data;

                data = _context.Inventories.Where((t) => t.Marca == code).ToList();

                if (data.Count > 0) return data;

                data = _context.Inventories.Where((t) => t.Model == code).ToList();

                if (data.Count > 0) return data;

                data = _context.Inventories.Where((t) => t.Imei == code).ToList();

                if (data.Count > 0) return data;

                data = _context.Inventories.Where((t) => t.Description == code).ToList();

                if (data.Count > 0) return data;

                data = _context.Inventories.Where((t) => t.TypeService == code).ToList();

                return data;
            }
            catch (Exception)
            { 
                throw;
            } 
        }

         
        [HttpDelete("deleteInventory")]
        public async Task deleteInventoryForCode()
        {
            try
            {
                using (var stream = new StreamReader(Request.Body, Encoding.UTF8))
                {
                    Inventory? inventory = JsonSerializer.Deserialize<Inventory>(await  stream.ReadToEndAsync());

                    _context.Inventories.Remove(inventory!);

                    await _context.SaveChangesAsync();
                } 
            }
            catch (Exception)
            {

                throw;
            }

        }

        [HttpPut("putInventory")]
        public async Task putInventory()
        {
            try
            {
                using (var stream = new StreamReader(Request.Body, Encoding.UTF8))
                {
                    Inventory? inventory = JsonSerializer.Deserialize<Inventory>(await stream.ReadToEndAsync());

                    _context.Inventories.Update(inventory!);

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

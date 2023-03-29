using Microsoft.AspNetCore.Mvc;
using OpenRepara_API.Models;
using System.Collections.Generic;

namespace OpenRepara_API.Controllers
{
    [ApiController]
    [Route("api")]
    public class InventarioController : Controller
    {
        OpenReparaContext _context;

        public InventarioController(OpenReparaContext context)
        {
            _context = context;
        }


        [HttpGet("getInventario")]
        public List<Inventario>GetInventarios()
        {
            return _context.Inventarios.ToList();
        }

        [HttpGet("getInventarioForCode")]
        public List<Inventario> getInventarioForCode(string code)
        {
            List<Inventario> data = new List<Inventario>();
            try
            {
                data = _context.Inventarios.Where((t) => t.Code == code).ToList();

                if(data.Count > 0)
                {
                    return data;
                }
                else
                {
                    data = _context.Inventarios.Where((t) => t.Marca == code).ToList();

                    if (data.Count > 0)
                    {
                        return data;
                    }
                    else
                    {
                        data = _context.Inventarios.Where((t) => t.Model == code).ToList();

                        if (data.Count > 0)
                        {
                            return data;
                        }
                        else
                        {
                            data = _context.Inventarios.Where((t) => t.Serial == code).ToList();

                            if (data.Count > 0)
                            {
                                return data;
                            }
                            else
                            {
                                data = _context.Inventarios.Where((t) => t.Imei == code).ToList();

                                if (data.Count > 0)
                                {
                                    return data;
                                }
                                else
                                {
                                    data = _context.Inventarios.Where((t) => t.Description == code).ToList();

                                    if (data.Count > 0)
                                    {
                                        return data;
                                    }
                                    else
                                    {
                                        data = _context.Inventarios.Where((t) => t.Type == code).ToList();

                                        return data;
                                    }
                                }
                            }
                        }
                    }
                }


            }
            catch (Exception)
            {

                throw;
            }


        }
    }
}

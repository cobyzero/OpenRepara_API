using Microsoft.AspNetCore.Mvc;
using OpenRepara_API.Models;
using System.Text;
using System.Text.Json;

namespace OpenRepara_API.Controllers
{
    [ApiController]
    [Route("api")]
    public class OrderController : Controller
    {
        OpenReparaContext _context;

        public OrderController(OpenReparaContext context) {
            _context = context;
        }

        [HttpGet("getOrder")]
        public List<Order> getOrder()
        {
            return _context.Orders.ToList();
        }

        [HttpGet("getOrderForCode")]
        public List<Order> getOrderForCode(string code)
        {
            try
            {
                return _context.Orders.Where((t) => t.Code == code).ToList();
            }
            catch (Exception)
            {

                return new List<Order>();
            }
        }

        [HttpPut("putOrderStatus")]
        public async Task putOrderStatus()
        {
            try
            {
                using (var stream = new StreamReader(Request.Body, Encoding.UTF8))
                {
                    Order? order = JsonSerializer.Deserialize<Order>(await stream.ReadToEndAsync());

                    order!.Status++;

                    _context.Update(order);

                    Inventory? inventory = _context.Inventories.Where((t)=>t.Code == order.Code).FirstOrDefault();
                    _context.Inventories.Remove(inventory!);

                    Sale sale = new Sale() { 
                        Code=order.Code,
                        ClientName = order.NameClient,
                        DateService = order.DateOrder,
                        TypeService = order.TypeService,
                        PriceService = order.Price,
                    };

                    _context.Sales.Add(sale);
                    await _context.SaveChangesAsync();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpDelete("deleteOrder")]
        public async Task deleteOrder()
        {
            try
            {
                using (var stream = new StreamReader(Request.Body, Encoding.UTF8))
                {
                    Order? ordene = JsonSerializer.Deserialize<Order>(await stream.ReadToEndAsync());
                     
                    _context.Remove(ordene!);

                    await _context.SaveChangesAsync();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }


        [HttpPost("addOrder")]
        public async Task addOrder()
        {
            try
            {
                using (var stream = new StreamReader(Request.Body, Encoding.UTF8))
                {
                    Order? ordene = JsonSerializer.Deserialize<Order>(await stream.ReadToEndAsync());

                    _context.Orders.Add(ordene!);
                    


                    if(_context.Clients.Where((t)=>t.Code == ordene!.Code).ToList().Count() == 0)
                    {
                        _context.Clients.Add(new Client(){
                            Code = ordene!.Code,
                            Name = ordene.NameClient,
                            Email = ordene.EmailClient,
                            Number = ordene.NumberClient,
                         });
                    }

                    _context.Inventories.Add(new Inventory()
                    {
                        Code = ordene!.Code,
                        Marca = ordene.MarcaDispositive,
                        Model = ordene.ModelDispositive,
                        Imei = ordene.ImeiDispositive,
                        Description = ordene.FailDispositive,
                        TypeService = ordene.Dispositive
                    });
                     
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

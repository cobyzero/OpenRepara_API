using Microsoft.AspNetCore.Mvc;
using OpenRepara_API.Models;

namespace OpenRepara_API.Controllers
{
    [ApiController]
    [Route("api")]
    public class LoginController : Controller
    {

        OpenReparaContext _context;

        public LoginController(OpenReparaContext context)
        {
            _context = context;
        }

        [HttpGet("checkLogin")]
        public User checkLogin(string username, string password)
        {
            try
            {
               User user =  _context.Users.Where((t) => (t.Username == username && t.Password == password) || (t.Email == username && t.Password == password)).First();
                return user;
            
            }
               
            catch (Exception)
            {
                return new User();
            }
        }
    }
}

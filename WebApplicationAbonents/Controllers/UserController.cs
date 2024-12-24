using Microsoft.AspNetCore.Mvc;
using WebApplicationAbonents.Models;

namespace WebApplicationAbonents.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        
        [HttpGet("auth/{email},{password}")]
        public ActionResult<User?> Auth(string email, string password)
        {
            User? user = Program.context.Users.Where(i => i.Email == email && i.Password == password).FirstOrDefault();
            return user == null ? NotFound("Пользователь не найден") : Ok(user);
        }

        [HttpPost("register")]
        public ActionResult<User?> Register([FromBody] User user)
        {
            Program.context.Users.Add(user);
            Program.context.SaveChanges();
            return Ok(user);
        }
    }
}

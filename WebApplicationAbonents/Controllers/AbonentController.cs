using Microsoft.AspNetCore.Mvc;
using WebApplicationAbonents.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApplicationAbonents.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AbonentController : ControllerBase
    {
        // GET: api/<AbonentController>
        [HttpGet]
        public ActionResult<List<Abonent>> GetAbonents()
        {
            return Ok(Program.context.Abonents.ToList());
        }

        [HttpGet("search/surname/{toSearch}")]
        public ActionResult<List<Abonent>> SearchSurnameAbonents(string toSearch)
        {
            return Ok(Program.context.Abonents.Where(i => i.Surname.Contains(toSearch)).ToList());
        }

        [HttpGet("search/phone/{toSearch}")]
        public ActionResult<List<Abonent>> SearchPhoneAbonents(string toSearch)
        {
            return Ok(Program.context.Abonents.Where(i => i.Phone.Contains(toSearch)).ToList());
        }

        [HttpPut("{id}")]
        public ActionResult<Abonent> UpdateAbonent(int id, [FromBody] Abonent abonentUpdated)
        {
            var abonent = Program.context.Abonents.Where(i => i.Id == id).FirstOrDefault();
            if (abonent != null)
            {
                abonent.Address = abonentUpdated.Address;
                abonent.Phone = abonentUpdated.Phone;
                abonent.Pochta = abonentUpdated.Pochta;
                abonent.Surname = abonentUpdated.Surname;
                abonent.Name = abonentUpdated.Name;
                abonent.Patronymic = abonentUpdated.Patronymic;

                Program.context.SaveChanges();
                return Ok(abonent);
            }
            else
            {
                return NotFound("Абонент не найден");
            }
        }

        // POST api/<AbonentController>
        [HttpPost]
        public ActionResult<Abonent> CreateAbonent([FromBody] Abonent abonent)
        {
            Program.context.Abonents.Add(abonent);
            Program.context.SaveChanges();
            return Ok(abonent);
        }



        // DELETE api/<AbonentController>/5
        [HttpDelete("{id}")]
        public ActionResult DeleteAbonent(int id)
        {
            var abonent = Program.context.Abonents.Where(i => i.Id == id).FirstOrDefault();
            if (abonent != null)
            {
                Program.context.Abonents.Remove(abonent);
                Program.context.SaveChanges();
                return Ok("Удалено успешно");
            }
            else
            {
                return NotFound("Абонент не найден");
            }
        }
    }
}

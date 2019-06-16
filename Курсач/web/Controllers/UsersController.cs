using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using TestApp;

namespace web.Controllers
{
    [Route("api/[controller]")]
    public class UsersController : Controller
    {
        UsersContext db;
        public UsersController(UsersContext context)
        {
            this.db = context;
            if (!db.Users.Any())
            {
                ///db.Users.Add(new Models.User { Email = "vlad", Name = "govno", Password = "1488", Surname = "Jam", TelNumb = "00000", Type = "admin" });
                ///db.SaveChanges();
            }
        }

        [HttpGet]
        public string Get()
        {

            return Program.GetFirst();
        }

        // GET api/users/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            Users user = db.Users.FirstOrDefault(x => x.Id == id);
            if (user == null)
                return NotFound();
            return new ObjectResult(user);
        }

        // POST api/users
        [HttpPost]
        public IActionResult Post([FromBody]Users user)
        {
            if (user == null)
            {
                return BadRequest();
            }

            db.Users.Add(user);
            db.SaveChanges();
            return Ok(user);
        }

        // PUT api/users/
        [HttpPut]
        public IActionResult Put([FromBody]Users user)
        {
            if (user == null)
            {
                return BadRequest();
            }
            if (!db.Users.Any(x => x.Id == user.Id))
            {
                return NotFound();
            }

            db.Update(user);
            db.SaveChanges();
            return Ok(user);
        }

        // DELETE api/users/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            Users user = db.Users.FirstOrDefault(x => x.Id == id);
            if (user == null)
            {
                return NotFound();
            }
            db.Users.Remove(user);
            db.SaveChanges();
            return Ok(user);
        }
    }
}

using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using TestApp;

namespace web.Controllers
{
    [Route("api/[controller]")]
    public class OrderController : Controller
    {
        UsersContext db;
        public OrderController(UsersContext context)
        {
            this.db = context;
            if (!db.Order.Any())
            {
                //db.Order.Add(new Models.Order {Address = "Kiev", OrderedItems= "negr", Status = "ne vipolneno", User = 1 });
                //db.SaveChanges();
            }
        }

        [HttpGet]
        public IEnumerable<Order> Get()
        {
            return db.Order.ToList();
        }

        // GET api/Orders/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            Order Order = db.Order.FirstOrDefault(x => x.Id == id);
            if (Order == null)
                return NotFound();
            return new ObjectResult(Order);
        }

        // POST api/Orders
        [HttpPost]
        public IActionResult Post([FromBody]Order Order)
        {
            if (Order == null)
            {
                return BadRequest();
            }

            db.Order.Add(Order);
            db.SaveChanges();
            return Ok(Order);
        }

        // PUT api/Orders/
        [HttpPut]
        public IActionResult Put([FromBody]Order Order)
        {
            if (Order == null)
            {
                return BadRequest();
            }
            if (!db.Order.Any(x => x.Id == Order.Id))
            {
                return NotFound();
            }

            db.Update(Order);
            db.SaveChanges();
            return Ok(Order);
        }

        // DELETE api/Orders/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            Order Order = db.Order.FirstOrDefault(x => x.Id == id);
            if (Order == null)
            {
                return NotFound();
            }
            db.Order.Remove(Order);
            db.SaveChanges();
            return Ok(Order);
        }
    }
}

using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;

using TestApp;

namespace web.Controllers
{
    [Route("api/[controller]")]
    public class ItemController : Controller
    {
        UsersContext db;
        public ItemController(UsersContext context)
        {
            this.db = context;
            if (!db.Item.Any())
            {
                //db.Item.Add(new Models.Item { Name = "Penis", Category = 1, Price = 100, Count = 1, Description = "Huy vo rtu", MainPhoto = "kartinki netu sosi chlen"});
                //db.SaveChanges();
            }
        }

        [HttpGet]
        public IEnumerable<Item> Get()
        {
            return db.Item.ToList();
        }

        // GET api/Items/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            Item Item = db.Item.FirstOrDefault(x => x.Id == id);
            if (Item == null)
                return NotFound();
            return new ObjectResult(Item);
        }

        // POST api/Items
        [HttpPost]
        public IActionResult Post([FromBody]Item Item)
        {
            if (Item == null)
            {
                return BadRequest();
            }

            db.Item.Add(Item);
            db.SaveChanges();
            return Ok(Item);
        }

        // PUT api/Items/
        [HttpPut]
        public IActionResult Put([FromBody]Item Item)
        {
            if (Item == null)
            {
                return BadRequest();
            }
            if (!db.Item.Any(x => x.Id == Item.Id))
            {
                return NotFound();
            }

            db.Update(Item);
            db.SaveChanges();
            return Ok(Item);
        }

        // DELETE api/Items/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            Item Item = db.Item.FirstOrDefault(x => x.Id == id);
            if (Item == null)
            {
                return NotFound();
            }
            db.Item.Remove(Item);
            db.SaveChanges();
            return Ok(Item);
        }
    }
}

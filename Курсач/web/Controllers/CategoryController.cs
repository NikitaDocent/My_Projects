using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;

using TestApp;
namespace web.Controllers
{
    [Route("api/[controller]")]
    public class CategoryController : Controller
    {
        UsersContext db;
        public CategoryController(UsersContext context)
        {
            this.db = context;
            if (!db.Category.Any())
            {
                /////db.Category.Add(new Models.Category {Name = "Huski" });
                ////db.SaveChanges();
            }
        }

        [HttpGet]
        public IEnumerable<Category> Get()
        {
            return db.Category.ToList();
        }

        // GET api/Categorys/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            Category Category = db.Category.FirstOrDefault(x => x.Id == id);
            if (Category == null)
                return NotFound();
            return new ObjectResult(Category);
        }

        // POST api/Categorys
        [HttpPost]
        public IActionResult Post([FromBody]Category Category)
        {
            if (Category == null)
            {
                return BadRequest();
            }

            db.Category.Add(Category);
            db.SaveChanges();
            return Ok(Category);
        }

        // PUT api/Categorys/
        [HttpPut]
        public IActionResult Put([FromBody]Category Category)
        {
            if (Category == null)
            {
                return BadRequest();
            }
            if (!db.Category.Any(x => x.Id == Category.Id))
            {
                return NotFound();
            }

            db.Update(Category);
            db.SaveChanges();
            return Ok(Category);
        }

        // DELETE api/Categorys/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            Category Category = db.Category.FirstOrDefault(x => x.Id == id);
            if (Category == null)
            {
                return NotFound();
            }
            db.Category.Remove(Category);
            db.SaveChanges();
            return Ok(Category);
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContactListSwagger
{
    [Route("/contacts")]
    public class ContactController : Controller
    {
        public static List<Person> items = new List<Person>();
        public int counterId=1;

        public ContactController()
        {
            
            items.Add(new Person(this.counterId, "Chuck", "Norris", "noemailneededforchucknorris"));
            this.counterId++;
            items.Add(new Person(this.counterId, "Obi-Wan", "Kenobi","obiwan@jedimaster.com"));
            this.counterId++;
            items.Add(new Person(this.counterId, "Anakin", "Skywalker", "aniwalker@nojedimaster.com"));
        }

        public List<Person> getItems()
        {
            return items;
        }

        [HttpGet/*("/contacts")*/]
        public IActionResult GetAll()
        {
            return Ok(items);
        }

        [HttpPost/*("/contacts")*/]
        public IActionResult Add([FromBody] Person test)
        {

            if(test == null)
            {
                return BadRequest();
            }
            test.Id = this.counterId;
            items.Add(test);
            return CreatedAtRoute("contacts", test);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            var pers = items.FirstOrDefault(t => t.Id == id);
            if (pers == null)
            {
                return NotFound();
            }

            items.Remove(pers);
            return Ok("Deleted Successfully!");
        }

        [HttpGet("findByName/{name}")]
        public IActionResult Findbyname(string name)
        {
            if (name.Equals(""))
            {
                return BadRequest();
            }
            List<Person> sol = new List<Person>();
            foreach(Person pers in items)
            {
                if (pers.Firstname.ToLower().Contains(name.ToLower()) || pers.Lastname.ToLower().Contains(name.ToLower()))
                {
                    sol.Add(pers);
                }
            }
            if (!sol.Any())
            {
                return Ok("Nothing found!");
            }
            return Ok(sol);
        }
    }
}

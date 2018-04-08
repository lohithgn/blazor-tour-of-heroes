using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlazorTourOfHeroes.Shared;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlazorTourOfHeroes.Server.Controllers
{
    [Produces("application/json")]
    [Route("api/Heroes")]
    public class HeroesController : Controller
    {
        private static List<Hero> Heroes = new List<Hero>()
        {
            new Hero{ Id= 11, Name= "Mr. Nice" },
            new Hero{ Id= 12, Name= "Narco" },
            new Hero{ Id= 13, Name= "Bombasto" },
            new Hero{ Id= 14, Name= "Celeritas" },
            new Hero{ Id= 15, Name= "Magneta" },
            new Hero{ Id= 16, Name= "RubberMan" },
            new Hero{ Id= 17, Name= "Dynama" },
            new Hero{ Id= 18, Name= "Dr IQ" },
            new Hero{ Id= 19, Name= "Magma" },
            new Hero{ Id= 20, Name= "Tornado" }
        };

        [HttpGet]
        public IActionResult GetHeroes([FromQuery] string name)
        {
            List<Hero> heroes = Heroes;
            if(!string.IsNullOrEmpty(name?.Trim()))
            {
                heroes = Heroes.Where(h => h.Name.ToLowerInvariant().Contains(name.ToLowerInvariant()))
                               .ToList();
            }
            return Ok(heroes.OrderByDescending(h=>h.Id));
        }

        [HttpGet]
        [Route("top")]
        public IActionResult GetTopHeroes()
        {
            return Ok(Heroes.Take(4));
        }

        [HttpGet("{id}",Name ="GetHero")]
        public IActionResult GetHero([FromRoute] int id)
        {
            var hero = Heroes.FirstOrDefault(h => h.Id == id);
            if(hero == null)
            {
                return NotFound();
            }
            return Ok(hero);
        }

        [HttpPost]
        public IActionResult CreateHero([FromBody] Hero newHero)
        {
            if (newHero == null)
            {
                return BadRequest();
            }
            newHero.Id = Heroes.Max(h => h.Id) + 1;
            Heroes.Add(newHero);
            return CreatedAtRoute("GetHero", new { id = newHero.Id }, newHero);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateHero(int id, [FromBody] Hero input)
        {
            if (input == null || input.Id != id)
            {
                return BadRequest();
            }

            var hero = Heroes.FirstOrDefault(t => t.Id == id);
            if (hero == null)
            {
                return NotFound();
            }

            hero.Name = input.Name;
            
            return new NoContentResult();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteHero(int id)
        {
            var hero = Heroes.FirstOrDefault(t => t.Id == id);
            if (hero == null)
            {
                return NotFound();
            }

            Heroes.Remove(hero);
            return new NoContentResult();
        }
    }
}
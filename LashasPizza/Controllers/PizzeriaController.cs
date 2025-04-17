using LashasPizza.Data;
using LashasPizza.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LashasPizza.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class PizzeriaController : ControllerBase
    {
        private readonly AppDbContext _context;

        public PizzeriaController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetPizzas()
        {
            var pizzas = _context.Pizzas.ToList();
            return Ok(pizzas);
        }

        [HttpGet("{id:int}")]
        public IActionResult GetPizzaById(int id) 
        {
            var pizza = _context.Pizzas.SingleOrDefault(p => p.Id == id);
            if (pizza == null)
            {
                return NotFound($"Pizza with id {id} not found");
            }
            return Ok(pizza);
        }

        [HttpPost]
        public IActionResult AddPizza([FromBody] Pizza pizza)
        {
            if (pizza == null)
            {
                return BadRequest("Pizza cannot be null");
            }

            _context.Pizzas.Add(pizza);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetPizzaById), new { id = pizza.Id }, pizza);
        }

        [HttpPut("{id:int}")]
        public IActionResult UpdatePizzaById(int id, [FromBody] Pizza pizza)
        {
            if (pizza == null || pizza.Id != id)
            {
                return BadRequest("Pizza cannot be null and id must match");
            }

            var existingPizza = _context.Pizzas.SingleOrDefault(p => p.Id == id);
            if (existingPizza == null)
            {
                return NotFound($"Pizza with id {id} not found");
            }

            existingPizza.Name = pizza.Name;
            existingPizza.Price = pizza.Price;

            _context.SaveChanges();

            return NoContent();
        }

        [HttpDelete]
        public IActionResult DeletePizza(int id)
        {
            var pizza = _context.Pizzas.SingleOrDefault(p => p.Id == id);
            if (pizza == null)
            {
                return NotFound($"Pizza with id {id} not found");
            }

            _context.Pizzas.Remove(pizza);
            _context.SaveChanges();

            return NoContent();
        }
    }
}

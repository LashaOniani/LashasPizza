using LashasPizza.Data;
using LashasPizza.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LashasPizza.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class PersonsController : ControllerBase
    {
        private readonly AppDbContext _contextDb;

        public PersonsController(AppDbContext context)
        {
            this._contextDb = context;
        }

        [HttpPost]
        public IActionResult CreatePerson([FromBody] Person person)
        {
            if (person == null)
            {
                return BadRequest("Person cannot be null");
            }
            _contextDb.Persons.Add(person);
            return StatusCode(StatusCodes.Status201Created, "Person Created Sucessfully!");
        }

        [HttpPut("{id:int}")]
        public IActionResult UpdatePerson([FromBody] Person person)
        {
            if(person == null) return StatusCode(StatusCodes.Status400BadRequest, "Person cannot be null");
            var ePerson = _contextDb.Persons.SingleOrDefault(p => p.Id == person.Id);
            if (ePerson == null) return StatusCode(StatusCodes.Status404NotFound, $"Person with id {person.Id} not found");
            return StatusCode(StatusCodes.Status200OK, "Person Updated Sucessfully!");
        }
    }
}

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjetoCRUD.Application.API.Context;
using ProjetoCRUD.Application.API.Models;

namespace ProjetoCRUD.Application.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly SQLServerContext _context;

        public PersonController(SQLServerContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Person>>> FindPerosnAll()
        {
            return await _context.People.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Person>> FindPersonById(int id)
        {
            Person person = await _context.People.FindAsync(id);
            if (person == null)
            {
                return NotFound();
            }
            return person;
        }

        [HttpPost]
        public async Task<ActionResult<Person>> SavePerson(Person person)
        {
            await _context.People.AddAsync(person);
            await _context.SaveChangesAsync();

            return Ok();
        }

        [HttpPut]
        public async Task<ActionResult> UpdatePerson(Person person)
        {
            _context.People.Update(person);
            await _context.SaveChangesAsync();

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeletePerson(int id)
        {
            Person person = await _context.People.FindAsync(id);
            _context.Remove(person);
            await _context.SaveChangesAsync();
            return Ok();
        }
    }
}

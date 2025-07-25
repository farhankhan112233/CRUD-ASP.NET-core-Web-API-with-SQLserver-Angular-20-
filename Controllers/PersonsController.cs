using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Representational_State_Transfer.Data;
using Representational_State_Transfer.Models.Entities;

namespace Representational_State_Transfer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonsController : ControllerBase
    {
        private readonly AppDbContext dbContext;

        public PersonsController(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        [HttpGet]
        public IActionResult GetAllPersons()
        {
            var persons = dbContext.Persons.ToList();
            return Ok(persons);
        }
        [HttpPost]
        public async Task<IActionResult> AddPerson([FromBody] Person person)
        {
          
            var newPerson = new Person
            {
                firstName = person.firstName,
                lastName = person.lastName,
                mail = person.mail,
                Address = new Address
                {
                    street = person.Address.street,
                    city = person.Address.city,
                    country = person.Address.country
                },
                gender = person.gender,
                phone = person.phone,
                description = person.description
            };

            dbContext.Persons.Add(newPerson);
            await dbContext.SaveChangesAsync();

            return CreatedAtAction(nameof(GetPersonById), new { id = newPerson.Id }, newPerson);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPersonById(int id)
        {
            var person = await dbContext.Persons.FindAsync(id);
            return person == null ? NotFound() : Ok(person);
        }
    }
}


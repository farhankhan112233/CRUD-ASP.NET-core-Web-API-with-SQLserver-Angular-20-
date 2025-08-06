using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Representational_State_Transfer.Data;
using Representational_State_Transfer.Interfaces;
using Representational_State_Transfer.Models.Entities;
using Representational_State_Transfer.Services;

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
        
        [HttpPost]
        public async Task<IActionResult> AddPerson([FromBody] Person person)
        {
            bool existingValues = dbContext.Persons.Any(p => p.mail == person.mail &&
            p.phone == person.phone);
            
            if (person == null || existingValues)
            {
                return BadRequest();
            }

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
        
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePerson(int id, [FromBody] Person person)
        {
            
            //if (id != person.Id)
            //{
            //    return BadRequest("Person ID mismatch.");
            //}
            var existingPerson = await dbContext.Persons.FindAsync(id);
            if (existingPerson == null)
            {
                return NotFound();
            }
            existingPerson.firstName = person.firstName;
            existingPerson.lastName = person.lastName;
            existingPerson.mail = person.mail;
            existingPerson.Address = person.Address;
            existingPerson.gender = person.gender;
            existingPerson.phone = person.phone;
            existingPerson.description = person.description;
            dbContext.Persons.Update(existingPerson);
            await dbContext.SaveChangesAsync();
            return NoContent();



        }
        [Authorize]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePerson(int id)
        {
            var person = await dbContext.Persons.FindAsync(id);
            if (person == null)
            {
                return NotFound();
            }
            dbContext.Persons.Remove(person);
            await dbContext.SaveChangesAsync();
            return NoContent();
        }
        
       
    }
}
    


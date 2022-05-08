using System.Collections.Generic;
using System.Threading.Tasks;
using Lab2_Kazimierowski.rest.Context;
using Lab2_Kazimierowski.rest.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Lab2_Kazimierowski.rest.Controllers
{    
    [ApiController]
    [Route( "/people")]
    public class PeopleController: Controller
    {
        private AzureDbContext azureDbContext;

        public PeopleController(AzureDbContext azureDbContext)
        {
            this.azureDbContext = azureDbContext;
        }


        [HttpGet]
        public async Task<List<Person>> GetAllPersons()
        {
            return await azureDbContext.People.ToListAsync();
        }

        [HttpGet("{personId}")]
        public async Task<Person> GetPersonById(int personId)
        {
            return await azureDbContext.People.FirstOrDefaultAsync(e => e.PersonId == personId);
        }

        [HttpPost]
        public async Task<Person> AddPerson([FromBody]Person person)
        {
            var result = await azureDbContext.People.AddAsync(person);
            await azureDbContext.SaveChangesAsync();
            return result.Entity;
        }

        [HttpPut("{personId}")]
        public async Task<Person> UpdatePerson(int personId, [FromBody] PersonS person)
        {
            var result = await azureDbContext.People.FirstOrDefaultAsync(e => e.PersonId == personId);

            if (result == null) return null;
            result.FirstName = person.FirstName;
            result.LastName = person.LastName;

            await azureDbContext.SaveChangesAsync();

            return result;

        }

        [HttpDelete("{personId}")]
        public async void DeletePerson(int personId)
        {
            var result = await azureDbContext.People.FirstOrDefaultAsync(e => e.PersonId == personId);
            if (result == null) return;
            azureDbContext.People.Remove(result);
            await azureDbContext.SaveChangesAsync();
        }
    }
}
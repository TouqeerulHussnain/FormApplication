using FormApplication.Models;
using Microsoft.EntityFrameworkCore;

namespace FormApplication.Services
{
    public class ApplicationDatabaseContext:DbContext
    {
        public ApplicationDatabaseContext(DbContextOptions options):base(options)
        {

        }
        public DbSet<Person>    Persons { get; set; }

        public void AddPerson(Person person) { 
            Persons.Add(person);
        }
    }
}

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HigherLowerGame
{
    public class PersonDbContext : DbContext, IDesignTimeDbContextFactory<PersonDbContext>
    {
        public PersonDbContext(DbContextOptions<PersonDbContext> options):base(options)
        {
            
        }

        public PersonDbContext()
        {
            
        }

        public DbSet<Person> Persons { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured) { 
                optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=PersonDB");
            }
        }

        public PersonDbContext CreateDbContext(string[] args)
        {
            return new PersonDbContext();
        }
    }
}

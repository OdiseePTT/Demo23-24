using AutoFixture;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using System.Data.Common;

namespace HigherLowerGame.Tests
{
    public class PersonRepositoryTests
    {
        // In-memory db setup start

        private DbContextOptions<PersonDbContext> _options;
        private Fixture _fixture = new Fixture();

        public PersonRepositoryTests()
        {
            // in-memory db maken
            DbConnection connection = new SqliteConnection("Filename=:memory:");
            connection.Open();

            // options ophalen voor de connection
            _options = new DbContextOptionsBuilder<PersonDbContext>().UseSqlite(connection).Options;

            PersonDbContext personDbContext = CreateDbContext();
            personDbContext.Database.EnsureCreated();
        }

        private PersonDbContext CreateDbContext()
        {
            return new PersonDbContext(_options);
        }

        // In-memory db setup end


        [Fact]
        public void GetAllPersons_WithItemsInDB_ReturnsListOfPersons()
        {
            // Arrange
            PersonDbContext dbContext = CreateDbContext(); //  test double

            List<Person> persons = _fixture.Build<Person>()
                .With(person => person.Id, 0)
                .With(person => person.BirthDate, new DateTime(1990, 21,2))
                .CreateMany().ToList();


            SeedDatabaseWithData(dbContext, persons);
            PersonRepository sut = new PersonRepository(dbContext);

            // Act
            List<Person> actualPersons = sut.GetAllPersons();

            // Assert
            //actualPersons.Should().HaveCount(4);
            actualPersons.Should().BeEquivalentTo(persons);

        }

        [Fact]
        public void GetAllPersonsWithBirthyearBelow_WithBirthYear2010_ReturnsItemsWithBirthYearBelow2010()
        {
            // Arrange
            PersonDbContext dbContext = CreateDbContext(); //  test double

            List<Person> personsWithBirtDateBefore2010 = _fixture.Build<Person>()
           .With(person => person.Id, 0)
           .With(person => person.BirthDate, new DateTime(1990, 2, 2))
           .CreateMany().ToList();

            List<Person> personsWithBirtDateAfter2010 = _fixture.Build<Person>()
           .With(person => person.Id, 0)
           .With(person => person.BirthDate, new DateTime(2020, 2, 2))
           .CreateMany().ToList();


            SeedDatabaseWithData(dbContext,personsWithBirtDateAfter2010);
            SeedDatabaseWithData(dbContext, personsWithBirtDateBefore2010);
            PersonRepository sut = new PersonRepository(dbContext);

            // Act
            List<Person> persons = sut.GetAllPersonsWithBirthyearBelow(2010);

            // Assert
            persons.Should().HaveCount(3);
            persons.Should().BeEquivalentTo(
                personsWithBirtDateBefore2010
                );
        }

        [Fact]
        public void AddPerson_WithRandomPerson_AddPersonToDb()
        {

            // Arrange
            PersonDbContext context = CreateDbContext();
            PersonRepository sut = new PersonRepository(context);
            DateTime CurrentDate = DateTime.Today;

            // Act
            sut.AddPerson(new Person("Demo", "Demo", CurrentDate )); 

            // Assert
            context.Persons.Should().ContainEquivalentOf(new Person("Demo", "Demo", CurrentDate) { Id = 1 });
        }


        private void SeedDatabaseWithData(PersonDbContext dbContext, List<Person> persons)
        {
            dbContext.Persons.AddRange(persons);
            dbContext.SaveChanges();
        }
    }
}

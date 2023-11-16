using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Todo.Data;
using Todo.Data.Entities;

namespace Todo.UITests.Helpers
{
    public class BaseTest
    {
        protected WebDriver _webDriver;
        protected string _url = "https://localhost:1234";

        ApplicationDbContext _context;
        UserManager<IdentityUser> _userManager;
        public BaseTest(SharedWebDriver driver)
        {
            _webDriver = driver;

            WebApplicationFactory<TodoProgram> factory = new WebTestingHostFactory<TodoProgram>();

            factory = factory.WithWebHostBuilder(builder =>
            {
                var dbConnection = new SqliteConnection("DataSource=:memory:");
                dbConnection.Open();

                builder.UseUrls(_url);

                builder.ConfigureServices(services =>
                {
                    var descriptor = services.SingleOrDefault(d => d.ServiceType == typeof(DbContextOptions<ApplicationDbContext>));

                    if (descriptor != null) services.Remove(descriptor);

                    services.AddDbContext<ApplicationDbContext>(options => {
                        options.UseSqlite(dbConnection);
                    });
                });
            });

            factory.CreateDefaultClient();

            IServiceScope scope = factory.Services.CreateScope();
            _context = scope.ServiceProvider.GetService<ApplicationDbContext>();
            _context.Database.EnsureCreated();

            _userManager = scope.ServiceProvider.GetService<UserManager<IdentityUser>>();

        }

        protected void AddUser(string username, string password)
        {
            IdentityUser user = new IdentityUser("matthias.druwe@odisee.be");
            user.EmailConfirmed = true;
            _userManager.CreateAsync(user, password);

        }

        protected void AddTodoItem(TodoItem item)
        {
            _context.TodoItems.Add(item);
            _context.SaveChanges();

        }
    }
}

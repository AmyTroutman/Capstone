using LibraryApp.Core.Models;
using LibraryApp.Core.Services;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryApp
{
    public class DbInitializer
    {
        private readonly IBookRepository _bookRepository;
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly ICatalogRepository _catalogRepository;

        public DbInitializer(UserManager<User> userManager, RoleManager<IdentityRole> roleManager, ICatalogRepository catalogRepository, IBookRepository bookRepository)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _bookRepository = bookRepository;
            _catalogRepository = catalogRepository;
        }

        public void Initialize()
        {
            AddAdminUser();
            AddTestUsers();
            AddTestCatalogs();
        }

        public void AddTestUsers()
        {
            var testUsers = new[]
            {
                new
                {
                    Email = "john.smith@test.com",
                    FirstName = "John",
                    LastName = "Smith"
                },

            new
            {
                Email = "jane.doe@test.com",
                FirstName = "Jane",
                LastName = "Doe"
            }
            };

            foreach (var user in testUsers)
            {
                CreateUser(user.Email, user.FirstName, user.LastName);
            }
        }

        private User CreateUser(string email, string firstName, string lastname)
        {
            if (_userManager.FindByEmailAsync(email).Result == null)
            {
                User user = new User
                {
                    UserName = email,
                    Email = email,
                    FirstName = firstName,
                    LastName = lastname
                };

                var result = _userManager.CreateAsync(user, "Testing123!").Result;
                if (result.Succeeded) return user;
            }
            return null;
        }

        public void AddTestCatalogs()
        {
            if (_catalogRepository.GetAll().Count() > 0) return;

            var john = _userManager.FindByNameAsync("john.smith@test.com").Result;
            var jane = _userManager.FindByNameAsync("jane.doe@test.com").Result;
            var johnCatalog1 = CreateTestCatalog(john, "My First Library");
            var janeCatalog1 = CreateTestCatalog(jane, "Random Nonsense");
            _catalogRepository.Add(johnCatalog1);
            _catalogRepository.Add(janeCatalog1);
        }

        private Catalog CreateTestCatalog(User user, string name)
        {
            return new Catalog
            {
                Name = name,
                UserId = user.Id,
                Books = new List<Book>
                {
                    new Book
                    {
                        Title = "Leviathan Wakes",
                        Genre = "SciFi",
                        Notes = "The first. More of a mystery/noir detective style.",
                        Medium = "eBook",
                        Author = CreateTestAuthor("James", "Corey"),
                        Series = CreateTestSeries("The Expanse", 1)
                    },
                    new Book
                    {
                        Title = "Caliban's War",
                        Genre = "SciFi",
                        Notes = "The search for Mei on Ganymede, protomolecule experiements on kids.",
                        Medium = "eBook",
                        Author = CreateTestAuthor("James", "Corey"),
                        Series = CreateTestSeries("The Expanse", 2)
                    },
                    new Book
                    {
                        Title = "Abaddon's Gate",
                        Genre = "SciFi",
                        Notes = "Welcome to the creepy alien gate. Holden is guided by alien/ghost Miller and activates the gate.",
                        Medium = "eBook",
                        Author = CreateTestAuthor("James", "Corey"),
                        Series = CreateTestSeries("The Expanse", 3)
                    },
                    new Book
                    {
                        Title = "Cibola Burn",
                        Genre = "SciFi",
                        Notes = "Holden plays sheriff on a gun crazy planet. Everybody is going blind, good times.",
                        Medium = "Paperback",
                        Author = CreateTestAuthor("James", "Corey"),
                        Series = CreateTestSeries("The Expanse", 4)
                    },
                    new Book
                    {
                        Title = "Nemesis Games",
                        Genre = "SciFi",
                        Notes = "The one where the gang is scattered throughout the solar system dealing with their own stuff.",
                        Medium = "Hardback",
                        Author = CreateTestAuthor("James", "Corey"),
                        Series = CreateTestSeries("The Expanse", 5)
                    }
                }
            };
        }

        private Author CreateTestAuthor(string firstName, string lastName)
        {
            return new Author
            {
                FirstName = firstName,
                LastName = lastName,
            };
        }

        private Series CreateTestSeries(string name, int seriesNum)
        {
            return new Series
            {
                Name = name,
            };
        }

        private void AddAdminUser()
        {
            if (_roleManager.FindByNameAsync("Admin").Result == null)
            {
                var adminRole = new IdentityRole
                {
                    Name = "Admin",
                    NormalizedName = "Admin".ToUpper()
                };
                var result = _roleManager.CreateAsync(adminRole).Result;
            }

            var user = CreateUser("admin@test.com", "admin", "admin");
            if (user != null)
            {
                _userManager.AddToRoleAsync(user, "Admin").Wait();
            }
        }
    }
}
    

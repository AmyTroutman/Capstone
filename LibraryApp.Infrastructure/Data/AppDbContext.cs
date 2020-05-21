using LibraryApp.Core.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;


namespace LibraryApp.Infrastructure.Data
{
    public class AppDbContext : DbContext //If you add users, change to IdentityDbContext<User>
    {
        //public DbSet<Book> Books { get; set; }
        //public DbSet<Author> Authors { get; set; }
        //public DbSet<Series> Series { get; set; }
        //public DbSet<Catalog> Catalogs { get; set; }
        //todo check that this is correct (Checkpoint)
        //public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=book.db");
        }
        //todo check quiz project from Azure lesson to see how to set up switching to sqlserver
    }
}

using LibraryApp.Core.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;


namespace LibraryApp.Infrastructure.Data
{
    public class AppDbContext : IdentityDbContext
    {
       /* public AppDbContext(DbContextOptions<AppDbContext> options)
    : base(options)
        { }*/

        public DbSet<Book> Books { get; set; }
        public DbSet<Catalog> Catalogs { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Series> Series { get; set; }

        //todo check quiz project from Azure lesson to see how to set up switching to sqlserver
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=book.db");
        }

        

      
    }
}

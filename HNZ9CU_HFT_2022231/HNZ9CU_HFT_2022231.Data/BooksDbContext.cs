using HNZ9CU_HFT_2022231.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace HNZ9CU_HFT_2022231.Data
{
    public class BooksDbContext : DbContext
    {
        public virtual DbSet<Book> Books { get; set; }
        public virtual DbSet<Publisher> Publishers { get; set; }
        public virtual DbSet<Author> Authors { get; set; }



        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
                this.Database.EnsureCreated();

            optionsBuilder.UseInMemoryDatabase("BooksDB").UseLazyLoadingProxies();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            








        }
    }
}

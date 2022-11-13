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

        public BooksDbContext()
        {
            this.Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseInMemoryDatabase("BooksDB").UseLazyLoadingProxies();
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>(
                entity =>
                {
                    entity.HasOne(book => book.Author)
                    .WithMany(author => author.Books)
                    .HasForeignKey(book => book.AuthorId)
                    .OnDelete(DeleteBehavior.Cascade);

                    entity.HasOne(book => book.Publisher)
                    .WithMany(pub => pub.Books)
                    .HasForeignKey(book => book.PublisherId)
                    .OnDelete(DeleteBehavior.Cascade);
                });

            var books = new Book[]
            {
                new Book(){ Id = 1, Title = "ASD", Price = 1233, RelaseDate = 2007, PagenNumber = 120, Rating = 4.5, AuthorId = 1, PublisherId = 1 },
                new Book(){ Id = 2, Title = "asdfasdf", Price = 3000, RelaseDate = 1999, PagenNumber = 220, Rating = 3, AuthorId = 2, PublisherId = 2 }

            };

            var authors = new Author[]
            {
                new Author(){ Id = 1, BirthDate = 1823, IsAlive = false, Country = "Hungary", Name = "Sándor Petőfi"},
                new Author(){ Id = 2, BirthDate = 1987, IsAlive = true, Country = "Hungary", Name = "Kovács János"}

            };

            var publishers = new Publisher[]
            {
                new Publisher(){ Id = 1, Name = "BestBooks", City  = "Budapest", Address = "Hungária krt. 44.", EstablishDate = 2001, NumberOfPublishedBooks = 340, Rating = 3.7},
                new Publisher(){ Id = 2, Name = "ShitBooks", City  = "Budapest", Address = "Hungária krt. 22.", EstablishDate = 2004, NumberOfPublishedBooks = 10, Rating = 2},

            };

            modelBuilder.Entity<Book>().HasData(books);
            modelBuilder.Entity<Author>().HasData(authors);
            modelBuilder.Entity<Publisher>().HasData(publishers);

        }
    }
}

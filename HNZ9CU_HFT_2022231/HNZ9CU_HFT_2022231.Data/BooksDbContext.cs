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

            modelBuilder.Entity<Author>(
                e =>
                {
                    e.HasMany(b => b.Books)
                    .WithOne(c => c.Author)
                    .HasForeignKey(c => c.AuthorId)
                    .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity<Publisher>(
                e =>
                {
                    e.HasMany(b => b.Books)
                    .WithOne(c => c.Publisher)
                    .HasForeignKey(c => c.PublisherId)
                    .OnDelete(DeleteBehavior.Cascade);
                });

            var books = new Book[]
            {
                new Book(){ Id = 1, Title = "Elveszett Bárka", Price = 1233, RelaseDate = 2007, PagenNumber = 120, Rating = 4.5, AuthorId = 1, PublisherId = 1 },
                new Book(){ Id = 2, Title = "Utazás a Holdba", Price = 1643, RelaseDate = 1999, PagenNumber = 431, Rating = 2.2, AuthorId = 1, PublisherId = 1 },
                new Book(){ Id = 3, Title = "Leleményes Hangya", Price = 2495, RelaseDate = 1951, PagenNumber = 152, Rating = 8.3, AuthorId = 1, PublisherId = 2 },
                new Book(){ Id = 4, Title = "Gondolatok az életről", Price = 1216, RelaseDate = 1992, PagenNumber = 340, Rating = 8.9, AuthorId = 1, PublisherId = 1 },
                new Book(){ Id = 5, Title = "Magasságok és mélységek", Price = 8335, RelaseDate = 1977, PagenNumber = 265, Rating = 8.5, AuthorId = 2, PublisherId = 1 },
                new Book(){ Id = 6, Title = "Írásjelek manapság", Price = 7080, RelaseDate = 1998, PagenNumber = 113, Rating = 3.7, AuthorId = 2, PublisherId = 2 },
                new Book(){ Id = 7, Title = "Aranyásók", Price = 3581, RelaseDate = 2009, PagenNumber = 306, Rating = 2.7, AuthorId = 2, PublisherId = 2 },
                new Book(){ Id = 8, Title = "Kecskék farmja", Price = 5147, RelaseDate = 1961, PagenNumber = 422, Rating = 6.7, AuthorId = 3, PublisherId = 2 },
                new Book(){ Id = 9, Title = "Népmesék", Price = 5042, RelaseDate = 1980, PagenNumber = 415, Rating = 4.2, AuthorId = 3, PublisherId = 3 },
                new Book(){ Id = 10, Title = "Jancsi utazásai", Price = 8346, RelaseDate = 1959, PagenNumber = 354, Rating = 7.3, AuthorId = 4, PublisherId = 3 },
                new Book(){ Id = 11, Title = "Rákok vándorlása", Price = 5917, RelaseDate = 1963, PagenNumber = 407, Rating = 3.3, AuthorId = 4, PublisherId = 3 },
                new Book(){ Id = 12, Title = "Polcok harca", Price = 4405, RelaseDate = 1969, PagenNumber = 450, Rating = 9.4, AuthorId = 5, PublisherId = 4 },
                new Book(){ Id = 13, Title = "Galván Peti titka", Price = 1029, RelaseDate = 1984, PagenNumber = 411, Rating = 3.4, AuthorId = 6, PublisherId = 3 },
                new Book(){ Id = 14, Title = "Metró és csatornák", Price = 3955, RelaseDate = 1977, PagenNumber = 113, Rating = 4, AuthorId = 7, PublisherId = 4 },
                new Book(){ Id = 15, Title = "Répa ültetés kezdőknek", Price = 2846, RelaseDate = 1995, PagenNumber = 310, Rating = 6.4, AuthorId = 6, PublisherId = 4 },
                new Book(){ Id = 16, Title = "Világ országai", Price = 6836, RelaseDate = 1957, PagenNumber = 272, Rating = 2.9, AuthorId = 7, PublisherId = 5 },
                new Book(){ Id = 17, Title = "A tegnap ma van", Price = 8821, RelaseDate = 1998, PagenNumber = 275, Rating = 4.4, AuthorId = 8, PublisherId = 5 },
                new Book(){ Id = 18, Title = "Sünök támadása", Price = 5486, RelaseDate = 1974, PagenNumber = 447, Rating = 7.9, AuthorId = 8, PublisherId = 5 },
                new Book(){ Id = 19, Title = "Aranyásók 2", Price = 576, RelaseDate = 2014, PagenNumber = 204, Rating = 3.6, AuthorId = 2, PublisherId = 2 },
                new Book(){ Id = 20, Title = "Polcok harca 2", Price = 3790, RelaseDate = 1980, PagenNumber = 333, Rating = 6.6, AuthorId = 5, PublisherId = 4 }
            };

            var authors = new Author[]
            {
                new Author(){ Id = 1, BirthDate = 1940, IsAlive = true, Country = "Hungary", Name = "Sándor Petako"},
                new Author(){ Id = 2, BirthDate = 1953, IsAlive = false, Country = "France", Name = "Fracios Glea"},
                new Author(){ Id = 3, BirthDate = 1939, IsAlive = true, Country = "Hungary", Name = "Árpád Kalanti"},
                new Author(){ Id = 4, BirthDate = 1926, IsAlive = false, Country = "USA", Name = "Peter Perker"},
                new Author(){ Id = 5, BirthDate = 1955, IsAlive = true, Country = "England", Name = "Wiliam Strong"},
                new Author(){ Id = 6, BirthDate = 1969, IsAlive = true, Country = "Russia", Name = "Ivan Ivinics"},
                new Author(){ Id = 7, BirthDate = 1934, IsAlive = false, Country = "Hungary", Name = "Lajos Bárdos"},
                new Author(){ Id = 8, BirthDate = 1950, IsAlive = false, Country = "Croatia", Name = "Luka Timoti"}
            };

            var publishers = new Publisher[]
            {
                new Publisher(){ Id = 1, Name = "Best Books", City  = "Budapest", Address = "Hungária krt. 44", EstablishDate = 2001, NumberOfPublishedBooks = 340, Rating = 3.7},
                new Publisher(){ Id = 2, Name = "Alexandro", City  = "Szeged", Address = "Iskola utca 13", EstablishDate = 2004, NumberOfPublishedBooks = 10, Rating = 2},
                new Publisher(){ Id = 3, Name = "Hipogrif Kiadó", City  = "Budapest", Address = "Kálvin tér 36", EstablishDate = 2004, NumberOfPublishedBooks = 10, Rating = 2},
                new Publisher(){ Id = 4, Name = "Ancient Cities", City  = "Budapest", Address = "Etele út 78", EstablishDate = 2004, NumberOfPublishedBooks = 10, Rating = 2},
                new Publisher(){ Id = 5, Name = "Better Be Reader", City  = "Győr", Address = "Ortondia utca 29", EstablishDate = 2004, NumberOfPublishedBooks = 10, Rating = 2}
            };

            modelBuilder.Entity<Book>().HasData(books);
            modelBuilder.Entity<Author>().HasData(authors);
            modelBuilder.Entity<Publisher>().HasData(publishers);
        }
    }
}

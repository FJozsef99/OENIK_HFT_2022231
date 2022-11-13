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








        }
    }
}

using HNZ9CU_HFT_2022231.Data;
using HNZ9CU_HFT_2022231.Logic;
using HNZ9CU_HFT_2022231.Models;
using HNZ9CU_HFT_2022231.Repository;
using System;
using System.Linq;

namespace HNZ9CU_HFT_2022231.Client
{
    public class Program
    {
        static void Main(string[] args)
        {
            BooksDbContext db = new BooksDbContext();

            var q1 = db.Books.ToList();

            BookRepository bk = new BookRepository(db);
            AuthorRepository au = new AuthorRepository(db);
            PublisherRepository pu = new PublisherRepository(db);

            

            

            //bk.Create(new Book() { Id = 3, Title = "UjKonyv", Price = 7878, RelaseDate = 2022, PagenNumber = 33, Rating = 6, AuthorId = 2, PublisherId = 2 });
            //var allbook1 = bk.GetAll();
            
            //var bok = bk.GetOne(3);
            
            //bk.Update(new Book() { Id = 3, Title = "UjKonyv", Price = 10000, RelaseDate = 2022, PagenNumber = 33, Rating = 10, AuthorId = 2, PublisherId = 2 }, 3);
            //var allbook3 = bk.GetAll();
            
            //bk.Delete(3);
            //var allbook2 = bk.GetAll();
        }
    }
}

using HNZ9CU_HFT_2022231.Data;
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
            ;
        }
    }
}

using HNZ9CU_HFT_2022231.Data;
using HNZ9CU_HFT_2022231.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HNZ9CU_HFT_2022231.Repository
{
    public class BookRepository : Repository<Book>, IBookRepository
    {

        public BookRepository(BooksDbContext db) : base(db)
        {
        }

        public override void Update(Book newitem, int id)
        {
            Book oldb = ReadOne(id);

            oldb.Price = newitem.Price;
            oldb.PublisherId = newitem.PublisherId;
            oldb.Rating = newitem.Rating;
        }
    }
}

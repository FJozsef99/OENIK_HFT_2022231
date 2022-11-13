using HNZ9CU_HFT_2022231.Data;
using HNZ9CU_HFT_2022231.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HNZ9CU_HFT_2022231.Repository
{
    public class PublisherRepository : Repository<Publisher>, IPublisherRepository
    {
        public PublisherRepository(BooksDbContext db) : base(db)
        {
        }

        public override void Update(Publisher newitem, int id)
        {
            Publisher old = newitem;
            old.City = newitem.City;
            old.Address = newitem.Address;
            old.Rating = newitem.Rating;
            old.NumberOfPublishedBooks = newitem.NumberOfPublishedBooks;
        }
    }
}

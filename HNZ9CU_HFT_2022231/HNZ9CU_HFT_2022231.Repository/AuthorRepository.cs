using HNZ9CU_HFT_2022231.Data;
using HNZ9CU_HFT_2022231.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HNZ9CU_HFT_2022231.Repository
{
    public class AuthorRepository : Repository<Author>, IAuthorRepository
    {
        public AuthorRepository(BooksDbContext db) : base(db)
        {
        }
        public override void Update(Author newitem, int id)
        {
            Author old = ReadOne(id);

            old.IsAlive = newitem.IsAlive;
            old.Country = newitem.Country;
        }
    }
}

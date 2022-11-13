using HNZ9CU_HFT_2022231.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HNZ9CU_HFT_2022231.Logic
{
    public interface IAuthorLogic
    {
        public bool Create(Author newbook);
        public Author ReadOne(int id);
        public IQueryable<Author> ReadAll();
        public bool Update(Author newbook);
        public bool Delete(int id);
    }
}

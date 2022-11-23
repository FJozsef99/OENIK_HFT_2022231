using HNZ9CU_HFT_2022231.Models;
using HNZ9CU_HFT_2022231.Models.helperClasses;
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
        public IEnumerable<Author> ReadAll();
        public bool Update(Author newbook, int id);
        public bool Delete(int id);

        //non crud
        //All Dead Writer who has a book with at least 6 rating
        public IEnumerable<DeadBookWithRating> GoodHunDeadWriters();
    }
}

using HNZ9CU_HFT_2022231.Models;
using HNZ9CU_HFT_2022231.Models.helperClasses;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace HNZ9CU_HFT_2022231.Logic
{
    public interface IBookLogic
    {
        public bool Create(Book newbook);
        public Book ReadOne(int id);
        public IEnumerable<Book> ReadAll();
        public bool Update(Book newbook, int id);
        public bool Delete(int id);

        //non cruds:
        
        //Halott írók kiadói listázva
        public IEnumerable<PubName> PublishersOfDeadWriters();
    }
}

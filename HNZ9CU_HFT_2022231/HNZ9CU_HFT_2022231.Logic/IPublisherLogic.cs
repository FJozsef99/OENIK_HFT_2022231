using HNZ9CU_HFT_2022231.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HNZ9CU_HFT_2022231.Logic
{
    public interface IPublisherLogic
    {
        public bool Create(Publisher newbook);
        public Publisher ReadOne(int id);
        public IQueryable<Publisher> ReadAll();
        public bool Update(Publisher newbook, int id);
        public bool Delete(int id);
    }
}

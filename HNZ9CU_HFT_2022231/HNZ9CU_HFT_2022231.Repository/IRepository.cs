using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HNZ9CU_HFT_2022231.Repository
{
    public interface IRepository<T> where T : class
    {
        public void Create(T newitem);
        T ReadOne(int id);
        IEnumerable<T> ReadAll();
        abstract public void Update(T newitem, int id);
        public void Delete(int id);
    }
}

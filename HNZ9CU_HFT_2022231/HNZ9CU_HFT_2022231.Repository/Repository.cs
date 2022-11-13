using HNZ9CU_HFT_2022231.Data;
using System;
using System.Linq;

namespace HNZ9CU_HFT_2022231.Repository
{
    public abstract class Repository<T> : IRepository<T> where T : class
    {
        protected BooksDbContext dbctx;
        public Repository(BooksDbContext db)
        {
            this.dbctx = db;
        }
        public void Create(T newitem)
        {
            dbctx.Add(newitem);
            dbctx.SaveChanges();
        }

        public void Delete(int id)
        {
            dbctx.Set<T>().Remove(ReadOne(id));
            dbctx.SaveChanges();
        }

        public IQueryable<T> ReadAll()
        {
            return dbctx.Set<T>();
        }

        public T ReadOne(int id)
        {
            return dbctx.Set<T>().Find(id);
        }

        virtual public void Update(T newitem, int id)
        {
        }
    }
}

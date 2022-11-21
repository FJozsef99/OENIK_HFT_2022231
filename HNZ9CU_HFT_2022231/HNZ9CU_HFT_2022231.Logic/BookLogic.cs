using HNZ9CU_HFT_2022231.Models;
using HNZ9CU_HFT_2022231.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace HNZ9CU_HFT_2022231.Logic
{
    public class BookLogic : IBookLogic
    {
        protected IBookRepository bookrepo;
        protected IAuthorRepository authorrepo;
        protected IPublisherRepository pubrepo;



        public BookLogic(IBookRepository bookrep)
        {
            bookrepo = bookrep;
        }

        public bool Create(Book newbook)
        {
            try
            {
                bookrepo.Create(newbook);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Delete(int id)
        {
            try
            {
                bookrepo.Delete(id);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public IQueryable<Book> ReadAll()
        {
            return bookrepo.ReadAll();
        }

        public Book ReadOne(int id)
        {
            return bookrepo.ReadOne(id);
        }

        public bool Update(Book newbook, int id)
        {
            try
            {
                bookrepo.Update(newbook, id);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public double AvgRatingOfBestBookPublisher()
        {
            throw new NotImplementedException();
        }

        public int FavouritePublisherSumPrice() // legkedveltebb kiadó könyveinek összára
        {
            var maxrating = pubrepo.ReadAll();//.Max(x => x.Rating);
            //var q = pubrepo.ReadAll().Where(x => x.Rating == maxrating).First().Books.Sum(y => y.Price);

            return 33333;
        }

        public List<Publisher> PublishersOfDeadWriters()
        {
            var deads = bookrepo.ReadAll().Where(x => x.Author.IsAlive == false).ToList();

            var books = from x in bookrepo.ReadAll()
                        where x.Author.IsAlive == false
                        group x by x.Publisher into g
                        select g;
            List<Publisher> ret = new List<Publisher>();
            //foreach (var item in books)
            //{
            //    ret.Add(item);
            //}
            return null;

        }
    }
}

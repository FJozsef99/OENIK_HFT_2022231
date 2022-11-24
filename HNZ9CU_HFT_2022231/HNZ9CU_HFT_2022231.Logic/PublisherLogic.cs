using HNZ9CU_HFT_2022231.Models;
using HNZ9CU_HFT_2022231.Models.helperClasses;
using HNZ9CU_HFT_2022231.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace HNZ9CU_HFT_2022231.Logic
{
    public class PublisherLogic : IPublisherLogic
    {
        protected IPublisherRepository pubrepo;

        public PublisherLogic(IPublisherRepository pubrep)
        {
            pubrepo = pubrep;
        }

        public bool Create(Publisher newpub)
        {
            if (newpub.Name.Length < 1)
            {
                throw new ArgumentException("Please enter a valid name for the new publisher!");
            }

            try
            {
                pubrepo.Create(newpub);
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
                pubrepo.Delete(id);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public IEnumerable<Publisher> ReadAll()
        {
            return pubrepo.ReadAll();
        }

        public Publisher ReadOne(int id)
        {
            return pubrepo.ReadOne(id);
        }

        public bool Update(Publisher newpub, int id)
        {
            try
            {
                pubrepo.Update(newpub, id);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        //non cruds

        public IEnumerable<BestBooks> BestBooksInEveryPublisher()
        {
            var pubs = pubrepo.ReadAll();

            List<Book> books = new List<Book>();

            foreach (var p in pubs)
            {
                var b = p.Books.Where(y => y.Rating == (p.Books.Max(x => x.Rating))).First();
                books.Add(b);
            }

            var q = from x in books
                    orderby x.Publisher.Name
                    select new BestBooks
                    {
                        PublisherName = x.Publisher.Name,
                        BestBookName = x.Title,
                        BookRating = x.Rating
                    };

            return q;
        }

        public IEnumerable<GoodPublisher> PubAndBooksGoodRating() //a kiadó és a könyvek átlag értékelése nagyobb mint 5.7
        {
            var ret = from x in pubrepo.ReadAll()
                      where ((x.Rating) + (x.Books.Average(b => b.Rating))) / 2 > 5.7
                      select new GoodPublisher
                      {
                          PublisherName = x.Name,
                          OverAllRating = ((x.Rating) + (x.Books.Average(b => b.Rating))) / 2
                      };
            return ret;
        }
    }
}

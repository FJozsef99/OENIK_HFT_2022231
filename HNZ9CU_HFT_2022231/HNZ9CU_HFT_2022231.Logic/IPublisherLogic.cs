using HNZ9CU_HFT_2022231.Models;
using HNZ9CU_HFT_2022231.Models.helperClasses;
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
        public IEnumerable<Publisher> ReadAll();
        public bool Update(Publisher newbook, int id);
        public bool Delete(int id);

        //non crud
        //Minden kiadó legsikeresebb könyve és annak ára
        public IEnumerable<BestBooks> BestBooksInEveryPublisher();

        public IEnumerable<GoodPublisher> PubAndBooksGoodRating();


    }
}

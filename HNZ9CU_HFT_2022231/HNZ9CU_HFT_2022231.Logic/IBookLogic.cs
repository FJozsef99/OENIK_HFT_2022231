using HNZ9CU_HFT_2022231.Models;
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
        public IQueryable<Book> ReadAll();
        public bool Update(Book newbook, int id);
        public bool Delete(int id);

        //non cruds:
        //Legkedveltebb kiadó könyveinek összára
        public int FavouritePublisherSumPrice();
        //Halott írók kiadói listázva
        public List<Publisher> PublishersOfDeadWriters();
        //legjobb könyv kiadójának könyveinek átlagértékelése
        public double AvgRatingOfBestBookPublisher();
        //

        //


    }
}

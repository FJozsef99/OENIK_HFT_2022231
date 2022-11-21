﻿using HNZ9CU_HFT_2022231.Models;
using HNZ9CU_HFT_2022231.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public bool Create(Publisher newbook)
        {
            try
            {
                pubrepo.Create(newbook);
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

        public IQueryable<Publisher> ReadAll()
        {
            return pubrepo.ReadAll();
        }

        public Publisher ReadOne(int id)
        {
            return pubrepo.ReadOne(id);
        }

        public bool Update(Publisher newbook, int id)
        {
            try
            {
                pubrepo.Update(newbook, id);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
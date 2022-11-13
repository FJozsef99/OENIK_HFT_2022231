﻿using HNZ9CU_HFT_2022231.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HNZ9CU_HFT_2022231.Logic
{
    public interface IAuthorLogic
    {
        public bool Create(AuthorLogic newbook);
        public AuthorLogic ReadOne(int id);
        public IQueryable<AuthorLogic> ReadAll();
        public bool Update(AuthorLogic newbook, int id);
        public bool Delete(int id);
    }
}

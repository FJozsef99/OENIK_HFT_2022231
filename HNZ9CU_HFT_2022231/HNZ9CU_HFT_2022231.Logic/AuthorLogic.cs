using HNZ9CU_HFT_2022231.Models;
using HNZ9CU_HFT_2022231.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HNZ9CU_HFT_2022231.Logic
{
    public class AuthorLogic : IAuthorLogic
    {
        protected IAuthorRepository autrepo;

        public AuthorLogic(IAuthorRepository authrep)
        {
            autrepo = authrep;
        }

        public bool Create(Author newaut)
        {
            if (newaut.Name.Length < 1)
            {
                throw new ArgumentException("The Writer's name cannot be shorter than one character!");
            }

            try
            {
                autrepo.Create(newaut);
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
                autrepo.Delete(id);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public IEnumerable<Author> ReadAll()
        {
            return autrepo.ReadAll();
        }

        public Author ReadOne(int id)
        {
            return autrepo.ReadOne(id);
        }

        public bool Update(Author newaut, int id)
        {
            try
            {
                autrepo.Update(newaut, id);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}

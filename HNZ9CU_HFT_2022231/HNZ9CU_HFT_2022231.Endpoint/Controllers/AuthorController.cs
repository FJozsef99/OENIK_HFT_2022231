using HNZ9CU_HFT_2022231.Logic;
using HNZ9CU_HFT_2022231.Models;
using HNZ9CU_HFT_2022231.Models.helperClasses;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace HNZ9CU_HFT_2022231.Endpoint.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        IAuthorLogic logic;

        public AuthorController(IAuthorLogic logic)
        {
            this.logic = logic;
        }
        [HttpGet]
        public IEnumerable<Author> ReadAll()
        {
            return this.logic.ReadAll();
        }

        [HttpGet("{id}")]
        public Author Read(int id)
        {
            return this.logic.ReadOne(id);
        }

        [HttpPost]
        public void Create([FromBody] Author value)
        {
            this.logic.Create(value);
        }

        [HttpPut]
        public void Put([FromBody] Author value, int id)
        {
            this.logic.Update(value, id);
        }

        [HttpDelete]
        public void Delete(int id)
        {
            this.logic.Delete(id);
        }

        [Route("/GoodDeadHun")]
        [HttpGet]
        public IEnumerable<DeadBookWithRating> GoodHunDeadWriters()
        {
            return this.logic.GoodHunDeadWriters();
        }
    }
}

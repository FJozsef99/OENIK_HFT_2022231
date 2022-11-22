using HNZ9CU_HFT_2022231.Logic;
using HNZ9CU_HFT_2022231.Models;
using HNZ9CU_HFT_2022231.Models.helperClasses;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace HNZ9CU_HFT_2022231.Endpoint.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        IBookLogic logic;

        public BookController(IBookLogic logic)
        {
            this.logic = logic;
        }
        [HttpGet]
        public IEnumerable<Book> ReadAll()
        {
            return this.logic.ReadAll();
        }

        [HttpGet("{id}")]
        public Book Read(int id)
        {
            return this.logic.ReadOne(id);
        }

        [HttpPost]
        public void Create([FromBody] Book value)
        {
            this.logic.Create(value);
        }

        [HttpPut]
        public void Put([FromBody] Book value, int id)
        {
            this.logic.Update(value, id);
        }

        [HttpDelete]
        public void Delete(int id)
        {
            this.logic.Delete(id);
        }

        //noncrud
        [Route("/pubsOfDeadWriters")]
        [HttpGet]
        public IEnumerable<PubName> PublishersOfDeadWriters()
        {
            return this.logic.PublishersOfDeadWriters();
        }
    }
}

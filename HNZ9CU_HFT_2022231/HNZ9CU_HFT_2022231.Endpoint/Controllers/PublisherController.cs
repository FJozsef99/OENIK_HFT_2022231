using HNZ9CU_HFT_2022231.Logic;
using HNZ9CU_HFT_2022231.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace HNZ9CU_HFT_2022231.Endpoint.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PublisherController : ControllerBase
    {
        IPublisherLogic logic;

        public PublisherController(IPublisherLogic logic)
        {
            this.logic = logic;
        }
        [HttpGet]
        public IEnumerable<Publisher> ReadAll()
        {
            return this.logic.ReadAll();
        }

        [HttpGet("{id}")]
        public Publisher Read(int id)
        {
            return this.logic.ReadOne(id);
        }

        [HttpPost]
        public void Create([FromBody] Publisher value)
        {
            this.logic.Create(value);
        }

        [HttpPut]
        public void Put([FromBody] Publisher value, int id)
        {
            this.logic.Update(value, id);
        }

        [HttpDelete]
        public void Delete(int id)
        {
            this.logic.Delete(id);
        }
    }
}

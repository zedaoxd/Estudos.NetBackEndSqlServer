using Microsoft.AspNetCore.Mvc;
using Shop.Models;

namespace Shop.Controllers
{
    // Endpoint = URL
    // http://localhost:5000
    // https://localhost:5001/categories/
    [Route("categories")]
    public class CategoryController : ControllerBase
    {
        [HttpGet]
        [Route("")]
        public string Get()
        {
            return "Get";
        }

        [HttpGet]
        [Route("{id:int}")]
        public string GetById(int id)
        {
            return $"Get {id}";
        }

        [HttpPost]
        [Route("")]
        public Category Post([FromBody]Category model)
        {
            return model;
        }

        [HttpPut]
        [Route("")]
        public string Put()
        {
            return "Put";
        }

        [HttpDelete]
        [Route("")]
        public string Delete()
        {
            return "Delete";
        }
    }
}
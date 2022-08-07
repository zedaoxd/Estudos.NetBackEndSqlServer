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
        [Route("{id:int}")]
        public Category Put(int id, [FromBody]Category model)
        {
            return model.Id == id ? model : null;
        }

        [HttpDelete]
        [Route("{id:int}")]
        public string Delete(int id)
        {
            return "Delete";
        }
    }
}
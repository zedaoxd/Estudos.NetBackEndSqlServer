using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Shop.Data;
using Shop.Models;

namespace Shop.Controllers
{
    [Route("products")]
    public class ProductController : ControllerBase
    {
        [HttpGet]
        [Route("")]
        public async Task<ActionResult<List<Product>>> Get([FromServices]DataContext context) 
        {
            var products = await context
                .Products
                .Include(x => x.Category)
                .AsNoTracking()
                .ToListAsync();

            return Ok(products);
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<ActionResult<Product>> GetById(int id, [FromServices]DataContext context)
        {
            var product = await context
                .Products
                .Include(x => x.Category)
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == id);
            
            return product != null ? Ok(product) : BadRequest("Não foi possivel encontrar o produto");
        }

        [HttpGet]
        [Route("categories/{id:int}")]
        public async Task<ActionResult<List<Product>>> GetByCategory([FromServices]DataContext context, int id)
        {
            var products = await context
                .Products.Include(x => x.Category)
                .AsNoTracking()
                .Where(x => x.CategoryId == id)
                .ToListAsync();
            
            return products != null ? Ok(products) : BadRequest("Não foi possivel encontrar produtos");
        }

        [HttpPost]
        [Route("")]
        public async Task<ActionResult<Product>> Post([FromBody]Product product, [FromServices]DataContext context) 
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try 
            {
                context.Products.Add(product);
                await context.SaveChangesAsync();
                return Ok(product);
            }
            catch 
            {
                return BadRequest("Não foi possivel salvar o produto");
            }
        }
    }
}
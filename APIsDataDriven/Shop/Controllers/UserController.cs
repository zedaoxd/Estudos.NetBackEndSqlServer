using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Shop.Data;
using Shop.Models;
using Shop.Services;

namespace Shop.Controllers
{
    [Route("users")]
    public class UserController : Controller
    {
        [HttpGet]
        [Route("")]
        [Authorize(Roles = "manager")]
        public async Task<ActionResult<List<User>>> Get([FromServices] DataContext context)
        {
            var users = await context.Users.AsNoTracking().ToListAsync();
            return users;
        }

        [HttpPut]
        [Route("{id:int}")]
        [Authorize(Roles = "manager")]
        public async Task<ActionResult<User>> Put(int id, [FromServices] DataContext context, [FromBody] User user)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (id != user.Id)
                return NotFound("Não foi possivel encontrar o usuário");

            try
            {
                context.Entry(user).State = EntityState.Modified;
                await context.SaveChangesAsync();
                return Ok(user);
            }
            catch
            {
                return BadRequest(new { message = "Não foi possivel criar o usuário" });
            }
        }

        [HttpPost]
        [Route("")]
        [AllowAnonymous]
        //[Authorize(Roles = "manager")]
        public async Task<ActionResult<User>> Post([FromServices] DataContext context, [FromBody] User model)
        {
            // verifica se os dados são válidos
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                // Força o usuário a ser sempre "Funcionário"
                model.Role = "employee";

                context.Users.Add(model);
                await context.SaveChangesAsync();

                // Esconde a senha
                model.Password = "";
                return Ok(model);
            }
            catch
            {
                return BadRequest("Não foi possivel criar o usuário");
            }
        }

        [HttpPost]
        [Route("login")]
        public async Task<ActionResult<dynamic>> Authenticate([FromServices] DataContext context, [FromBody] User model)
        {
            var user = await context.Users
                .AsNoTracking()
                .Where(x => (x.UserName == model.UserName) && (x.Password == model.Password))
                .FirstOrDefaultAsync();

            if (user == null)
                return NotFound(new { message = "Usuário ou senha inválidos" });

            var token = TokenServices.GenerateToken(user);
            user.Password = "";
            return new
            {
                user = user,
                token = token
            };
        }


    }
}
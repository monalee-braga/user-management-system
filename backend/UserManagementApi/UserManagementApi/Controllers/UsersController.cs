using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using UserManagementApi.Models;
using UserManagementApi.Service;

namespace UserManagementApi.Controllers
{
    [Authorize]
    [RoutePrefix("api/users")]
    public class UsersController : ApiController
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        // GET: api/users
        [HttpGet]
        [Route("")]
        public async Task<IHttpActionResult> GetAllUsers()
        {
            var users = await _userService.GetAllUsersAsync();  // Chamada assíncrona
            return Ok(users);
        }

        // GET: api/users/{name}
        [HttpGet]
        [Route("{name}")]
        public async Task<IHttpActionResult> GetUserByName(string name)
        {
            var user = await _userService.GetUserByNameAsync(name);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }

        // POST: api/users
        [HttpPost]
        [Route("")]
        public async Task<IHttpActionResult> CreateUser(User user)
        {
            if (user == null)
            {
                return BadRequest("User cannot be null");
            }

            await _userService.CreateUserAsync(user);
            return Ok("Usuário Criado");
        }

        // PUT: api/users/{id}
        [HttpPut]
        [Route("{id:int}")]
        public async Task<IHttpActionResult> UpdateUser(int id, User user)
        {
            if (id != user.Id)
            {
                return BadRequest("User ID mismatch");
            }

            await _userService.UpdateUserAsync(id, user);
            return Ok("Usuário atualizado");
        }
    }
}
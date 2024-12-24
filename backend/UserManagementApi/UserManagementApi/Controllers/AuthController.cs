using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using UserManagementApi.Models;
using UserManagementApi.Service;

namespace UserManagementApi.Controllers
{
    [RoutePrefix("api/auth")]
    public class AuthController : ApiController
    {
        private readonly IUserService _userService;

        // Injeção de dependência do serviço de usuário
        public AuthController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        [Route("login")]
        public async Task<IHttpActionResult> Login([FromBody] Login loginRequest)
        {
            // Validação do usuário
            User user =_userService.ValidateUser(loginRequest.Email, loginRequest.Password).Result;
            if (user == null)
            {
                return Unauthorized();  // Retorna 401 se o usuário não for válido
            }

            // Gerar o token JWT
            var token = new AuthService().GenerateJwtToken(user);
            return Ok(new { token });
        }
    }
}
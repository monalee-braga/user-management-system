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
            // Verifica se os dados de login foram enviados
            if (loginRequest == null || string.IsNullOrWhiteSpace(loginRequest.Email) || string.IsNullOrWhiteSpace(loginRequest.Password))
            {
                return BadRequest("Email and password are required.");
            }

            // Validação do usuário
            var user = await _userService.ValidateUserAsync(loginRequest.Email, loginRequest.Password);
            if (user == null)
            {
                return Unauthorized(); // Retorna 401 se o usuário não for válido
            }

            // Gerar o token JWT
            var token = new AuthService().GenerateJwtToken(user);

            // Retorna o token junto com as informações do usuário
            return Ok(new
            {
                token,
                user = new
                {
                    user.Name,
                    user.Email,
                    user.Permission,
                    user.Phone
                }
            });
        }

    }
}
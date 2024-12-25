using System;
using System.Web.Http;
using UserManagementApi.Repository;
using UserManagementApi.Service;
using Unity;
using Unity.AspNet.WebApi;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using UserManagementApi.Handlers;
using System.Configuration;

namespace UserManagementApi
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            // Configurar as rotas da Web API
            GlobalConfiguration.Configure(WebApiConfig.Register);

            // Configurar injeção de dependência com Unity
            var container = new UnityContainer();
            container.RegisterType<IUserRepository, UserRepository>();
            container.RegisterType<IUserService, UserService>();
            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);

            // Configurar autenticação JWT
            ConfigureJwtAuthentication();
        }

        private void ConfigureJwtAuthentication()
        {
            var tokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateIssuerSigningKey = true,
                ValidIssuer = ConfigurationManager.AppSettings["JwtIssuer"], // Substitua pelo seu emissor
                ValidAudience = ConfigurationManager.AppSettings["JwtAudience"], // Substitua pelo seu público
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(ConfigurationManager.AppSettings["JwtSecretKey"])) // Substitua pela sua chave secreta
            };

            var jwtHandler = new JwtSecurityTokenHandler();

            // Adiciona o handler para verificar o JWT em todas as requisições
            GlobalConfiguration.Configuration.MessageHandlers.Add(new JwtAuthenticationHandler(tokenValidationParameters, jwtHandler));
        }
    }
}



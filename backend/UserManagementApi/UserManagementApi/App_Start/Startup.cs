using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using Microsoft.IdentityModel.Tokens;
using System.Web.Http;
using Owin;
using Microsoft.Owin.Security.Jwt;

namespace UserManagementApi.App_Start
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            // Configuração de Web API
            HttpConfiguration config = new HttpConfiguration();

            // Configuração de autenticação JWT
            var issuer = "your-issuer";  // Identificador da sua aplicação
            var audience = "your-audience";  // Público para o qual o token foi emitido
            var secretKey = "your-very-strong-secret-key";  // Chave secreta para assinatura do token

            // Criando chave de segurança
            var key = Encoding.UTF8.GetBytes(secretKey);
            var signingKey = new SymmetricSecurityKey(key);

            // Configurando autenticação de token
            app.UseJwtBearerAuthentication(new JwtBearerAuthenticationOptions
            {
                TokenValidationParameters = new TokenValidationParameters
                {
                    ValidIssuer = issuer,
                    ValidAudience = audience,
                    IssuerSigningKey = signingKey,
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ClockSkew = TimeSpan.Zero  // Tolerância para o tempo de expiração do token
                }
            });

            // Configurar Web API
            WebApiConfig.Register(config);
            app.Use(config);
        }
    }
}
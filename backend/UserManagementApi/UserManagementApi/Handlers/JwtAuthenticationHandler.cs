using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net.Http;
using System.Net;
using System.Threading.Tasks;
using System.Threading;
using System.Web;
using Microsoft.IdentityModel.Tokens;

namespace UserManagementApi.Handlers
{
    public class JwtAuthenticationHandler : DelegatingHandler
    {
        private readonly TokenValidationParameters _tokenValidationParameters;
        private readonly JwtSecurityTokenHandler _jwtHandler;

        public JwtAuthenticationHandler(TokenValidationParameters tokenValidationParameters, JwtSecurityTokenHandler jwtHandler)
        {
            _tokenValidationParameters = tokenValidationParameters;
            _jwtHandler = jwtHandler;
        }

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            if (request.Headers.Authorization?.Scheme == "Bearer")
            {
                var token = request.Headers.Authorization.Parameter;

                try
                {
                    var principal = _jwtHandler.ValidateToken(token, _tokenValidationParameters, out _);
                    Thread.CurrentPrincipal = principal;
                    if (HttpContext.Current != null)
                        HttpContext.Current.User = principal;
                }
                catch (Exception)
                {
                    return new HttpResponseMessage(HttpStatusCode.Unauthorized);
                }
            }

            return await base.SendAsync(request, cancellationToken);
        }
    }

}
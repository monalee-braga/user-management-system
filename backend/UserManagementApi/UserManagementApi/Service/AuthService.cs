﻿using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Web;
using Microsoft.IdentityModel.Tokens;
using UserManagementApi.Models;

namespace UserManagementApi.Service
{
    public class AuthService
    {
        public string GenerateJwtToken(User user)
        {
            var issuer = "your-issuer";
            var audience = "your-audience";
            var secretKey = "your-very-strong-secret-key"; // Chave secreta

            var key = Encoding.UTF8.GetBytes(secretKey);
            var signingKey = new SymmetricSecurityKey(key);

            var claims = new[]
            {
                new Claim(ClaimTypes.Name, user.Name),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.Role, user.Permission.ToString())  // Admin ou Standard
            };

            var creds = new SigningCredentials(signingKey, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(issuer, audience, claims, expires: DateTime.Now.AddHours(1), signingCredentials: creds);

            var jwt = new JwtSecurityTokenHandler().WriteToken(token);
            return jwt;
        }
    }
}
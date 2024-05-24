using System.Text;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.IdentityModel.Tokens;
using JwtBearer.Models;
using JwtBearer.Config;
using System.Security.Claims;

namespace JwtBearer.Service
{
    public class TokenService
    {
        public string Generate(User user)
        {

            // Cria uma instância do JwtSecurityTokenHandler
            var handler = new JwtSecurityTokenHandler();

            var Key = Encoding.ASCII.GetBytes(Configuration.PrivateKey);

            var credentials = new SigningCredentials(new SymmetricSecurityKey(Key), SecurityAlgorithms.HmacSha256Signature);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = GeneratedClains(user),
                SigningCredentials = credentials,
                Expires = DateTime.UtcNow.AddHours(2),
            };

            // Gera o Token
            var token = handler.CreateToken(tokenDescriptor);

            // Gera uma string do token
            return handler.WriteToken(token);

        }

        private static ClaimsIdentity GeneratedClains(User user)
        {
            var ci = new ClaimsIdentity();
            ci.AddClaim(new Claim(ClaimTypes.Name, user.Email));

            foreach (var role in user.Roles)
            {
                ci.AddClaim(new Claim(ClaimTypes.Role, role));
            }
            return ci;
        }
    }
}

// Criar a API
// dotnet 

// Instalar o pacote
// dotnet add package Microsoft.AspNetCore.Authentication.JwtBearer


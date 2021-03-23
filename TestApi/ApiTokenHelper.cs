using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Application.TestApi
{
    public class ApiTokenHelper
    {
        public static string GetUserToken()
        {
            string userName = "miguel@correo.com";
            string[] roles = { "NoDefined" };

            return CreateToken(userName);
        }

        public static string GetUserTokenInvalid()
        {
            string userName = "miguel@correo.com";
            string[] roles = { "NoDefined" };

            return CreateTokenInvalid(userName);
        }

        private static string CreateToken(string userName)
        {
            var claims = new List<Claim> { new Claim(ClaimTypes.Name, userName) };

            var key = Encoding.ASCII.GetBytes("bf339b53-e085-4d2b-98b0-c64ec2bd13a8");
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims.ToArray()),
                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        private static string CreateTokenInvalid(string userName)
        {
            var claims = new List<Claim> { new Claim(ClaimTypes.Name, userName) };

            var key = Encoding.ASCII.GetBytes("bf339b53-e085-4d2b-98b0-c64ec12313a8");
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims.ToArray()),
                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}

using Application.Dtos;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Reflection;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Main.Tokens
{
    /// <summary>
    /// Implementation Generate Tokens
    /// </summary>
    /// <author>Oscar Julian Rojas Garces</author>
    /// <date>20/03/2021</date>
    public class TokenClaims : ITokenClaims
    {
        /// <summary>
        /// Instancia de configuracion aplicacion
        /// </summary>
        private readonly IConfiguration _configuration;

        /// <summary>
        /// Constructor 
        /// </summary>
        /// <param name="configuration">Instancia de configuracion</param>
        /// <author>Oscar Julian Rojas Garces</author>
        /// <date>20/03/2021</date>
        public TokenClaims(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        /// <summary>
        /// Generador de tokens 
        /// </summary>
        /// <param name="user">Usuario validado</param>
        /// <returns>Token string</returns>
        public async Task<string> GetTokenAsync(UserDto user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(this._configuration["Jwt:SecretKey"]);

            var claims = new List<Claim>();

            if (user == null)
            {
                await Task.CompletedTask;
                return null;
            }
            foreach (PropertyInfo prop in user.GetType().GetProperties())
            {
                _ = Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType;
                if (prop.Name != "Password")
                    if (prop.GetValue(user, null) != null)
                        claims.Add(new Claim(prop.Name, prop.GetValue(user, null).ToString()));
            }

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims.ToArray()),
                Expires = DateTime.UtcNow.AddHours(8),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            await Task.CompletedTask;
            return tokenHandler.WriteToken(token);
        }
    }
}

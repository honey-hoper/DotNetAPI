using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using WebAPIApp.Entities;


namespace WebAPIApp
{
    public class JWTTokenGenerator : ITokenGenerator
    {
        private readonly string SECRET;

        public JWTTokenGenerator(IConfiguration configuration)
        {
            SECRET = configuration["TokenOptions:Secret"];
        }
        
        public string GenerateToken(User user)
        {
            var claims = new[] {new Claim(ClaimTypes.NameIdentifier, user.Id.ToString())};
            var key = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(SECRET));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = credentials
            };
            var tokenHandler = new JwtSecurityTokenHandler();
            var securityToken = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(securityToken);
        }
    }
}
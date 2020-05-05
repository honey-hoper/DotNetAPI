using Microsoft.IdentityModel.Tokens;
using WebAPIApp.Entities;

namespace WebAPIApp
{
    public interface ITokenGenerator
    {
        public string GenerateToken(User user);
    }
}
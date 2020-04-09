using Microsoft.IdentityModel.Tokens;
using WebAPIApp.Models;

namespace WebAPIApp
{
    public interface ITokenGenerator
    {
        public string GenerateToken(User user);
    }
}
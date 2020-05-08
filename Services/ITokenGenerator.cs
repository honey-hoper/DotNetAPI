using System.Security.Claims;

namespace WebAPIApp
{
    public interface ITokenGenerator
    {
        public string GenerateToken(Claim[] claims);
    }
}
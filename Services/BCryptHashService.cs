namespace WebAPIApp
{
    public class BCryptHashService : IHashService
    {
        public string Generate(string text)
        {
            return BCrypt.Net.BCrypt.HashPassword(text);
        }

        public bool Match(string text, string hash)
        {
            return BCrypt.Net.BCrypt.Verify(text, hash);
        }
    }
}
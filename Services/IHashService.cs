namespace WebAPIApp
{
    public interface IHashService
    {
        public string Generate(string text);
        public bool Match(string text, string hash);
    }
}
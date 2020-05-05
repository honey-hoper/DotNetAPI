namespace WebAPIApp.Entities
{
    public class Post : BaseModel
    {
        public long Id { get; set; }
        public User Author { get; set; }
        public string Text { get; set; }
    }
}
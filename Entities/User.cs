namespace WebAPIApp.Entities
{
    public class User : BaseEntity
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Password { get; set; }
        public bool isActive { get; set; }
    }
}
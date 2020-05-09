using System.Text.Json.Serialization;

namespace WebAPIApp.DTOs.Response
{
    public class UserResObject
    {
        [JsonPropertyName("id")]
        public long Id { get; set; }
        
        [JsonPropertyName("name")]
        public string Name { get; set; }
        
        [JsonPropertyName("email")]
        public string Email { get; set; }
        
        [JsonPropertyName("phone_number")]
        public string PhoneNumber { get; set; }

        [JsonPropertyName("profile_picture_url")]
        public string ProfilePictureUrl { get; set; }

        [JsonPropertyName("is_active")]
        public bool IsActive { get; set; }

        [JsonPropertyName("created_at")]
        public string CreatedAt { get; set; }
        
        [JsonPropertyName("updated_at")]
        public string UpdatedAt { get; set; }
    }
}
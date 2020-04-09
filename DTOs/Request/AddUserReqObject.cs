using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace WebAPIApp.DTOs.Request
{
    public class AddUserReqObject
    {
        [Required]
        [JsonPropertyName("name")]
        public string Name { get; set; }
        
        [Required]
        [JsonPropertyName("email")]
        public string Email { get; set; }
        
        [JsonPropertyName("phone_number")]
        public string PhoneNumber { get; set; }
        
        [Required]
        [JsonPropertyName("password")]
        public string Password { get; set; }
    }
}
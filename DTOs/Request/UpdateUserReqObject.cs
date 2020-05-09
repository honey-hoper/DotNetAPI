using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace WebAPIApp.DTOs.Request
{
    public class UpdateUserReqObject
    {
        [Required]
        [JsonPropertyName("id")]
        public long Id { get; set; }
        
        [JsonPropertyName("name")]
        public string Name { get; set; }
        
        [JsonPropertyName("email")]
        public string Email { get; set; }
        
        [JsonPropertyName("phone_number")]
        public string PhoneNumber { get; set; }
    }
}
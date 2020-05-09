using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace WebAPIApp.DTOs.Request
{
    public class LoginUserReqObject
    {
        [Required]
        [JsonPropertyName("email")]
        public string Email { get; set; }
        
        [Required]
        [JsonPropertyName("password")]
        public string Password { get; set; }
    }
}
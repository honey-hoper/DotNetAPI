using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace WebAPIApp.DTOs.Response
{
    public class LoginResObject
    {
        [JsonPropertyName("token")]
        public string Token { get; set; }
        
        [JsonPropertyName("user")]
        public UserResObject User { get; set; }
    }
}
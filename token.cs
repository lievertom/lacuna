using System.Text.Json.Serialization;

namespace lacuna
{
    public class AuthorizationToken
    {
        [JsonPropertyName("token")]
        public string Token { get; set; }
    }
}
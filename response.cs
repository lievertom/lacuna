using System.Text.Json.Serialization;

namespace lacuna
{
    public class Response
    {
        [JsonPropertyName("secret")]
        public string Secret { get; set; }

        [JsonPropertyName("message")]
        public string Message { get; set; }

        [JsonPropertyName("status")]
        public string Status { get; set; }
    }
}
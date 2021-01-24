using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace lacuna
{
    public class Message
    {
        private static readonly HttpClient client = new HttpClient()
        {
            BaseAddress = new Uri("https://weak-system-lab.lacunasoftware.com")
        };

        public static async Task<string> GetSecretMessage(string masterToken)
        {
            var url = "https://weak-system-lab.lacunasoftware.com/api/secret";
            var request = new HttpRequestMessage(HttpMethod.Get, url);
            request.Headers.TryAddWithoutValidation("Authorization", $"Bearer {masterToken}");
            var res = await client.SendAsync(request);
            var response = await res.Content.ReadFromJsonAsync<Response>();

            if (response.Status.Equals("Success"))
                return response.Secret;
            else
                return response.Message;
        }
    }
}
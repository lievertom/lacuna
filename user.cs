using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using System.Text.Json.Serialization;

namespace lacuna
{
    public class User
    {
        [JsonPropertyName("username")]
        public string Name { get; }

        [JsonPropertyName("password")]
        public string Password { get; }

        [JsonPropertyName("email")]
        public string Email { get; }

        [JsonPropertyName("token")]
        public string Token { get; }

        public User(int userNameLength)
        {
            Password = "password";
            Email  = "lievertom@gmail.com";

            do
                Name = GenerateUserName(userNameLength);
            while (!CreateUser(this).Result);

            Token = Login(this).Result;
        }

        public static string GenerateUserName(int length)
        {
            var userName = new char[length];
            for (int i = 0; i < length; i++)
            {
                var charRandom = Convert.ToChar(new Random().Next(Convert.ToInt32('a'), Convert.ToInt32('z')+1));
                userName[i] = charRandom; 
            }
            return new string(userName);
        }

        private static readonly HttpClient client = new HttpClient()
        {
            BaseAddress = new Uri("https://weak-system-lab.lacunasoftware.com")
        };

        private static async Task<bool> CreateUser(User user)
        {
            var response = await client.PostAsJsonAsync<User>("api/users/create", user);
            response.EnsureSuccessStatusCode();
            var status = await response.Content.ReadFromJsonAsync<Response>();
            return status.Status.Equals("Success");    
        }

        private static async Task<string> Login(User user)
        {
            var response = await client.PostAsJsonAsync<User>("api/users/login", user);
            response.EnsureSuccessStatusCode();
            var token = await response.Content.ReadFromJsonAsync<AuthorizationToken>();
            return token.Token;
        }
    }
}
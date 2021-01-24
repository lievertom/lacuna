using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace lacuna
{
    class Program
    {
        private const int UserNameLength = 32;
        private const int UserNameLength2 = 31;

        static async Task Main(string[] args)
        {
            try
            {
                var user = new User(UserNameLength);
                var user2 = new User(UserNameLength2);

                var masterToken = Decolder.Decode(user, user2);

                var secretMessage = await Message.GetSecretMessage(masterToken);

                Console.WriteLine(secretMessage);
            }
            catch (HttpRequestException)
            {
                Console.WriteLine("An error occurred.");
            }
            catch (NotSupportedException) 
            {
                Console.WriteLine("The content type is not supported.");
            }
            catch (JsonException)
            {
                Console.WriteLine("Invalid JSON.");
            }
            catch (System.Exception)
            {
                Console.WriteLine("Impossible to complete program execution.");
            }

        }
    }
}
using System;
using System.Net.Http;
using System.Threading.Tasks;
using Puzzel.SmsGateway.Client.Exceptions;
using Puzzel.SmsGateway.Client.Models;

namespace Puzzel.SmsGateway.Client.Samples.ConsoleAppSimple
{
    class Program
    {
        // https://www.aspnetmonsters.com/2016/08/2016-08-27-httpclientwrong/
        private static readonly HttpClient HttpClient = new();

        public static async Task Main(string[] args)
        {
            try
            {
                // Single message
                var message = new Message("+4712345678", "This is a test");

                // Multiple messages
                // var messages = new List<Message>
                // {
                //     new("+4712345678", "This is a test"),
                //     new("+4712345678", "This is a test")
                // };

                var credentials = new SmsGatewayCredentials(1, "username", "password");
                var client = new SmsGatewayClient(HttpClient);
                var response = await client.SendAsync(credentials, message);
                Console.WriteLine($"SMS gateway response: {response}");
            }
            catch (SmsGatewayException e)
            {
                Console.WriteLine($"SMS gateway error: {e}");
            }
        }
    }
}
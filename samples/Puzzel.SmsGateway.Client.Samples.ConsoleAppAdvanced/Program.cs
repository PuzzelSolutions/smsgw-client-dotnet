using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Puzzel.SmsGateway.Client.Samples.ConsoleAppAdvanced
{
    class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        private static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureServices((context, services) =>
                {
                    // Add Puzzel SMS gateway client
                    services.Configure<SmsGatewayCredentials>(context.Configuration.GetSection("SmsGatewayCredentials"));
                    services.AddHttpClient<ISmsGatewayClient, SmsGatewayClient>();
                    services.AddHostedService<SmsService>();
                });
    }
}
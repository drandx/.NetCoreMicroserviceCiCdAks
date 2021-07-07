using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace CustomerApi.WebJobs.WebJobOne
{
    class Program
    {
        static async Task Main(string[] args)
        {
            
             Console.WriteLine("Hello World!");
             var builder = new HostBuilder();
             builder.UseEnvironment(EnvironmentName.Development);
             builder.ConfigureWebJobs(b =>
             {
                 b.AddAzureStorageCoreServices();
             });
            builder.ConfigureLogging(b =>
            {
                b.AddConsole();
            });
            builder.ConfigureWebJobs(b =>
            {
                b.AddAzureStorageCoreServices();
                b.AddAzureStorage();
            });
            var host = builder.Build();
            using (host)
             {
                 await host.RunAsync();
             }
        }
    }
    }

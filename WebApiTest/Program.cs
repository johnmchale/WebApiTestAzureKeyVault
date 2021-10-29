using Azure.Identity;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using System;

namespace WebApiTest
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureAppConfiguration((context, config) =>
                {
                    var builtConfig = config.Build();
                    config.AddAzureKeyVault(
                        new Uri($"https://{builtConfig["AzureKeyVault:Name"]}.vault.azure.net/"),
                        new ClientSecretCredential(
                            builtConfig["AzureKeyVault:TenantId"],
                            builtConfig["AzureKeyVault:ClientId"],
                            builtConfig["AzureKeyVault:ClientSecret"]));
                })
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}

using System;
using System.Net.Http;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Text;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using MatBlazor;
using InventoryApp.Database;

namespace InventoryApp
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");

            builder.Services
                .AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) })
                .AddSingleton<ICosmosDbService>(
                    await InitializeCosmosClientInstanceAsync(builder.Configuration.GetSection("CosmosDb"))
                )
                .AddMatBlazor();
            
            
            await builder.Build().RunAsync();
        }

        /// <summary>
        /// Creates a Cosmos DB database and a container with the specified partition key. 
        /// </summary>
        /// <returns></returns>
        private static async Task<CosmosDbService> InitializeCosmosClientInstanceAsync(IConfigurationSection configurationSection)
        {
            var databaseName = configurationSection.GetSection("DatabaseName").Value;
            var containerName = configurationSection.GetSection("ContainerName").Value;
            var account = configurationSection.GetSection("Account").Value;
            var key = configurationSection.GetSection("Key").Value;
            var client = new Microsoft.Azure.Cosmos.CosmosClient(account, key);
            var cosmosDbService = new CosmosDbService(client, databaseName, containerName);
            // var database = await client.CreateDatabaseIfNotExistsAsync(databaseName);
            // await database.Database.CreateContainerIfNotExistsAsync(containerName, "/id");

            return cosmosDbService;
        }
    }
}

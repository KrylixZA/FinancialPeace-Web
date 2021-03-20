using System;
using System.Net.Http;
using System.Threading.Tasks;
using FinancialPeace.Web.HttpClients;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;

namespace FinancialPeace.Web
{
    public class Program
    {
        private const string ApiBaseUrl = "http://localhost:5000";

        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");
            builder.Services.AddScoped(
                _ => new HttpClient
                {
                    BaseAddress = new Uri(builder.HostEnvironment.BaseAddress)
                });
            builder.Services.AddScoped(
                _ => new CurrenciesHttpClient(
                    ApiBaseUrl,
                    new AuthenticationHttpClient(new HttpClient
                    {
                        BaseAddress = new Uri(ApiBaseUrl)
                    })));
            await builder.Build().RunAsync();
        }
    }
}
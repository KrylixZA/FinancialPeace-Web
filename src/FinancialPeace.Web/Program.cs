using System;
using System.Net.Http;
using System.Threading.Tasks;
using Blazored.Modal;
using Blazored.Toast;
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
            var authenticationHttpClient = new AuthenticationHttpClient(new HttpClient
            {
                BaseAddress = new Uri(ApiBaseUrl)
            });
            
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");
            builder.Services.AddBlazoredToast();
            builder.Services.AddBlazoredModal();
            builder.Services.AddScoped(
                _ => new HttpClient
                {
                    BaseAddress = new Uri(builder.HostEnvironment.BaseAddress)
                });
            builder.Services.AddScoped(_ => new CurrenciesHttpClient(ApiBaseUrl, authenticationHttpClient));
            builder.Services.AddScoped(_ => new BudgetsHttpClient(ApiBaseUrl, authenticationHttpClient));
            builder.Services.AddScoped(_ => new ExpenseCategoriesHttpClient(ApiBaseUrl, authenticationHttpClient));
            
            await builder.Build().RunAsync();
        }
    }
}
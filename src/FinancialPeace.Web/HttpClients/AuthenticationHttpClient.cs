using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using FinancialPeace.Web.Models.Responses;

namespace FinancialPeace.Web.HttpClients
{
    public class AuthenticationHttpClient
    {
        private const string ControllerRoute = "/tokens";

        private readonly HttpClient _httpClient;

        public AuthenticationHttpClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<string> GetTokenAsync()
        {
            try
            {
                var response = await _httpClient.GetFromJsonAsync<JwtResponse>(ControllerRoute);
                return response?.AccessToken ?? throw new InvalidOperationException();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using FinancialPeace.Web.Models;
using Newtonsoft.Json;

namespace FinancialPeace.Web.HttpClients
{
    public class CurrencyHttpClient
    {
        private const string ControllerRoute = "currencies";

        private readonly string _apiBaseUrl;
        private readonly AuthenticationHttpClient _authenticationHttpClient;

        public CurrencyHttpClient(string apiBaseUrl, AuthenticationHttpClient authenticationHttpClient)
        {
            _apiBaseUrl = apiBaseUrl;
            _authenticationHttpClient = authenticationHttpClient;
        }

        public async Task<IEnumerable<Currency>?> GetCurrenciesAsync()
        {
            var token = await _authenticationHttpClient.GetTokenAsync();
            var request = new HttpRequestMessage
            {
                Headers =
                {
                    {"Authorization", $"Bearer {token}"}
                },
                Method = HttpMethod.Get,
                RequestUri = new Uri($"{_apiBaseUrl}/{ControllerRoute}")
            };
            var httpClient = new HttpClient();
            var response = await httpClient.SendAsync(request);
            response.EnsureSuccessStatusCode();
            var currencies = JsonConvert.DeserializeObject<GetCurrencyResponse>(await response.Content.ReadAsStringAsync());
            return currencies.Currencies;
        }
    }
}
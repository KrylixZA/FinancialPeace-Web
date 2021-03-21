using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using FinancialPeace.Web.Models;
using FinancialPeace.Web.Models.Requests;
using FinancialPeace.Web.Models.Responses;
using Newtonsoft.Json;

namespace FinancialPeace.Web.HttpClients
{
    public class CurrenciesHttpClient
    {
        private const string ControllerRoute = "currencies";

        private readonly string _apiBaseUrl;
        private readonly AuthenticationHttpClient _authenticationHttpClient;

        public CurrenciesHttpClient(string apiBaseUrl, AuthenticationHttpClient authenticationHttpClient)
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

        public async Task AddCurrencyAsync(AddCurrencyRequest request)
        {
            var token = await _authenticationHttpClient.GetTokenAsync();
            var apiRequest = new HttpRequestMessage
            {
                Headers =
                {
                    {"Authorization", $"Bearer {token}"}
                },
                Method = HttpMethod.Post,
                RequestUri = new Uri($"{_apiBaseUrl}/{ControllerRoute}"),
                Content = new StringContent(
                    JsonConvert.SerializeObject(request),
                    Encoding.UTF8,
                    "application/json")
                
            };
            var httpClient = new HttpClient();
            var response = await httpClient.SendAsync(apiRequest);
            response.EnsureSuccessStatusCode();
        }
    }
}
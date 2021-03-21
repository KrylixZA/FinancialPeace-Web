using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using FinancialPeace.Web.Models;
using FinancialPeace.Web.Models.Responses;
using Newtonsoft.Json;

namespace FinancialPeace.Web.HttpClients
{
    public class ExpenseCategoriesHttpClient
    {
        private const string ControllerRoute = "expenseCategories";

        private readonly string _apiBaseUrl;
        private readonly AuthenticationHttpClient _authenticationHttpClient;

        public ExpenseCategoriesHttpClient(string apiBaseUrl, AuthenticationHttpClient authenticationHttpClient)
        {
            _apiBaseUrl = apiBaseUrl;
            _authenticationHttpClient = authenticationHttpClient;
        }

        public async Task<IEnumerable<ExpenseCategory>?> GetExpenseCategoriesAsync()
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
            var currencies = JsonConvert.DeserializeObject<GetExpenseCategoriesResponse>(await response.Content.ReadAsStringAsync());
            return currencies.ExpenseCategories;
        }
    }
}
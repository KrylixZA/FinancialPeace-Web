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
    public class BudgetsHttpClient
    {
        private const string ControllerRoute = "budgets";
        private readonly Guid _userId = new("86ee1336-285a-4329-a7ea-acf497a237b0");

        private readonly string _apiBaseUrl;
        private readonly AuthenticationHttpClient _authenticationHttpClient;

        public BudgetsHttpClient(string apiBaseUrl, AuthenticationHttpClient authenticationHttpClient)
        {
            _apiBaseUrl = apiBaseUrl;
            _authenticationHttpClient = authenticationHttpClient;
        }

        public async Task<IEnumerable<Expense>> GetBudgetForUserAsync()
        {
            var token = await _authenticationHttpClient.GetTokenAsync();
            var request = new HttpRequestMessage
            {
                Headers =
                {
                    {"Authorization", $"Bearer {token}"}
                },
                Method = HttpMethod.Get,
                RequestUri = new Uri($"{_apiBaseUrl}/{ControllerRoute}/user/{_userId}")
            };
            var httpClient = new HttpClient();
            var response = await httpClient.SendAsync(request);
            response.EnsureSuccessStatusCode();
            var currencies = JsonConvert.DeserializeObject<GetBudgetForUserResponse>(await response.Content.ReadAsStringAsync());
            return currencies.Expenses;
        }

        public async Task CreateExpenseForUserAsync(CreateExpenseRequest request)
        {
            var token = await _authenticationHttpClient.GetTokenAsync();
            var apiRequest = new HttpRequestMessage
            {
                Headers =
                {
                    {"Authorization", $"Bearer {token}"}
                },
                Method = HttpMethod.Post,
                RequestUri = new Uri($"{_apiBaseUrl}/{ControllerRoute}/user/{_userId}"),
                Content = new StringContent(
                    JsonConvert.SerializeObject(request),
                    Encoding.UTF8,
                    "application/json")
            };
            var httpClient = new HttpClient();
            var response = await httpClient.SendAsync(apiRequest);
            response.EnsureSuccessStatusCode();
        }

        public async Task DeleteExpenseForUserAsync(Guid expenseId)
        {
            var token = await _authenticationHttpClient.GetTokenAsync();
            var apiRequest = new HttpRequestMessage
            {
                Headers =
                {
                    {"Authorization", $"Bearer {token}"}
                },
                Method = HttpMethod.Delete,
                RequestUri = new Uri($"{_apiBaseUrl}/{ControllerRoute}/user/{_userId}/expense/{expenseId}")
                
            };
            var httpClient = new HttpClient();
            var response = await httpClient.SendAsync(apiRequest);
            response.EnsureSuccessStatusCode();
        }

        public async Task UpdateExpenseForUserAsync(Guid expenseId, UpdateExpenseRequest request)
        {
            var token = await _authenticationHttpClient.GetTokenAsync();
            var apiRequest = new HttpRequestMessage
            {
                Headers =
                {
                    {"Authorization", $"Bearer {token}"}
                },
                Method = HttpMethod.Patch,
                RequestUri = new Uri($"{_apiBaseUrl}/{ControllerRoute}/user/{_userId}"),
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
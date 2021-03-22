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
    public class ExpenseCategoriesHttpClient
    {
        private const string ControllerRoute = "expenseCategories";
        private readonly Guid _userId = new("86ee1336-285a-4329-a7ea-acf497a237b0");

        private readonly string _apiBaseUrl;
        private readonly AuthenticationHttpClient _authenticationHttpClient;

        public ExpenseCategoriesHttpClient(string apiBaseUrl, AuthenticationHttpClient authenticationHttpClient)
        {
            _apiBaseUrl = apiBaseUrl;
            _authenticationHttpClient = authenticationHttpClient;
        }

        public async Task<IEnumerable<ExpenseCategory>> GetExpenseCategoriesAsync()
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
        
        public async Task<IEnumerable<ExpenseCategory>> GetExpenseCategoriesForUserAsync()
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
            var currencies = JsonConvert.DeserializeObject<GetExpenseCategoriesForUserResponse>(await response.Content.ReadAsStringAsync());
            return currencies.ExpenseCategories;
        }

        public async Task AddExpenseCategoryAsync(AddExpenseCategoryRequest request)
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
        
        public async Task DeleteExpenseCategoryAsync(Guid expenseCategoryId)
        {
            var token = await _authenticationHttpClient.GetTokenAsync();
            var apiRequest = new HttpRequestMessage
            {
                Headers =
                {
                    {"Authorization", $"Bearer {token}"}
                },
                Method = HttpMethod.Delete,
                RequestUri = new Uri($"{_apiBaseUrl}/{ControllerRoute}/user/{_userId}/expense/{expenseCategoryId}")
                
            };
            var httpClient = new HttpClient();
            var response = await httpClient.SendAsync(apiRequest);
            response.EnsureSuccessStatusCode();
        }
    }
}
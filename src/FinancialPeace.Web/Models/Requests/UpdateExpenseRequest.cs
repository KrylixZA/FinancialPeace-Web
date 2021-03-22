using Newtonsoft.Json;

namespace FinancialPeace.Web.Models.Requests
{
    public class UpdateExpenseRequest
    {
        [JsonProperty("expenseCategoryName")]
        public string ExpenseCategoryName { get; set; }
        
        [JsonProperty("countryCurrencyCode")]
        public string CountryCurrencyCode { get; set; }
        
        [JsonProperty("value")]
        public double Value { get; set; }
    }
}
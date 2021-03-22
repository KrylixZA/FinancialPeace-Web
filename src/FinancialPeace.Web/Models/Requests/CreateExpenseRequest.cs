using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace FinancialPeace.Web.Models.Requests
{
    public class CreateExpenseRequest
    {
        [Required]
        [JsonProperty("expenseCategoryName", Required = Required.Always)]
        public string ExpenseCategoryName { get; set; } = null!;

        [Required]
        [JsonProperty("countryCurrencyCode", Required = Required.Always)]
        public string CountryCurrencyCode { get; set; } = null!;

        [Required]
        [JsonProperty("value", Required = Required.Always)]
        public double Value { get; set; }
    }
}
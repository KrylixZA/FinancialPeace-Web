using System;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace FinancialPeace.Web.Models
{
    public class Expense
    {
        [Required]
        [JsonProperty("budgetId", Required = Required.Always)]
        public Guid BudgetId { get; set; }
        
        [Required]
        [JsonProperty("userId", Required = Required.Always)]
        public Guid UserId { get; set; }
        
        [Required]
        [JsonProperty("expenseId", Required = Required.Always)]
        public Guid ExpenseId { get; set; }
        
        [Required]
        [JsonProperty("displayName", Required = Required.Always)]
        public string DisplayName { get; set; } = null!;

        [Required]
        [JsonProperty("countryCurrencyCode", Required = Required.Always)]
        public string CountryCurrencyCode { get; set; } = null!;

        [Required]
        [JsonProperty("value", Required = Required.Always)]
        public double Value { get; set; }
    }
}
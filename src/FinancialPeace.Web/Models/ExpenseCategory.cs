using System;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace FinancialPeace.Web.Models
{
    public class ExpenseCategory
    {
        [Required]
        [JsonProperty("expenseCategoryId", Required = Required.Always)]
        public Guid ExpenseCategoryId { get; set; }
        
        [Required]
        [JsonProperty("expenseCategoryName", Required = Required.Always)]
        public string ExpenseCategoryName { get; set; } = string.Empty;
    }
}
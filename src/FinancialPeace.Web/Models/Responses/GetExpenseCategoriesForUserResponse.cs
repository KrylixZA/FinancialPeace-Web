using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace FinancialPeace.Web.Models.Responses
{
    public class GetExpenseCategoriesForUserResponse
    {
        [Required]
        [JsonProperty("userId", Required = Required.Always)]
        public Guid UserId { get; set; }
        
        [JsonProperty("expenseCategories", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public IEnumerable<ExpenseCategory> ExpenseCategories { get; set; }
    }
}
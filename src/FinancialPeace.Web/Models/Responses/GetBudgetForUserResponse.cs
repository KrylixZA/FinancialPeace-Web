using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace FinancialPeace.Web.Models.Responses
{
    public class GetBudgetForUserResponse
    {
        [Required]
        [JsonProperty("userId", Required = Required.Always)]
        public Guid UserId { get; set; }

        [JsonProperty("expenses", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public IEnumerable<Expense> Expenses { get; set; }
    }
}
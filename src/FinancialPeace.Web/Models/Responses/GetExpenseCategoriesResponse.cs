using System.Collections.Generic;
using Newtonsoft.Json;

namespace FinancialPeace.Web.Models.Responses
{
    public class GetExpenseCategoriesResponse
    {
        [JsonProperty("expenseCategories", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public IEnumerable<ExpenseCategory>? ExpenseCategories { get; set; }
    }
}
using System;
using Newtonsoft.Json;

namespace FinancialPeace.Web.Models.Requests
{
    public class AddExpenseCategoryRequest : ExpenseCategory
    {
        [JsonIgnore]
        public new Guid ExpenseCategoryId => Guid.Empty;
    }
}
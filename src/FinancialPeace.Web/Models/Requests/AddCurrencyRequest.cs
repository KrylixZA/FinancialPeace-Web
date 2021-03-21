using System;
using Newtonsoft.Json;

namespace FinancialPeace.Web.Models.Requests
{
    public class AddCurrencyRequest : Currency
    {
        [JsonIgnore]
        public new Guid CurrencyId => Guid.Empty;
    }
}
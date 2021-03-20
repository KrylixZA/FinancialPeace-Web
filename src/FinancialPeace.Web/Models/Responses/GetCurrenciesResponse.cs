using System.Collections.Generic;
using Newtonsoft.Json;

namespace FinancialPeace.Web.Models.Responses
{
    public class GetCurrencyResponse
    {
        [JsonProperty("currencies", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public IEnumerable<Currency>? Currencies { get; set; }
    }
}
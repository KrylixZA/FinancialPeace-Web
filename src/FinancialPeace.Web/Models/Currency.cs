using System;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using Newtonsoft.Json;

namespace FinancialPeace.Web.Models
{
    [ExcludeFromCodeCoverage]
    public class Currency
    {
        [Required]
        [JsonProperty("currencyId", Required = Required.Always)]
        public Guid CurrencyId { get; set; }

        [Required]
        [JsonProperty("countryCurrencyCode", Required = Required.Always)]
        public string CountryCurrencyCode { get; set; } = null!;

        [Required]
        [JsonProperty("name", Required = Required.Always)]
        public string Name { get; set; } = null!;

        [JsonProperty("country", NullValueHandling = NullValueHandling.Ignore)]
        public string? Country { get; set; }

        [Required]
        [JsonProperty("randExchangeRate", Required = Required.Always)]
        public double RandExchangeRate { get; set; }
    }
}
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace FinancialPeace.Web.Models.Responses
{
    public class JwtResponse
    {
        [JsonProperty("accessToken", Required = Required.Always)]
        [Required]
        public string AccessToken { get; set; }
        
        [JsonProperty("expiresInMinutes", Required = Required.Always)]
        [Required]
        public int ExpiresInMinutes { get; set; }
    }
}
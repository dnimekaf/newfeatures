using Newtonsoft.Json;

namespace CurrencyConverter.ConverterGateway.Models
{
    public class Currency
    {
        [JsonProperty("currencyName")]
        public string CurrencyName { get; init; }
        
        [JsonProperty("currencySymbol")]
        public string CurrencySymbol { get; init; }
        
        [JsonProperty("id")]
        public string Id { get; init; }

        public override string ToString()
        {
            return $"{CurrencyName}, Symbol = {CurrencySymbol}, Id = {Id}";
        }
    }
}
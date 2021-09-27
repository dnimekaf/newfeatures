using Newtonsoft.Json;

namespace CurrencyConverter.ConverterGateway.Models
{
    //NEW FEATURE
    public class Country
    {
        [JsonProperty("alpha3")]
        public string Alpha3 { get; init; }
        
        [JsonProperty("currencyId")]
        public string CurrencyId { get; init; }
        
        [JsonProperty("currencyName")]
        public string CurrencyName { get; init; }
        
        [JsonProperty("currencySymbol")]
        public string CurrencySymbol { get; init; }
        
        [JsonProperty("id")]
        public string Id { get; init; }
        
        [JsonProperty("name")]
        public string Name { get; init; }


        public override string ToString()
        {
            return $"{Name}, id = {Id}, Currency name = {CurrencyName}, Symbol = {CurrencySymbol}";
        }
    }
}
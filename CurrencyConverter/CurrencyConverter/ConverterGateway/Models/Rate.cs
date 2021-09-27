using Newtonsoft.Json;

namespace CurrencyConverter.ConverterGateway.Models
{
    public class Rate
    {
        [JsonProperty("id")]
        public string Id { get; init; }
        
        [JsonProperty("val")]
        public decimal Val { get; init; }
        
        [JsonProperty("to")]
        public string To { get; init; }
        
        [JsonProperty("fr")]
        public string From { get; init; }

        public override string ToString()
        {
            return $"{From} to {To} conversation rate is {Val}";
        }
    }
}
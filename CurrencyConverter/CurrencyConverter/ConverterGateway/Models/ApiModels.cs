using System.Collections.Generic;

namespace CurrencyConverter.ConverterGateway.Models
{
    //NEW FEATURE
    public record CountryResult(Dictionary<string, Country> results);
    
    public record CurrencyResult(Dictionary<string, Currency> results);

    public record RateResult(Dictionary<string, Rate> results);
}
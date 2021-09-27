using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using CurrencyConverter.ConverterGateway.Models;
using Newtonsoft.Json;

namespace CurrencyConverter.ConverterGateway
{
    public class ConverterGateway : IConverterGateway
    {
        private readonly ApiConfiguration _configuration;
        private readonly HttpClient _client;

        public ConverterGateway(ApiConfiguration configuration, HttpClient client)
        {
            _configuration = configuration;
            _client = client;
        }

        public async Task<IEnumerable<Country>> Countries(CancellationToken token = default)
        {
            var request = await _client.GetAsync(CreateUri("countries"), token);
            request.EnsureSuccessStatusCode();
            var result = JsonConvert.DeserializeObject<CountryResult>(await request.Content.ReadAsStringAsync(token));
            return result?.results.Values ?? Enumerable.Empty<Country>();
        }

        public async Task<IEnumerable<Currency>> Currencies(CancellationToken token = default)
        {
            var request = await _client.GetAsync(CreateUri("currencies"), token);
            request.EnsureSuccessStatusCode();
            var result = JsonConvert.DeserializeObject<CurrencyResult>(await request.Content.ReadAsStringAsync(token));
            return result?.results.Values ?? Enumerable.Empty<Currency>();  
        }

        public async Task<(Rate, Rate)> GetConversationRates(string firstId, string secondId, CancellationToken token = default)
        {
            if (string.IsNullOrEmpty(firstId))
            {
                throw new ArgumentNullException(firstId);
            }

            if (string.IsNullOrEmpty(secondId))
            {
                throw new ArgumentNullException(secondId);
            }
            
            var query = $"q={firstId.ToUpper()}_{secondId.ToUpper()},{secondId.ToUpper()}_{firstId.ToUpper()}";
            var request = await _client.GetAsync(CreateUri("convert", query), token);
            var result = JsonConvert.DeserializeObject<RateResult>(await request.Content.ReadAsStringAsync(token));

            if (result?.results != null)
            {
                return (result.results.First().Value, result.results.Last().Value);
            }
            return (null, null);
        }

        private Uri CreateUri(string method, string query = null)
        {
            if (string.IsNullOrEmpty(query))
            {
                return new Uri($"{_configuration.Endpoint}/{method}?apiKey={_configuration.Key}");
            }
            return new Uri($"{_configuration.Endpoint}/{method}?{query}&apiKey={_configuration.Key}");
        }
    }
}
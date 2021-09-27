using System.IO;
using System.Net.Http;
using CurrencyConverter.ConverterGateway;
using CurrencyConverter.ConverterGateway.Models;
using CurrencyConverter.Services;
using Microsoft.Extensions.Configuration;

//NEW FEATURE (no Main)

var configuration = GetApiConfiguration();
var converter = new ConverterGateway(configuration,new HttpClient());

//NEW FEATURE
ConverterService service = new(converter);
await service.Execute();
    
static ApiConfiguration GetApiConfiguration()
{
    var builder = new ConfigurationBuilder()
        .SetBasePath(Directory.GetCurrentDirectory())
        .AddJsonFile("appsettings.json", optional: false);

    var config = builder.Build();
    return new ApiConfiguration(config["APIKey"], config["APIEndpoint"]);
}
    

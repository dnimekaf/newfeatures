using CurrencyConverter.ConverterGateway;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace CurrencyConverter.Services
{
    internal class PrintCountriesCommand : ICommand
    {
        private readonly IConverterGateway _gateway;

        public PrintCountriesCommand(IConverterGateway gateway)
        {
            _gateway = gateway;
        }


        public async Task Execute()
        {
            var countries = await _gateway.Countries();
            foreach (var country in countries.OrderBy(x => x.Name))
            {
                Console.WriteLine(country);
            }
        }
    }
}

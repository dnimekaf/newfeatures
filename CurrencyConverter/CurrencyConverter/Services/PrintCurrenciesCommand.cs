using CurrencyConverter.ConverterGateway;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace CurrencyConverter.Services
{
    internal class PrintCurrenciesCommand : ICommand
    {
        private readonly IConverterGateway _gateway;

        public PrintCurrenciesCommand(IConverterGateway gateway)
        {
            _gateway = gateway;
        }

        public async Task Execute()
        {
            var currencies = await _gateway.Currencies();
            foreach (var country in currencies.OrderBy(x => x.CurrencyName))
            {
                Console.WriteLine(country);
            }
        }
    }
}

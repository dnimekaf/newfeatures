using CurrencyConverter.ConverterGateway;
using System;
using System.Threading.Tasks;

namespace CurrencyConverter.Services
{
    internal class ConvertCommand : ICommand
    {
        private readonly IConverterGateway _gateway;

        public ConvertCommand(IConverterGateway gateway)
        {
            _gateway = gateway;
        }

        public async Task Execute()
        {
            Console.Write("\nEnter currency you wish to convert from (i.e. USD): ");
            var from = Console.ReadLine();
            Console.Write("\nEnter currency you wish to convert to (i.e. RUB): ");
            var to = Console.ReadLine();
            Console.Write($"Enter amount of {from} you wish to convert: ");
            var amountStr = Console.ReadLine();
            if (decimal.TryParse(amountStr, out var amount) == false)
            {
                Console.WriteLine("Wrong amount value");
                return;
            }

            var (f, _) = await _gateway.GetConversationRates(from, to);
            if (f != null)
            {
                Console.WriteLine($"Convert rate from {from} to {to} is {f.Val}");
                var result = amount * f.Val;
                Console.WriteLine($"{amount} {from} is {result}");
            }
        }
    }
}

using System;
using System.Threading.Tasks;
using CurrencyConverter.ConverterGateway;

namespace CurrencyConverter.Services
{
    public class ConverterService
    {
        private readonly IConverterGateway _gateway;

        public ConverterService(IConverterGateway gateway)
        {
            _gateway = gateway;
        }

        public async Task Execute()
        {
            Console.WriteLine($"Select an action:\n" +
                              $"1. View all countries and their currencies\n" +
                              $"2. View all currencies with codes\n" +
                              $"3. Convert an amount from one currency to another\n");
            
            var input = Console.ReadLine();
            var command = GetCommand(input);
            await command.Execute();                       
        }

        //NEW FEATURE
        private ICommand GetCommand(object command) =>
            command switch
            {
                string cmd when cmd.StartsWith("1") => new PrintCountriesCommand(_gateway),
                string cmd when cmd.StartsWith("2") => new PrintCurrenciesCommand(_gateway),
                string cmd when cmd.StartsWith("3") => new ConvertCommand(_gateway),
                _ => throw new ArgumentException("Not valid command")
            };          
    }
}
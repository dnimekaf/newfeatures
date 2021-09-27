using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using CurrencyConverter.ConverterGateway.Models;

namespace CurrencyConverter.ConverterGateway
{
    public interface IConverterGateway
    {
        Task<IEnumerable<Country>> Countries(CancellationToken token = default);

        Task<IEnumerable<Currency>> Currencies(CancellationToken token = default);

        Task<(Rate, Rate)> GetConversationRates(string firstId, string secondId, CancellationToken token = default);
    }
}
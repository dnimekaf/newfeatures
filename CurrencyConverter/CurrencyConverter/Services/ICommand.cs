using System.Threading.Tasks;

namespace CurrencyConverter.Services
{
    internal interface ICommand
    {
        Task Execute();
    }
}


namespace CashRegister
{
    public interface ILogger
    {
        void LogError(string error);

        void LogOrder(object sender, Order order);
    }
}

using CashRegisterUI;

namespace CashRegisterUi
{
    public static class CashRegisterUiExtensions
    {
        public static string Prompt(this IConsoleInterface consoleInterface, string message)
        {
            consoleInterface.WriteLine(message);
            return consoleInterface.ReadLine();
        }
    }
}

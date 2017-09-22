using CashRegister;
using CashRegisterUI;

namespace CashRegisterUi
{
    public class Program
    {
        static void Main(string[] args)
        {
            var register = new CashRegister.CashRegister();

            var registerUi = new CashRegisterUi { Register = register, ConsoleInterface = new ConsoleInterface() };

            registerUi.RunCashRegister();
        }
    }
}

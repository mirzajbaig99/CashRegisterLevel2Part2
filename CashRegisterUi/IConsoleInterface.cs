namespace CashRegisterUI
{
    public interface IConsoleInterface
    {
        string ReadLine();
        void Write(string format, params object[] args);
        void Write(string output);
        void WriteLine(string format, params object[] args);
        void WriteLine(string output);
    }
}

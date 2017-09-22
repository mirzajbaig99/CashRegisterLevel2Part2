using System;
using System.Diagnostics.CodeAnalysis;

namespace CashRegisterUI
{
    /// <summary>
    /// ConsoleInterface implements the IConsoleInterface interface to encapsulate the Console functionality (for testing)
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class ConsoleInterface : IConsoleInterface
    {
        #region IConsoleInterface implementation

        /// <summary>
        /// provides the Console ReadLine functionality
        /// </summary>
        /// <returns>line read from the console</returns>
        public string ReadLine()
        {
            return Console.ReadLine();
        }

        /// <summary>
        /// provides the Console Write functionality for a string input
        /// </summary>
        /// <param name="output">string to be written to the console</param>
        public void Write(string output)
        {
            Console.Write(output);
        }

        /// <summary>
        /// provides the Console Write functionality for a format string plus parameters
        /// </summary>
        /// <param name="format">format string</param>
        /// <param name="args">parameters for the format string</param>
        public void Write(string format, params object[] args)
        {
            Console.Write(format, args);
        }

        /// <summary>
        /// provides the Console WriteLine functionality for a string input
        /// </summary>
        /// <param name="output">string to be written to the console</param>
        public void WriteLine(string output)
        {
            Console.WriteLine(output);
        }

        /// <summary>
        /// provides the Console WriteLine functionality for a format string plus parameters
        /// </summary>
        /// <param name="format">format string</param>
        /// <param name="args">parameters for the format string</param>
        public void WriteLine(string format, params object[] args)
        {
            Console.WriteLine(format, args);
        }

        #endregion
    }
}

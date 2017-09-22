using System;

namespace CashRegister
{
    /// <summary>
    /// Logs orders and errors
    /// </summary>
    public class Logger : ILogger
    {
        //TODO: Singleton DP Exercise - Update CashRegister’s Logger class to implement the singleton pattern

        /// <summary>
        /// logs an error message
        /// </summary>
        /// <param name="error">error message to be logged</param>
        public void LogError(string error)
        {
           Console.WriteLine(error);
        }

        /// <summary>
        /// logs an order
        /// </summary>
        /// <param name="sender">object that published the OrderUp event</param>
        /// <param name="order">order to log (implicitly uses ToString() method)</param>
        public void LogOrder(object sender, Order order)
        {
            const string OrderMessage = @"\nOrder is ready! - {0}";
            Console.WriteLine(OrderMessage, order);
        }
    }
}

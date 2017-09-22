
using System;

namespace CashRegister
{
    public interface ITakesOrder
    {
        /// <summary>
        /// OrderUp handles order events
        /// </summary>
        event EventHandler<Order> OrderUp;

        void Order(Order order);

        void OrderCallback(Object order);
    }
}

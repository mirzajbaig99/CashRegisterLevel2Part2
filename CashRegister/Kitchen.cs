using System;

namespace CashRegister
{
    /// <summary>
    /// Kitchen handles food orders
    /// </summary>
    public class Kitchen : ITakesOrder
    {
        /// <summary>
        /// allows for an event to be published when the order is ready
        /// </summary>
        public event EventHandler<Order> OrderUp;

        /// <summary>
        /// Order processes a food order
        /// </summary>
        /// <param name="order">a food order</param>
        public void Order(Order order)
        {
            if (!(order is Food))
            {
                throw new ArgumentException("Kitchen only takes food orders", "order");
            }
            OrderCallback(order);
        }

        /// <summary>
        /// publishes the order-up event
        /// </summary>
        /// <param name="order">the order that's ready</param>
        public void OrderCallback(Object order)
        {
            OrderUp(this, (Order)order);
        }
    }
}

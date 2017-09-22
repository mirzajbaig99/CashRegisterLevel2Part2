using System;

namespace CashRegister
{
    /// <summary>
    /// Bar handles drink orders
    /// </summary>
    public class Bar : ITakesOrder
    {
        /// <summary>
        /// allows for an event to be published when the order is ready
        /// </summary>
        public event EventHandler<Order> OrderUp;

        /// <summary>
        /// Order places a drink order
        /// </summary>
        /// <param name="order">a drink order</param>
        public void Order(Order order)
        {
            if (!(order is Drink))
            {
                throw new ArgumentException("Bar only takes drink orders", "order");
            }
            throw new NotImplementedException("The bartender's late for work");
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

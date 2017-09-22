
namespace CashRegister
{
    /// <summary>
    /// parent class for drink and food menu items
    /// </summary>
    public abstract class Order
    {
        /// <summary>
        /// Name of the menu item
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// price of the menu item
        /// </summary>
        public virtual decimal Price { get; set; }

        /// <summary>
        /// The temperature at which the order should be served
        /// </summary>
        public virtual decimal Temperature { get; set; }

        /// <summary>
        /// tax on the menu item (calculated by child class)
        /// </summary>
        public virtual decimal Tax
        {
            get
            {
                return Price * 0.65m;
            }
        }

        /// <summary>
        /// overrides the standard object.ToString() method
        /// </summary>
        /// <returns>menu item name</returns>
        public override string ToString()
        {
            return Name;
        }
    }
}

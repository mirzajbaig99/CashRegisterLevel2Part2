
namespace CashRegister
{
    /// <summary>
    /// Bar order
    /// </summary>
    public class Drink : Order
    {
        /// <summary>
        /// minimum price for drinks
        /// </summary>
        public const decimal MinimumPrice = 3;

        /// <summary>
        /// Price of a drink must be at least the minimum price
        /// </summary>
        public override decimal Price
        {
            get
            {
                return base.Price;
            }
            set
            {
                base.Price = value < MinimumPrice ? MinimumPrice : value;
            }
        }

        /// <summary>
        /// returns tax on the order at 10%
        /// </summary>
        public override decimal Tax
        {
            get { return Price * 0.10M; }
        }
    }
}

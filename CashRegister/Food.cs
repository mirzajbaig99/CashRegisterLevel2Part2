
namespace CashRegister
{
    /// <summary>
    /// Kitchen order
    /// </summary>
    public class Food : Order
    {
        /// <summary>
        /// returns tax on the order at 5%
        /// </summary>
        public override decimal Tax
        {
            get { return Price * 0.05M; }
        }
    }
}

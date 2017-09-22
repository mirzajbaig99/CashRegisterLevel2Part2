using System;
using System.Collections.Generic;
using System.Linq;

namespace CashRegister
{
    /// <summary>
    /// a ticket represents a patron's check, containing all items ordered
    /// </summary>
    public class Ticket : ITicket
    {
        #region private constants

        private const string EmptyTicket = "Empty";

        private const string BarTicket = "Bar";

        private const string KitchenTicket = "Kitchen";

        private const string MixedTicket = "Mixed";

        #endregion

        public Ticket(int ticketNumber = 0)
        {
            TicketNumber = ticketNumber;
            ItemsOrdered = new List<Order>();
        }
        /// <summary>
        /// Contains all items ordered
        /// </summary>
        public List<Order> ItemsOrdered { get; set; }

        /// <summary>
        /// gets and sets the ticket number
        /// </summary>
        public int TicketNumber { get; set; }

        /// <summary>
        /// returns the check total
        /// </summary>
        public decimal Total
        {
            get
            {
                return Decimal.Round(ItemsOrdered.Sum(x => x.Price + x.Tax), 2);
            }
        }

        /// <summary>
        /// returns the type of ticket
        /// </summary>
        public string TicketType
        {
            get
            {
                return this.DetermineTicketType();
            }
        }

        /// <summary>
        /// provides a message to be printed on a patron's check
        /// </summary>
        public string TicketMessage
        {
            get
            {
                if (TicketType == EmptyTicket)
                {
                    return string.Empty;
                }
                if (TicketType == BarTicket)
                {
                    return "Thanks for your patronage. Hope you try our food next time.";
                }
                return "Thanks for your patronage.";
            }
        }

        private string DetermineTicketType()
        {
            if (ItemsOrdered.Count == 0)
            {
                return EmptyTicket;
            }
            if (ItemsOrdered.All(o => o.GetType() == typeof(Bar)))
            {
                return BarTicket;
            }
            if (ItemsOrdered.Any(o => o.GetType() == typeof(Bar)))
            {
                return MixedTicket;
            }
            return KitchenTicket;
        }
    }
}

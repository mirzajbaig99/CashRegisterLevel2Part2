using System;
using System.Collections.Generic;

namespace CashRegister
{
    public class TicketBuilder : ITicketBuilder
    {
        #region private fields

        private readonly IMenu menu;

        private readonly Ticket ticket;

        #endregion

        //TODO: Implement the constructor:
        //TODO:  => Must be able to inject menu (IMenu) and ticket repository (IRepository<ITicket>) objects in to the TicketBuilder
        //TODO:  => Also allow passing in a ticket number (default it to 0)
        public TicketBuilder()
        {
            //TODO:  => If the ticket number passed in is zero, set it using the TicketRepository.GetNextId method
            //TODO:  => Instantiate a new ticket in the constructor, passing in the ticket number
            //TODO:  => Store the ticket in the ticket repository
        }

        //TODO: Implement the ITicketBuilder interface

        #region ITicketBuilder implementation

        public ITicket Ticket
        {
            get
            {
                return ticket;
            }
        }

        //TODO:  => The BuildOrders() method should create the orders from a collection of order names
        public void BuildOrders(IEnumerable<string> orderNames)
        {
            //TODO:  => Use the menu to get the order for each item name
            throw new NotImplementedException();
        }

        #endregion
    }
}

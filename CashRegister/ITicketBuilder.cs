using System.Collections.Generic;

namespace CashRegister
{
    interface ITicketBuilder
    {
        ITicket Ticket { get; }

        void BuildOrders(IEnumerable<string> orderNames);
    }
}

using System.Collections.Generic;

namespace CashRegister
{
    public interface ITicket
    {
        List<Order> ItemsOrdered { get; set; }

        string TicketMessage { get; }
        int TicketNumber { get; set; }
        string TicketType { get; }
        decimal Total { get; }
    }
}

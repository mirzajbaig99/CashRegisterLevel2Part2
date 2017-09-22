using System.Collections.Generic;

namespace CashRegister
{
    public interface ICashRegister
    {
        List<ITicket> CompletedTickets { get; }
        List<ITicket> PendingTickets { get; }

        ITicket StartNewTicket(int ticketNumber = 0, ICollection<string> orderNames = null);
        decimal CloseTicket(ITicket ticket);

        void Order(ITicket ticket, Order order);
        void OrderByName(ITicket ticket, string orderName);
        void OrderDrink(ITicket ticket, Order drink);
        void OrderFood(ITicket ticket, Order food);
    }
}

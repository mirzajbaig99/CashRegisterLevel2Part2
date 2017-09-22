using System.Collections.Generic;

namespace CashRegister
{
    public class TicketDto
    {
        public List<OrderDto> ItemsOrdered { get; set; }
        public int TicketNumber { get; set; }
        public bool IsPending { get; set; }
    }
}

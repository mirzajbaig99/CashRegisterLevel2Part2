using System;
using System.Collections.Generic;
using System.Linq;

namespace CashRegister
{
    /// <summary>
    /// CashRegister is the main class in this project
    /// </summary>
    public class CashRegister : ICashRegister
    {
        #region private fields

        private readonly ITakesOrder bar;

        private readonly ITakesOrder kitchen;

        private readonly IMenu menu;

        private readonly ILogger logger;

        private readonly IRepository<ITicket> ticketRepository;

        #endregion

        /// <summary>
        /// collection of pending tickets
        /// </summary>
        public List<ITicket> PendingTickets { get; private set; }

        /// <summary>
        /// collection of completed tickets
        /// </summary>
        public List<ITicket> CompletedTickets { get; private set; }

        /// <summary>
        /// constructor for dependency injection
        /// </summary>
        /// <param name="bar">bar object</param>
        /// <param name="kitchen">kitchen object</param>
        /// <param name="menu">menu object</param>
        /// <param name="logger">logger object</param>
        /// <param name="menuRepository">menu repository used for instantiating the menu (if needed)</param>
        /// <param name="ticketRepository">ticket repository used for instantiating the ticket builder</param>
        public CashRegister(
            ITakesOrder bar = null,
            ITakesOrder kitchen = null,
            IMenu menu = null,
            ILogger logger = null,
            IRepository<MenuItem> menuRepository = null,
            TicketRepository ticketRepository = null)
        {
            CashRegisterAutoMapperConfiguration.Configure();

            PendingTickets = new List<ITicket>();
            CompletedTickets = new List<ITicket>();

            this.bar = bar ?? new Bar();
            this.kitchen = kitchen ?? new Kitchen();
            this.menu = menu ?? new Menu(menuRepository);
            this.ticketRepository = ticketRepository ?? new TicketRepository();

            //TODO: Singleton DP Exercise - Update CashRegister constructor to use the singleton Logger class
            this.logger = logger ?? new Logger();

            this.kitchen.OrderUp += (sender, order) => this.logger.LogOrder(sender, order);
        }

        //TODO: Builder DP Exercise - Implement StartNewTicket in the CashRegister class
        /// <summary>
        /// Creates a new (pending) ticket
        /// </summary>
        /// <param name="ticketNumber">new ticket number if known - defaults to zero</param>
        /// <param name="orderNames">names of orders to be added to the ticket</param>
        /// <returns>the new, pending ticket</returns>
        public ITicket StartNewTicket(int ticketNumber = 0, ICollection<string> orderNames = null)
        {
            //TODO: Builder DP Exercise - Instantiate a TicketBuilder object
            //TODO: Builder DP Exercise - Call the TicketBuilder BuildOrders() method with orderNames
            //TODO: Builder DP Exercise - Add the new ticket to PendingTickets
            //TODO: Builder DP Exercise - Call Bar.Order() or Kitchen.Order() with each order in the ticket
            return new Ticket();
        }

        /// <summary>
        /// order a menu item by its name
        /// </summary>
        /// <param name="ticket">the ticket to add the order to</param>
        /// <param name="orderName">the name of the menu item</param>
        public void OrderByName(ITicket ticket, string itemName)
        {
            var item = menu.GetOrderByName(itemName);
            var orderFactory = new OrderFactory();
            //var order = orderFactory.CreateOrder()
            this.Order(ticket, item);
        }

        /// <summary>
        /// Order a menu item
        /// </summary>
        /// <param name="ticket">ticket to add the order to</param>
        /// <param name="order">menu item to be added (can be Drink or Food)</param>
        public void Order(ITicket ticket, Order order)
        {
            this.CheckForNullParameters(ticket, order);

            if (!PendingTickets.Contains(ticket))
            {
                PendingTickets.Add(ticket);
            }

            try
            {
                if (order.GetType() == typeof(Drink))
                {
                    this.OrderDrink(ticket, order);
                }
                else
                {
                    this.OrderFood(ticket, order);
                }
            }
            catch (ArgumentException)
            {
                this.HandleOrderTypeError(order);
            }
        }

        private void CheckForNullParameters(ITicket ticket, Order order)
        {
            if (ticket == null || order == null)
            {
                var parmName = ticket == null ? "ticket" : "order";
                this.logger.LogError(parmName);
                throw new ArgumentNullException(parmName);
            }
        }

        private void HandleOrderTypeError(Order order)
        {
            var message = string.Format("Order must be Food or Drink, but was {0}", order.GetType().Name);
            this.logger.LogError(message);
        }

        /// <summary>
        /// adds a food order to a ticket
        /// </summary>
        /// <param name="ticket">ticket to add the order to</param>
        /// <param name="food">food order to add</param>
        public void OrderFood(ITicket ticket, Order food)
        {
            ticket.ItemsOrdered.Add(food);
            kitchen.Order(food);
        }

        /// <summary>
        /// adds a drink order to a ticket
        /// </summary>
        /// <param name="ticket">ticket to add the order to</param>
        /// <param name="drink">drink order to add</param>
        public void OrderDrink(ITicket ticket, Order drink)
        {
            ticket.ItemsOrdered.Add(drink);
            bar.Order(drink);
        }

        /// <summary>
        /// Moves a ticket from the pending tickets to the completed tickets
        /// </summary>
        /// <param name="ticket">ticket to be closed</param>
        /// <returns>Amount due</returns>
        public decimal CloseTicket(ITicket ticket)
        {
            PendingTickets.Remove(ticket);
            CompletedTickets.Add(ticket);

            return ticket.Total;
        }

        
    }
}

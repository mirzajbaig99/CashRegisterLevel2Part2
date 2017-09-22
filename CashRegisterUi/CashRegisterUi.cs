using System;
using System.Linq;
using CashRegister;
using CashRegisterUI;

namespace CashRegisterUi
{
    /// <summary>
    /// User interface class for interfacing with CashRegister
    /// </summary>
    public class CashRegisterUi
    {
        /// <summary>
        /// CashRegister class object instance
        /// </summary>
        public ICashRegister Register { get; set; }

        /// <summary>
        /// ConsoleInterface instance
        /// </summary>
        public IConsoleInterface ConsoleInterface { get; set; }

        /// <summary>
        /// Runs the console interface with CashRegister
        /// </summary>
        public void RunCashRegister()
        {
            var continueRunning = true;

            while (continueRunning)
            {
                try
                {
                    continueRunning = this.RunCashRegisterIteration();
                }
                catch (Exception e)
                {
                    ConsoleInterface.WriteLine("{0}: {1}", e.GetType().Name, e.Message);
                    break;
                }
            }
        }

        private bool RunCashRegisterIteration()
        {

            string input = ConsoleInterface.Prompt("Enter ticket number (<enter> to list, or 0 for new) or \"exit\": ");

            if (String.IsNullOrWhiteSpace(input))
            {
                this.ListTickets();
            }
            else
            {
                if (input.ToLower() == "exit")
                {
                    return false;
                }
                HandleTicketNumber(input);
            }
            return true;
        }

        private void ListTickets()
        {
            ConsoleInterface.WriteLine("Pending tickets:");
            foreach (var ticket in Register.PendingTickets)
            {
                ConsoleInterface.WriteLine("Ticket {0}: {1} items", ticket.TicketNumber, ticket.ItemsOrdered.Count);
            }

            ConsoleInterface.WriteLine("\nCompleted tickets:");
            
            foreach (var ticket in Register.CompletedTickets)
            {
                ConsoleInterface.WriteLine("{0} items totaling {1}", ticket.ItemsOrdered.Count, ticket.Total);
            }
            ConsoleInterface.WriteLine("");
        }

        private void HandleTicketNumber(string input)
        {
            ITicket ticket;

            int num = Convert.ToInt32(input);
            if (num == 0)
            {
                this.CreateNewTicket();
                return;
            }

            ticket = Register.PendingTickets.FirstOrDefault(t => t.TicketNumber == num);
            if (ticket == null)
            {
                ConsoleInterface.WriteLine("Ticket {0} not found", num);
                return;
            }

            string name = ConsoleInterface.Prompt("Name of item to order (<enter> to close ticket): ");
            if (String.IsNullOrWhiteSpace(name))
            {
                this.CloseTicket(ticket);
                return;
            }

            this.AddOrderToTicket(ticket, name);
        }

        private void CreateNewTicket()
        {
            var ticket = Register.StartNewTicket();
            ConsoleInterface.WriteLine("Generated ticket {0}", ticket.TicketNumber);
        }

        private void CloseTicket(ITicket ticket)
        {
            Register.CloseTicket(ticket);
            ConsoleInterface.WriteLine("Closed ticket with total cost: " + ticket.Total);
        }

        private void AddOrderToTicket(ITicket ticket, string orderName)
        {
            var input = ConsoleInterface.Prompt("Price of item: ");
            var price = Convert.ToDecimal(input);

            input = ConsoleInterface.Prompt("Food or drink? ");

            switch (input.ToLower())
            {
                case "food":
                    this.Register.OrderFood(ticket, new Food { Name = orderName, Price = price });
                    break;
                case "drink":
                    this.Register.OrderDrink(ticket, new Drink { Name = orderName, Price = price });
                    break;
                default:
                    ConsoleInterface.WriteLine("Order must be food or drink.");
                    break;
            }
        }
    }
}

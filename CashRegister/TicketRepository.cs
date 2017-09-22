using System;
using System.Collections.Generic;
using System.Linq;

namespace CashRegister
{
    /// <summary>
    /// Ticket Repository
    /// </summary>
    public class TicketRepository : IRepository<ITicket>
    {
        #region Private Fields

        private readonly CashRegisterMapper mapper;
        private readonly List<TicketDto> ticketsDtos;

        #endregion

        public TicketRepository(CashRegisterMapper cashRegisterMapper = null, IEnumerable<Ticket> tickets = null)
        {
            this.mapper = cashRegisterMapper ?? new CashRegisterMapper();
            this.ticketsDtos = tickets != null ? mapper.MapToTicketDtos(tickets).ToList() : new List<TicketDto>();
        }

        //TODO: Implement the IRepository<ITicket> interface
        //TODO:  => Wrap the implementation inside this “#region IRepository<ITicket> implementation”
        public bool Add(ITicket item)
        {
            throw new NotImplementedException();
        }

        public bool Add(IEnumerable<ITicket> items)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ITicket> Get()
        {
            throw new NotImplementedException();
        }

        public ITicket Get(int id)
        {
            throw new NotImplementedException();
        }

        public ITicket Get(string name)
        {
            throw new NotImplementedException();
        }

        //TODO: Code the GetNextId() method to return one (1) plus the current maximum ticket number in the TicketRepository
        public int GetNextId()
        {
            throw new NotImplementedException();
        }

        public bool Update(ITicket item)
        {
            throw new NotImplementedException();
        }

        public bool Remove(ITicket item)
        {
            throw new NotImplementedException();
        }
    }
}

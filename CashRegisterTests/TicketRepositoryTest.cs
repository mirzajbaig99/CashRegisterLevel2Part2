using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CashRegister;

namespace CashRegisterTests
{
    [TestClass]
    public class TicketRepositoryTest
    {
        #region Private Fields

        private static CashRegisterMapper mapper;
        private TicketRepository ticketRep;

        #endregion

        [ClassInitialize]
        public static void Initialize(TestContext testContext)
        {
            CashRegisterAutoMapperConfiguration.Configure();
            mapper = new CashRegisterMapper();
        }

        [TestInitialize]
        public void InitializeTest()
        {
            ticketRep = new TicketRepository(mapper);
        }

        [TestMethod]
        public void TestGetNextIdReturnsOneForEmptyRepository()
        {
            //Arrange
            int ticketNumber;

            //Act
            ticketNumber = ticketRep.GetNextId();

            //Assert
            Assert.AreEqual(1, ticketNumber);
        }

        [TestMethod]
        public void TestGetNextIdReturnsTwo()
        {
            //Arrange
            ticketRep.Add(GetTicket());
            int expected = 2;

            //Act
            var actual = ticketRep.GetNextId();

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestAddTicketReturnsTrue()
        {
            //Arrange
            Ticket ticket = GetTicket();

            //Act
            bool itemAdded = ticketRep.Add(ticket);

            //Assert
            Assert.IsTrue(itemAdded);
        }

        [TestMethod]
        public void TestAddNullReturnsFalse()
        {
            //Arrange
            //Act
            bool itemAdded = ticketRep.Add((Ticket)null);

            //Assert
            Assert.IsFalse(itemAdded);
        }

        [TestMethod]
        public void TestAddDuplicateTicketReturnsFalse()
        {
            //Arrange
            Ticket ticket1 = GetTicket();
            Ticket ticket2 = GetTicket();
            ticketRep.Add(ticket1);

            //Act
            bool itemAdded = ticketRep.Add(ticket2);

            //Assert
            Assert.IsFalse(itemAdded);
        }

        [TestMethod]
        public void TestAddEnumerableReturnsTrue()
        {
            //Arrange
            Ticket ticket1 = GetTicket();
            Ticket ticket2 = GetTicket(ticketNumber: 2);
            var tickets = new List<Ticket> { ticket1, ticket2 };

            //Act
            bool itemsAdded = ticketRep.Add(tickets);

            //Assert
            Assert.IsTrue(itemsAdded);
        }

        [TestMethod]
        public void TestAddEnumerableNullReturnsFalse()
        {
            //Arrange
            //Act
            bool itemsAdded = ticketRep.Add((List<Ticket>)null);

            //Assert
            Assert.IsFalse(itemsAdded);
        }

        [TestMethod]
        public void TestAddEnumerableZeroCountReturnsFalse()
        {
            //Arrange
            IList<Ticket> tickets = new List<Ticket>();

            //Act
            bool itemsAdded = ticketRep.Add(tickets);

            //Assert
            Assert.IsFalse(itemsAdded);
        }

        [TestMethod]
        public void TestGetReturnTicketsCollection()
        {
            //Arrange
            var expected = new List<Ticket> { GetTicket(), GetTicket(ticketNumber: 2) };
            ticketRep.Add(expected);

            //Act
            List<ITicket> actual = ticketRep.Get().ToList();

            //Assert            
            CollectionAssert.AllItemsAreInstancesOfType(actual, typeof(Ticket));
            Assert.AreEqual(expected.Count, actual.Count);
            for (var i = 0; i < expected.Count; i++)
            {
                Assert.AreEqual(expected[i].TicketNumber, actual[i].TicketNumber);
            }
        }

        [TestMethod]
        public void TestGetByExistingIdReturnsTicket()
        {
            //Arrange
            var expected = GetTicket();
            ticketRep.Add(expected);

            //Act
            var actual = ticketRep.Get(expected.TicketNumber);

            //Assert
            Assert.IsInstanceOfType(actual, typeof(Ticket));
            Assert.AreEqual(expected.TicketNumber, actual.TicketNumber);
            CollectionAssert.AreEqual(expected.ItemsOrdered, actual.ItemsOrdered);
        }

        [TestMethod]
        public void TestGetByNonExistingIdReturnsNull()
        {
            //Arrange
            ticketRep.Add(GetTicket());

            //Act
            var actual = ticketRep.Get(2);

            //Assert
            Assert.IsNull(actual);
        }

        [TestMethod]
        public void TestUpdateReturnsTrue()
        {
            //Arrange
            var ticket = GetTicket();
            ticketRep.Add(ticket);

            var expectedItemsOrdered = new List<Order> { GetDrink() };
            var updatedTicket = GetTicket(ticket.TicketNumber, expectedItemsOrdered);

            //Act
            bool itemUpdated = ticketRep.Update(updatedTicket);
            var actual = ticketRep.Get(updatedTicket.TicketNumber);

            //Assert
            Assert.IsTrue(itemUpdated);
            Assert.AreEqual(expectedItemsOrdered.Count, actual.ItemsOrdered.Count);
            for (var i = 0; i < expectedItemsOrdered.Count; i++)
            {
                Assert.AreEqual(expectedItemsOrdered[i].Name, actual.ItemsOrdered[i].Name);
                Assert.AreEqual(expectedItemsOrdered[i].Price, actual.ItemsOrdered[i].Price);
                Assert.AreEqual(expectedItemsOrdered[i].ToString(), actual.ItemsOrdered[i].ToString());
            }
        }

        [TestMethod]
        public void TestUpdateEmptyRepositoryReturnsFalse()
        {
            //Arrange
            var ticket = GetTicket();

            //Act
            bool itemUpdated = ticketRep.Update(ticket);

            //Assert
            Assert.IsFalse(itemUpdated);
        }

        [TestMethod]
        public void TestUpdateNonExistingTicketReturnsFalse()
        {
            //Arrange
            ticketRep.Add(GetTicket());
            var ticket = GetTicket(ticketNumber: 2);

            //Act
            bool itemUpdated = ticketRep.Update(ticket);

            //Assert
            Assert.IsFalse(itemUpdated);
        }

        [TestMethod]
        public void TestRemoveReturnsTrue()
        {
            //Arrange
            var ticket = GetTicket();
            ticketRep.Add(ticket);

            //Act
            bool itemRemoved = ticketRep.Remove(ticket);

            //Assert
            Assert.IsTrue(itemRemoved);
        }

        [TestMethod]
        public void TestRemoveNotExistingTicketReturnsFalse()
        {
            //Arrange
            ticketRep.Add(GetTicket());
            var ticket2 = GetTicket(2);

            //Act
            bool itemRemoved = ticketRep.Remove(ticket2);

            //Assert
            Assert.IsFalse(itemRemoved);
        }

        [TestMethod]
        public void TestRemoveNullReturnsFalse()
        {
            //Arrange
            ticketRep.Add(GetTicket());

            //Act
            bool itemRemoved = ticketRep.Remove(null);

            //Assert
            Assert.IsFalse(itemRemoved);
        }

        private static Ticket GetTicket(int ticketNumber = 1, List<Order> orders = null)
        {
            var orderList = orders ?? new List<Order>();
            var ticket = new Ticket { TicketNumber = ticketNumber, ItemsOrdered = orderList };
            return ticket;
        }

        private static Drink GetDrink(string name = null, decimal price = 0m)
        {
            name = name ?? "Soda";
            price = price <= 0 ? 3 : price;
            return new Drink { Name = name, Price = price };
        }
    }
}

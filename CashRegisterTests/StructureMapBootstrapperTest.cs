using System.Collections.Generic;
using CashRegister;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StructureMap;


namespace CashRegisterTests
{
    [TestClass]
    public class StructureMapBootstrapperTest
    {
        private static IContainer container;

        [ClassInitialize]
        public static void ClassInit(TestContext context)
        {
            container = StructureMapBootstrapper.Initialize();
        }

        [TestMethod]
        public void AssertRegistryIsValid()
        {
            //Arrange, Act, Assert
            container.AssertConfigurationIsValid();
        }

        [TestMethod]
        public void TestExerciseOne()
        {
            //Arrange, Act
            var ticket = container.GetInstance<ITicket>();

            //Assert
            Assert.AreEqual(typeof(Ticket), ticket.GetType());
        }

        [TestMethod]
        public void TestExerciseTwo()
        {
            //Arrange, Act
            var kithcen = container.GetInstance<ITakesOrder>("Kitchen");

            //Assert
            Assert.AreEqual(typeof(Kitchen), kithcen.GetType());
        }

        [TestMethod]
        public void TestExerciseThree()
        {
            //Arrange, Act
            var drink = container.GetInstance<Order>("ExpensiveDrink");

            //Assert
            Assert.IsInstanceOfType(drink, typeof(Drink));
            Assert.AreEqual(10, drink.Price);
        }

        [TestMethod]
        public void TestExerciseFour()
        {
            //Arrange
            var ticketRepo = container.GetInstance<IRepository<ITicket>>();

            //Act
            var ticketAdded = ticketRepo.Add(new Ticket
            {
                TicketNumber = 1,
                ItemsOrdered = new List<Order>()
            });

            //Assert
            Assert.IsTrue(ticketAdded);
            Assert.AreEqual(ticketRepo.Get(1).TicketNumber, 1);
        }

    }
}

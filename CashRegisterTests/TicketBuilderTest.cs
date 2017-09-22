using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CashRegister;

namespace CashRegisterTests
{
    [TestClass]
    public class TicketBuilderTest
    {
        //private TicketBuilder ticketBuilder;
        //private TicketRepository ticketRepository;

        //[TestInitialize]
        //public void Initialize()
        //{
        //    CashRegisterAutoMapperConfiguration.Configure();
        //    ticketRepository = new TicketRepository();
        //    ticketBuilder = new TicketBuilder(new Menu(), ticketRepository);
        //}
        //[TestMethod]
        //public void TestConstructorCreatesNewTicketInRepository()
        //{
        //    //Arrange
        //    //Act
        //    var actual = ticketBuilder.Ticket;

        //    //Assert
        //    Assert.IsNotNull(actual);
        //    Assert.IsNotNull(actual.ItemsOrdered);
        //    Assert.IsNotNull(ticketRepository.Get(actual.TicketNumber));
        //}

        //[TestMethod]
        //public void TestBuildOrdersCreatesExpectedOrders()
        //{
        //    //Arrange
        //    var expectedOrders = new List<Order>()
        //    {
        //        new Drink() {Name = "Soda", Price = 3},
        //        new Food() {Name = "Hot Dog", Price = 4}
        //    };
        //    var orderNames = new List<string> {expectedOrders[0].Name, expectedOrders[1].Name};

        //    //Act
        //    ticketBuilder.BuildOrders(orderNames);
        //    var actual = ticketBuilder.Ticket;

        //    //Assert
        //    CollectionAssert.AllItemsAreInstancesOfType(actual.ItemsOrdered, typeof(Order));
        //    Assert.AreEqual(expectedOrders.Count, actual.ItemsOrdered.Count);
        //    for (var i = 0; i < expectedOrders.Count; i++)
        //    {
        //        Assert.AreEqual(expectedOrders[i].Name, actual.ItemsOrdered[i].Name);
        //        Assert.AreEqual(expectedOrders[i].Price, actual.ItemsOrdered[i].Price);
        //    }
        //}

        //[TestMethod]
        //public void TestBuildOrdersWithEmptyNameList()
        //{
        //    //Arrange
        //    var emptyNameList = new List<string>();
        //    var expectedOrders = new List<string>();

        //    //Act
        //    ticketBuilder.BuildOrders(emptyNameList);

        //    //Assert
        //    CollectionAssert.AreEquivalent(expectedOrders, ticketBuilder.Ticket.ItemsOrdered);
        //    Assert.AreEqual(expectedOrders.Count, ticketBuilder.Ticket.ItemsOrdered.Count);
        //}

        //[TestMethod]
        //public void TestBuildOrdersWithNameList()
        //{
        //    //Arrange
        //    var expectedOrderItems = new List<Order>();
        //    //Act
        //    ticketBuilder.BuildOrders(null);
        //    //Assert
        //    CollectionAssert.AreEquivalent(expectedOrderItems, ticketBuilder.Ticket.ItemsOrdered);
        //    Assert.AreEqual(expectedOrderItems.Count, ticketBuilder.Ticket.ItemsOrdered.Count);
        //}
    }
}

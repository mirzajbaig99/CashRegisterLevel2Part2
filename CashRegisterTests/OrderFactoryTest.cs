using System;
using CashRegister;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CashRegisterTests
{
    [TestClass]
    public class OrderFactoryTest
    {
        [TestMethod]
        public void TestGoodDrinkOrder()
        {
            // Arrange
            const string OrderType = "Drink";
            const string OrderName = "Soda";
            const decimal OrderPrice = 3;

            var orderFactory = new OrderFactory();

            // Act
            var order = orderFactory.Get(OrderType, OrderName, OrderPrice);

            // Assert
            Assert.IsNotNull(order);
            Assert.AreEqual(OrderType, order.GetType().Name);
            Assert.AreEqual(OrderName, order.Name);
            Assert.AreEqual(OrderPrice, order.Price);
        }

        [TestMethod]
        public void TestGoodFoodOrder()
        {
            // Arrange
            const string OrderType = "Food";
            const string OrderName = "HotDog";
            const decimal OrderPrice = 3.5m;

            var orderFactory = new OrderFactory();

            // Act
            var order = orderFactory.Get(OrderType, OrderName, OrderPrice);

            // Assert
            Assert.IsNotNull(order);
            Assert.AreEqual(OrderType, order.GetType().Name);
            Assert.AreEqual(OrderName, order.Name);
            Assert.AreEqual(OrderPrice, order.Price);
        }

        [TestMethod]
        public void TestOrderPriceLessThanZeroShouldBeChangedToZero()
        {
            // Arrange
            const string OrderType = "Food";
            const string OrderName = "HotDog";
            const decimal OrderPrice = -3.5m;

            var orderFactory = new OrderFactory();

            // Act
            var order = orderFactory.Get(OrderType, OrderName, OrderPrice);

            // Assert
            Assert.IsNotNull(order);
            Assert.AreEqual(OrderType, order.GetType().Name);
            Assert.AreEqual(OrderName, order.Name);
            Assert.AreEqual(0, order.Price);
        }

        [TestMethod]
        public void TestBadOrderType()
        {
            // Arrange
            const string OrderType = "Order";
            const string HotDog = "HotDog";
            const decimal OrderPrice = 3.5m;

            var orderFactory = new OrderFactory();

            // Act
            var order = orderFactory.Get(OrderType, HotDog, OrderPrice);

            // Assert
            Assert.IsNull(order);
        }
    }
}

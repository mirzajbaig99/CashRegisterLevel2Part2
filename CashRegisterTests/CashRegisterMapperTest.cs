using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using CashRegister;

namespace CashRegisterTests
{
    [TestClass]
    public class CashRegisterMapperTest
    {
        private static CashRegisterMapper mapper;

        private static bool autoMapperExercise5IsComplete = true;

        private static bool autoMapperExercise6IsComplete = true;

        [ClassInitialize]
        public static void Initialize(TestContext testContext)
        {
            CashRegisterAutoMapperConfiguration.Configure();
            mapper = new CashRegisterMapper();
        }

        #region AutoMapper Exercise 1 unit tests

        [TestMethod]
        public void TestMapMenuItemToMenuItemDto()
        {
            // Arrange
            var menuItem = this.GetDrinkItem();

            // Act
            var menuItemDto = mapper.MapToMenuItemDto(menuItem);

            // Assert
            Assert.AreEqual(typeof(MenuItemDto), menuItemDto.GetType());

            Assert.AreEqual(menuItem.ItemType, menuItemDto.ItemType);
            Assert.AreEqual(menuItem.Name, menuItemDto.Name);
            Assert.AreEqual(menuItem.Price, menuItemDto.Price);
            Assert.AreEqual(menuItem.ServiceType, menuItemDto.ServiceType);
        }

        [TestMethod]
        public void TestMapMenuItemDtoToMenuItem()
        {
            // Arrange
            var menuItemDto = this.GetDrinkItemDto();

            // Act
            var menuItem = mapper.MapToMenuItem(menuItemDto);

            // Assert
            Assert.AreEqual(typeof(MenuItem), menuItem.GetType());

            Assert.AreEqual(menuItemDto.ItemType, menuItem.ItemType);
            Assert.AreEqual(menuItemDto.Name, menuItem.Name);
            Assert.AreEqual(menuItemDto.Price, menuItem.Price);
            Assert.AreEqual(menuItemDto.ServiceType, menuItem.ServiceType);
        }

        [TestMethod]
        public void TestMapOrderDtoToDrinkOrder()
        {
            // Arrange
            var orderDto = this.GetDrinkOrderDto();

            // Act
            var order = mapper.MapToOrder(orderDto);

            // Assert
            Assert.AreEqual(orderDto.ItemType, order.GetType().Name);
            Assert.AreEqual(orderDto.Name, order.Name);
            Assert.AreEqual(orderDto.Price, order.Price);
        }

        [TestMethod]
        public void TestMapOrderDtoToFoodOrder()
        {
            // Arrange
            var orderDto = this.GetFoodOrderDto();

            // Act
            var order = mapper.MapToOrder(orderDto);

            // Assert
            Assert.AreEqual(orderDto.ItemType, order.GetType().Name);
            Assert.AreEqual(orderDto.Name, order.Name);
            Assert.AreEqual(orderDto.Price, order.Price);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "Order")]
        public void TestMapOrderDtoToOrderThrowsArgumentException()
        {
            // Arrange
            var item = this.GetDrinkOrderDto();
            item.ItemType = "Order";

            // Act
            var order = mapper.MapToOrder(item);
        }

        #endregion

        #region AutoMapper Exercise 2 unit tests

        [TestMethod]
        public void TestMapMenuItemsToMenuItemDtos()
        {
            // Arrange
            var drink = this.GetDrinkItem();
            var food = this.GetFoodItem();
            var menuItems = new List<MenuItem> { drink, food };

            // Act
            var menuItemDtos = mapper.MapToMenuItemDtos(menuItems);

            // Assert
            CollectionAssert.AllItemsAreInstancesOfType((ICollection)menuItemDtos, typeof(MenuItemDto));
            Assert.AreEqual(2, menuItemDtos.Count());
            Assert.IsTrue(menuItemDtos.Any(i => i.Name == drink.Name));
            Assert.IsTrue(menuItemDtos.Any(i => i.Name == food.Name));
        }

        [TestMethod]
        public void TestMapMenuItemDtosToMenuItems()
        {
            // Arrange
            var drinkDto = this.GetDrinkItemDto();
            var foodDto = this.GetFoodItemDto();
            var menuItemDtos = new List<MenuItemDto> { drinkDto, foodDto };

            // Act
            var menuItems = mapper.MapToMenuItems(menuItemDtos);

            // Assert
            CollectionAssert.AllItemsAreInstancesOfType((ICollection)menuItems, typeof(MenuItem));
            Assert.AreEqual(2, menuItems.Count());
            Assert.IsTrue(menuItems.Any(i => i.Name == drinkDto.Name));
            Assert.IsTrue(menuItems.Any(i => i.Name == foodDto.Name));
        }

        #endregion

        #region AutoMapper Exercise 3 unit tests

        [TestMethod]
        public void TestMapOrderToOrderDto()
        {
            // Arrange
            var order = this.GetDrinkOrder();

            // Act
            var orderDto = mapper.MapToOrderDto(order);

            // Assert
            Assert.AreEqual(typeof(Drink).Name, orderDto.ItemType);
            Assert.AreEqual(order.Name, orderDto.Name);
            Assert.AreEqual(order.Price, orderDto.Price);
        }

        [TestMethod]
        public void TestMapOrdersToOrderDtos()
        {
            // Arrange
            var orders = new List<Order> { this.GetDrinkOrder(), this.GetFoodOrder() };

            // Act
            var orderDtos = mapper.MapToOrderDtos(orders).ToList();

            // Assert
            Assert.AreEqual(2, orderDtos.Count());
            Assert.AreEqual(orders[0].Name, orderDtos[0].Name);
            Assert.AreEqual("Drink", orderDtos[0].ItemType);
            Assert.AreEqual("Food", orderDtos[1].ItemType);
        }

        #endregion

        #region AutoMapper Excercise 4 unit tests

        [TestMethod]
        public void TestMapOrderToMenuItem()
        {
            // Arrange
            var order = this.GetDrinkOrder();

            // Act
            var item = mapper.MapToMenuItem(order);

            // Assert
            Assert.AreEqual(typeof(MenuItem), item.GetType());
            Assert.AreEqual(order.Name, item.Name);
            Assert.AreEqual(order.Price, item.Price);
            Assert.AreEqual(order.GetType().Name, item.ItemType);
            Assert.AreEqual("All", item.ServiceType);
        }

        [TestMethod]
        public void TestMapMenuItemToDrinkOrder()
        {
            // Arrange
            var item = this.GetDrinkItem();

            // Act
            var order = mapper.MapToOrder(item);

            // Assert
            Assert.AreEqual(typeof(Drink), order.GetType());
            Assert.AreEqual(item.Name, order.Name);
            Assert.AreEqual(item.Price, order.Price);
        }

        [TestMethod]
        public void TestMapMenuItemToFoodOrder()
        {
            // Arrange
            var item = this.GetFoodItem();

            // Act
            var order = mapper.MapToOrder(item);

            // Assert
            Assert.AreEqual(typeof(Food), order.GetType());
            Assert.AreEqual(item.Name, order.Name);
            Assert.AreEqual(item.Price, order.Price);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "Order")]
        public void TestMapMenuItemToOrderThrowsArgumentException()
        {
            // Arrange
            var item = this.GetFoodItem();
            item.ItemType = "Order";

            // Act
            var order = mapper.MapToOrder(item);
        }

        [TestMethod]
        public void TestMapTicketToTicketDto()
        {
            // Arrange
            var ticket = this.GetTicket();

            // Act
            var ticketDto = mapper.MapToTicketDto(ticket);

            // Assert
            Assert.AreEqual(typeof(TicketDto), ticketDto.GetType());
            Assert.AreEqual(ticket.TicketNumber, ticketDto.TicketNumber);
            Assert.AreEqual(2, ticketDto.ItemsOrdered.Count);
            CollectionAssert.AllItemsAreInstancesOfType((ICollection)ticketDto.ItemsOrdered, typeof(OrderDto));
            Assert.IsTrue(ticketDto.ItemsOrdered.Any(i => i.Name == ticket.ItemsOrdered[0].Name));
            Assert.IsTrue(ticketDto.ItemsOrdered.Any(i => i.Name == ticket.ItemsOrdered[1].Name));
        }

        [TestMethod]
        public void TestMapTicketDtoToTicket()
        {
            // Arrange
            var ticketDto = this.GetTicketDto();

            // Act
            var ticket = mapper.MapToTicket(ticketDto);

            // Assert
            Assert.AreEqual(typeof(Ticket), ticket.GetType());
            Assert.AreEqual(ticketDto.TicketNumber, ticket.TicketNumber);
            Assert.AreEqual(2, ticket.ItemsOrdered.Count);
            CollectionAssert.AllItemsAreInstancesOfType((ICollection)ticket.ItemsOrdered, typeof(Order));
            Assert.IsTrue(ticket.ItemsOrdered.Any(i => i.Name == ticketDto.ItemsOrdered[0].Name));
            Assert.IsTrue(ticket.ItemsOrdered.Any(i => i.Name == ticketDto.ItemsOrdered[1].Name));
        }

        [TestMethod]
        public void TestMapTicketsToTicketDtos()
        {
            // Arrange
            var ticket1 = this.GetTicket();
            var ticket2 = this.GetTicket();
            ticket2.TicketNumber = 2;
            var tickets = new List<Ticket> { ticket1, ticket2 };

            // Act
            var ticketDtos = mapper.MapToTicketDtos(tickets).ToList();

            // Assert
            CollectionAssert.AllItemsAreInstancesOfType(ticketDtos, typeof(TicketDto));
            CollectionAssert.AllItemsAreInstancesOfType(ticketDtos[0].ItemsOrdered, typeof(OrderDto));
            Assert.AreEqual(1, ticketDtos[0].TicketNumber);
            Assert.AreEqual(2, ticketDtos[1].TicketNumber);
        }

        [TestMethod]
        public void TestMapTicketDtosToTickets()
        {
            // Arrange
            var ticketDto1 = this.GetTicketDto();
            var ticketDto2 = this.GetTicketDto();
            ticketDto2.TicketNumber = 2;
            var ticketDtos = new List<TicketDto> { ticketDto1, ticketDto2 };

            // Act
            var tickets = mapper.MapToTickets(ticketDtos).ToList();

            // Assert
            CollectionAssert.AllItemsAreInstancesOfType(tickets, typeof(Ticket));
            CollectionAssert.AllItemsAreInstancesOfType(tickets[0].ItemsOrdered, typeof(Order));
            Assert.AreEqual(1, tickets[0].TicketNumber);
            Assert.AreEqual(2, tickets[1].TicketNumber);
        }

        #endregion

        #region AutoMapper Excercise 5 unit tests

        [TestMethod]
        public void TestMapOrderToMenuItemWithTemperature()
        {
            if (autoMapperExercise5IsComplete && !autoMapperExercise6IsComplete)
            {
                // Arrange
                var order = GetDrinkOrder();
                order.Temperature = 35.5m;

                // Act
                var item = mapper.MapToMenuItem(order);

                // Assert
                Assert.AreEqual(35.5f, item.Temperature);
            }
        }

        [TestMethod]
        public void TestMapMenuItemToDrinkOrderWithTemperature()
        {
            if (autoMapperExercise5IsComplete && !autoMapperExercise6IsComplete)
            {
                // Arrange
                var item = this.GetDrinkItem();
                item.Temperature = 35.5f;

                // Act
                var order = mapper.MapToOrder(item);

                // Assert
                Assert.AreEqual(35.5m, order.Temperature);
            }
        }

        [TestMethod]
        public void TestMapMenuItemToFoodOrderWithTemperature()
        {
            if (autoMapperExercise5IsComplete && !autoMapperExercise6IsComplete)
            {
                // Arrange
                var item = this.GetFoodItem();
                item.Temperature = 159.3f;

                // Act
                var order = mapper.MapToOrder(item);

                // Assert
                Assert.AreEqual(159.3m, order.Temperature);
            }
        }

        #endregion

        #region AutoMapper Excercise 6 unit tests

        [TestMethod]
        public void TestMapOrderToMenuItemConvertingTemperature()
        {
            if (autoMapperExercise6IsComplete)
            {
                // Arrange
                var order = GetDrinkOrder();
                order.Temperature = 35.6m;

                // Act
                var item = mapper.MapToMenuItem(order);

                // Assert
                Assert.AreEqual(2.0f, item.Temperature);
            }
        }

        [TestMethod]
        public void TestMapMenuItemToDrinkOrderConvertingTemperature()
        {
            if (autoMapperExercise6IsComplete)
            {
                // Arrange
                var item = this.GetDrinkItem();
                item.Temperature = 2.0f;

                // Act
                var order = mapper.MapToOrder(item);

                // Assert
                Assert.AreEqual(35.6m, order.Temperature);
            }
        }

        [TestMethod]
        public void TestMapMenuItemToFoodOrderConvertingTemperature()
        {
            if (autoMapperExercise6IsComplete)
            {
                // Arrange
                var item = this.GetFoodItem();
                item.Temperature = 71.5f;

                // Act
                var order = mapper.MapToOrder(item);

                // Assert
                Assert.AreEqual(160.7m, order.Temperature);
            }
        }

        #endregion

        #region private classes to create objects for the unit tests

        #region tickets

        private Ticket GetTicket()
        {
            var drinkOrder = this.GetDrinkOrder();
            var foodOrder = this.GetFoodOrder();
            return new Ticket
            {
                TicketNumber = 1, 
                ItemsOrdered = new List<Order> { drinkOrder, foodOrder }
            };
        }

        private TicketDto GetTicketDto()
        {
            var drinkOrderDto = this.GetDrinkOrderDto();
            var foodOrderDto = this.GetFoodOrderDto();
            return new TicketDto
            {
                IsPending = true,
                ItemsOrdered = new List<OrderDto> { drinkOrderDto, foodOrderDto },
                TicketNumber = 1
            };
        }

        #endregion

        #region orders

        private Order GetDrinkOrder()
        {
            return new Drink { Name = "Soda", Price = 3 };
        }

        private OrderDto GetDrinkOrderDto()
        {
            return new OrderDto { ItemType = "Drink", Name = "Soda", Price = 3 };
        }

        private Order GetFoodOrder()
        {
            return new Food { Name = "Hot Dog", Price = 3 };
        }

        private OrderDto GetFoodOrderDto()
        {
            return new OrderDto { ItemType = "Food", Name = "Hot Dog", Price = 3 };
        }

        #endregion

        #region menu items

        private MenuItem GetDrinkItem()
        {
            return new MenuItem { ItemType = "Drink", Name = "Soda", Price = 3, ServiceType = "All" };
        }

        private MenuItem GetFoodItem()
        {
            return new MenuItem { ItemType = "Food", Name = "Hot Dog", Price = 3, ServiceType = "All" };
        }

        private MenuItemDto GetDrinkItemDto()
        {
            return new MenuItemDto { ItemType = "Drink", Name = "Soda", Price = 3, ServiceType = "All" };
        }

        private MenuItemDto GetFoodItemDto()
        {
            return new MenuItemDto { ItemType = "Food", Name = "Hot Dog", Price = 3, ServiceType = "All" };
        }

        #endregion

        #endregion
    }
}

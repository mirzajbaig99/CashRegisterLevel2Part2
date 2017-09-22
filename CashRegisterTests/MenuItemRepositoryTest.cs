using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CashRegister;

namespace CashRegisterTests
{
    [TestClass]
    public class MenuItemRepositoryTest
    {
        private static CashRegisterMapper mapper;
        private static MenuRepository menuItemRepository;

        private const string Drink = "Drink";
        private const string Food = "Food";

        private const string All = "All";
        private const string Dinner = "Dinner";

        private const string Soda = "Soda";
        private const string Beer = "Beer";
        private const string AppleJuice = "Apple Juice";
        private const string OrangeJuice = "Orange Juice";

        private const string Hamburger = "Hamburger";
        private const string Pizza = "Pizza";
        private const string Bread = "Bread";
        private const string Salad = "Salad";

        [ClassInitialize]
        public static void Initialize(TestContext testContext)
        {
            CashRegisterAutoMapperConfiguration.Configure();
            mapper = new CashRegisterMapper();
        }

        [TestInitialize]
        public void TestInitialize()
        {
            menuItemRepository = new MenuRepository(mapper);
        }

        [TestMethod]
        public void TestAddDrink()
        {
            //Arrange
            //Act
            bool added = menuItemRepository.Add(Drink, AppleJuice, 3, Dinner);

            //Assert
            Assert.IsTrue(added);
        }

        [TestMethod]
        public void TestAddFood()
        {
            //Arrange
            //Act
            bool added = menuItemRepository.Add(Food, Salad, 6);

            //Assert
            Assert.IsTrue(added);
        }

        [TestMethod]
        public void TestAddExistingMenuItem()
        {
            //Arrange
            //Act
            bool added = menuItemRepository.Add(Drink, Beer, 3);

            //Assert
            Assert.IsFalse(added);
        }

        [TestMethod]
        public void TestAddMenuItem()
        {
            //Arrange
            var item = new MenuItem { ItemType = Drink, Name = OrangeJuice, Price = 3, ServiceType = All, };

            //Act
            bool added = menuItemRepository.Add(item);

            //Assert
            Assert.IsTrue(added);
        }

        [TestMethod]
        public void TestAddNullMenuItem()
        {
            //Arrange
            //Act
            bool added = menuItemRepository.Add((MenuItem)null);

            //Assert
            Assert.IsFalse(added);
        }

        [TestMethod]
        public void TestAddMenuItems()
        {
            //Arrange
            var item1 = new MenuItem { ItemType = Food, Name = Bread, Price = 2, ServiceType = All, };
            var item2 = new MenuItem { ItemType = Drink, Name = OrangeJuice, Price = 3, ServiceType = All, };

            var items = new List<MenuItem> { item1, item2 };

            //Act
            bool added = menuItemRepository.Add(items);

            //Assert
            Assert.IsTrue(added);
        }

        [TestMethod]
        public void TestAddExistingMenuItems()
        {
            //Arrange
            var item1 = new MenuItem { ItemType = Food, Name = Pizza, Price = 9, ServiceType = All, };
            var item2 = new MenuItem { ItemType = Drink, Name = Soda, Price = 3, ServiceType = All, };

            var items = new List<MenuItem> { item1, item2 };

            //Act
            bool added = menuItemRepository.Add(items);

            //Assert
            Assert.IsFalse(added);
        }

        [TestMethod]
        public void TestAddMenuItemsNull()
        {
            //Arrange
            //Act
            bool added = menuItemRepository.Add((IList<MenuItem>)null);

            //Assert
            Assert.IsFalse(added);
        }

        [TestMethod]
        public void TestAddMenuItemsZeroCount()
        {
            //Arrange
            IList<MenuItem> items = new List<MenuItem>();

            //Act
            bool added = menuItemRepository.Add(items);

            //Assert
            Assert.IsFalse(added);
        }

        [TestMethod]
        public void TestGet()
        {
            //Arrange
            var expectedCount = MenuDefaults.DefaultMenuItems.Count();

            //Act
            var menuItems = menuItemRepository.Get().ToList();

            //Assert
            Assert.AreEqual(expectedCount, menuItems.Count());
            CollectionAssert.AllItemsAreInstancesOfType(menuItems, typeof(MenuItem));
        }

        [TestMethod]
        public void TestGetDrinkByName()
        {
            //Arrange
            //Act
            MenuItem menuItem = menuItemRepository.Get(Soda);

            //Assert
            Assert.IsInstanceOfType(menuItem, typeof(MenuItem));
            Assert.AreEqual(Soda, menuItem.Name);
            Assert.AreEqual(All, menuItem.ServiceType);
            Assert.AreEqual(Drink, menuItem.ItemType);
            Assert.AreEqual(3, menuItem.Price);
        }

        [TestMethod]
        public void TestGetFoodByName()
        {
            //Arrange
            //Act
            MenuItem menuItem = menuItemRepository.Get(Hamburger);

            //Assert
            Assert.IsInstanceOfType(menuItem, typeof(MenuItem));
            Assert.AreEqual(Hamburger, menuItem.Name);
            Assert.AreEqual(All, menuItem.ServiceType);
            Assert.AreEqual(Food, menuItem.ItemType);
            Assert.AreEqual(7, menuItem.Price);
        }

        [TestMethod]
        public void TestUpdate()
        {
            //Arrange
            var item = new MenuItem { ItemType = "Drink", Name = "Beer", Price = 5, ServiceType = "All", };

            //Act
            bool updated = menuItemRepository.Update(item);

            //Assert
            Assert.IsTrue(updated);
        }

        [TestMethod]
        public void TestUpdateItemNotFound()
        {
            //Arrange
            var item = new MenuItem { ItemType = "Drink", Name = "AppleJuice", Price = 2, ServiceType = "All", };

            //Act
            bool updated = menuItemRepository.Update(item);

            //Assert
            Assert.IsFalse(updated);
        }

        [TestMethod]
        public void TestUpdateNullItem()
        {
            //Arrange
            //Act
            bool updated = menuItemRepository.Update(null);

            //Assert
            Assert.IsFalse(updated);
        }

        [TestMethod]
        public void TestRemove()
        {
            //Arrange
            var item = new MenuItem { ItemType = "Drink", Name = "Beer", Price = 4, ServiceType = "All", };

            //Act
            bool removed = menuItemRepository.Remove(item);

            //Assert
            Assert.IsTrue(removed);
        }

        [TestMethod]
        public void TestRemoveItemNotFound()
        {
            //Arrange
            var item = new MenuItem { ItemType = "Drink", Name = "OrangeJuice", Price = 4, ServiceType = "All", };

            //Act
            bool removed = menuItemRepository.Remove(item);

            //Assert
            Assert.IsFalse(removed);
        }

        [TestMethod]
        public void TestRemoveNull()
        {
            //Arrange
            //Act
            bool removed = menuItemRepository.Remove(null);

            //Assert
            Assert.IsFalse(removed);
        }
    }
}

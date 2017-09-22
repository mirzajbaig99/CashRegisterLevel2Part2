using System;
using System.Collections.Generic;
using System.Linq;

namespace CashRegister
{
    /// <summary>
    /// menu contains all drink (bar) and food (kitchen) items
    /// </summary>
    public class Menu : IMenu
    {
        #region private fields

        private CashRegisterMapper mapper;

        #endregion

        /// <summary>
        /// Constructor sets up menu items
        /// </summary>
        /// <param name="menuRepository">menu item repository</param>
        public Menu(IRepository<MenuItem> menuRepository = null)
        {
            mapper = new CashRegisterMapper();

            FoodItems = new List<MenuItem>();
            DrinkItems = new List<MenuItem>();

            MenuItemRepository = menuRepository ?? new MenuRepository();

            this.DrinkItems.AddRange(MenuItemRepository.Get().Where(i => i.ItemType == typeof(Drink).Name).ToList());
            this.FoodItems.AddRange(MenuItemRepository.Get().Where(i => i.ItemType == typeof(Food).Name).ToList());
        }

        #region IMenu implementation

        /// <summary>
        /// collection of food items
        /// </summary>
        public List<MenuItem> FoodItems { get; private set; }

        /// <summary>
        /// collection of drink items
        /// </summary>
        public List<MenuItem> DrinkItems { get; private set; }

        /// <summary>
        /// repository for menu items
        /// </summary>
        public IRepository<MenuItem> MenuItemRepository { get; private set; }

        /// <summary>
        /// adds an item to the menu
        /// </summary>
        /// <param name="type">type of item (drink or food)</param>
        /// <param name="name">name of item</param>
        /// <param name="price">price of item</param>
        /// <param name="service">type of service is Lunch, Dinner, or All (the default)</param>
        /// <returns>true or false indicating whether the item was added</returns>
        public bool AddMenuItem(string type, string name, ref decimal price, string service = "All")
        {
            return this.AddMenuItem(new MenuItem { ItemType = type.ToLower(), Name = name, Price = price, ServiceType = service });
        }

        /// <summary>
        /// Adds an item to the menu
        /// </summary>
        /// <param name="item">menu item to be added</param>
        /// <returns>true or false indicating whether the item was added</returns>
        public bool AddMenuItem(MenuItem item)
        {
            if (!MenuItemRepository.Add(item))
            {
                return false;
            }

            if (item.ItemType == typeof(Drink).Name)
            {
                DrinkItems.Add(item);
            }
            else
            {
                FoodItems.Add(item);
            }
            return true;
        }

        #endregion

        public IEnumerable<MenuItem> GetMenu()
        {
            return this.MenuItemRepository.Get();
        }

        /// <summary>
        /// gets an order by name
        /// </summary>
        /// <param name="name">name of the order</param>
        /// <returns>order with provided name or null if not found</returns>
        public Order GetOrderByName(string name)
        {
            return (Order)this.GetFoodByName(name) ?? (Order)this.GetDrinkByName(name);
        }

        /// <summary>
        /// gets a food order by name
        /// </summary>
        /// <param name="name">name of the order</param>
        /// <returns>order with provided name or null if not found</returns>
        public Food GetFoodByName(string name)
        {
            var menuItem = FoodItems.FirstOrDefault(f => f.Name == name);
            return menuItem == null
                ? null
                : (Food)mapper.MapToOrder(menuItem);
        }

        /// <summary>
        /// gets a drink order by name
        /// </summary>
        /// <param name="name">name of the order</param>
        /// <returns>order with provided name or null if not found</returns>
        public Drink GetDrinkByName(string name)
        {
            var menuItem = DrinkItems.FirstOrDefault(d => d.Name == name);
            return menuItem == null
                ? null
                : (Drink)mapper.MapToOrder(menuItem);
        }

        /// <summary>
        /// updates name of an order
        /// </summary>
        /// <param name="oldName">old order name</param>
        /// <param name="newName">new name</param>
        /// <returns>true or false indicating whether the order was updated</returns>
        public bool UpdateName(string oldName, string newName)
        {
            return this.UpdateOrder("name", oldName, newName);
        }

        /// <summary>
        /// updates price of an order
        /// </summary>
        /// <param name="name">order name</param>
        /// <param name="price">new price</param>
        /// <returns>true or false indicating whether the order was updated</returns>
        public bool UpdatePrice(string name, decimal price)
        {
            return this.UpdateOrder("price", name, price);
        }

        private bool UpdateOrder(string type, string name, object newValue)
        {
            var order = this.GetOrderByName(name);
            if (order == null)
            {
                return false;
            }
            if (type == "name")
            {
                order.Name = (string)newValue;
            }
            else
            {
                order.Price = (decimal)newValue;
            }
            return true;
        }

        /// <summary>
        /// Creates a new item on the menu
        /// </summary>
        /// <param name="type">item type must be drink or food</param>
        /// <param name="name">name of menu item</param>
        /// <param name="price">price of menu item</param>
        /// <returns>message describing the result of trying to add the menu item</returns>
        public string CreateMenuItem(string type, string name, decimal price)
        {
            const string ItemAdded = "Item added";
            const string ItemNotAdded = "Item not added";
            const string PriceChanged = "Item added with price changed to ${0}";

            //IMenu menu = new Menu(DefaultMenuItems);

            var p = price;

            if (!AddMenuItem(type, name, ref p))
            {
                return ItemNotAdded;
            }

            return p != price ? string.Format(PriceChanged, p) : ItemAdded;
        }
    }
}

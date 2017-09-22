using System.Collections.Generic;

namespace CashRegister
{
    /// <summary>
    /// default menu data
    /// </summary>
    public static class MenuDefaults
    {
        /// <summary>
        /// default menu items collection
        /// </summary>
        public static IEnumerable<MenuItemDto> DefaultMenuItems
        {
            get
            {
                return new List<MenuItemDto>
                {
                    new MenuItemDto { ServiceType = "All", ItemType = "Drink", Name = "Soda", Price = 3 },
                    new MenuItemDto { ServiceType = "All", ItemType = "Drink", Name = "Beer", Price = 4 },
                    new MenuItemDto { ServiceType = "All", ItemType = "Drink", Name = "Premium Beer", Price = 7 },
                    new MenuItemDto { ServiceType = "All", ItemType = "Drink", Name = "House Wine", Price = 5 },
                    new MenuItemDto { ServiceType = "All", ItemType = "Drink", Name = "Premium Wine", Price = 8 },
                    new MenuItemDto { ServiceType = "All", ItemType = "Drink", Name = "Rail Drink", Price = 6 },
                    new MenuItemDto { ServiceType = "All", ItemType = "Drink", Name = "Premium Drink", Price = 10 },
                    new MenuItemDto { ServiceType = "All", ItemType = "Food", Name = "Hamburger", Price = 7 },
                    new MenuItemDto { ServiceType = "All", ItemType = "Food", Name = "Hot Dog", Price = 4 },
                    new MenuItemDto { ServiceType = "All", ItemType = "Food", Name = "Pizza", Price = 10 },
                    new MenuItemDto { ServiceType = "All", ItemType = "Food", Name = "Special", Price = 8 },
                    new MenuItemDto { ServiceType = "All", ItemType = "Food", Name = "Side", Price = 4 },
                    new MenuItemDto { ServiceType = "All", ItemType = "Food", Name = "Dessert", Price = 6 }
                };
            }
        }
    }
}

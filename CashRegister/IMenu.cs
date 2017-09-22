using System.Collections.Generic;

namespace CashRegister
{
    public interface IMenu
    {
        List<MenuItem> DrinkItems { get; }
        List<MenuItem> FoodItems { get; }
        IRepository<MenuItem> MenuItemRepository { get; }

        bool AddMenuItem(string type, string name, ref decimal price, string service = "All");
        bool AddMenuItem(MenuItem item);

        IEnumerable<MenuItem> GetMenu();
        Order GetOrderByName(string name);
        Drink GetDrinkByName(string name);
        Food GetFoodByName(string name);

        bool UpdateName(string oldName, string newName);
        bool UpdatePrice(string name, decimal price);
    }
}

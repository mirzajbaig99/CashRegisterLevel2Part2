using System;
using System.Collections.Generic;
using System.Linq;

namespace CashRegister
{
    public class MenuRepository : IRepository<MenuItem>
    {
        #region private fields

        private readonly CashRegisterMapper mapper;

        //NOTE: Menu items are stored in memory (for now) as a collection of MenuItemDtos
        private readonly List<MenuItemDto> menuItemDtos; 

        #endregion

        public MenuRepository(CashRegisterMapper cashRegisterMapper = null)
        {
            this.mapper = cashRegisterMapper ?? new CashRegisterMapper();
            this.menuItemDtos = MenuDefaults.DefaultMenuItems.ToList();
        }

        //TODO: Also implement an Add(string itemType, string name, decimal price, string serviceType = "All") method that calls the Add(MenuItem item) method
        public bool Add(string itemType, string name, decimal price, string serviceType = "All")
        {
            throw new NotImplementedException();
        }

        //TODO: implement IRepository<MenuItem>
        //TODO:  => Wrap the implementation inside a “#region IRepository<MenuItem> implementation”
        //TODO:  => For any non-applicable methods (like “Get(int id)”), leave them as not implemented (throwing NotImplementedException())
        //TODO:  => If the item is null or is an existing item, return false
        //TODO:  => If the item is not a Drink or Food, throw and ArgumentException
        public bool Add(MenuItem item)
        {
            throw new NotImplementedException();
        }

        public bool Add(IEnumerable<MenuItem> items)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<MenuItem> Get()
        {
            throw new NotImplementedException();
        }

        public MenuItem Get(int id)
        {
            throw new NotImplementedException();
        }

        public MenuItem Get(string name)
        {
            throw new NotImplementedException();
        }

        public int GetNextId()
        {
            throw new NotImplementedException();
        }

        public bool Update(MenuItem item)
        {
            throw new NotImplementedException();
        }

        public bool Remove(MenuItem item)
        {
            throw new NotImplementedException();
        }
    }
}

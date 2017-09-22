using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CashRegister
{
    public class MenuItem
    {
        /// <summary>
        /// Service type can be Lunch, Dinner, or All
        /// </summary>
        public string ServiceType { get; set; }
        /// <summary>
        /// Item type can be Drink or Food
        /// </summary>
        public string ItemType { get; set; }
        /// <summary>
        /// Name of the menu item
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Price of the menu item
        /// </summary>
        public decimal Price { get; set; }
        /// <summary>
        /// temperature at which the menu item should be served
        /// </summary>
        public float Temperature { get; set; }
    }
}

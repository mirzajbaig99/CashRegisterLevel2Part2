using System;
using System.Collections.Generic;
using AutoMapper;

namespace CashRegister
{
    public class CashRegisterMapper
    {
        #region AutoMapper Exercise 1 Mappings

        public MenuItem MapToMenuItem(MenuItemDto menuItemDto)
        {
            return Mapper.Map<MenuItem>(menuItemDto);
            //TODO: AutoMapper Exercise 1 - return a MenuItem object mapped from a MenuItemDto class object
            
        }

        public MenuItemDto MapToMenuItemDto(MenuItem menuItem)
        {
            //TODO: AutoMapper Exercise 1 - return a MenuItemDto object mapped from a MenuItem class object
            return Mapper.Map<MenuItemDto>(menuItem);
        }

        public Order MapToOrder(OrderDto orderDto)
        {
            Order retval = null;
            //TODO: AutoMapper Exercise 1 - return either a Drink or Food object mapped from an OrderDto class object
            if(orderDto.ItemType == typeof(Drink).Name)
            {
                return Mapper.Map<Drink>(orderDto);
            }else if (orderDto.ItemType == typeof(Food).Name)
            {
                return Mapper.Map<Food>(orderDto);
            }else
            {
                throw new ArgumentException();
            }
            
        }

        #endregion

        #region AutoMapper Exercise 2 Mappings

        public IEnumerable<MenuItem> MapToMenuItems(IEnumerable<MenuItemDto> menuItemDtos)
        {
            //TODO: AutoMapper Exercise 2 - return a MenuItem IEnumerable object mapped from a MenuItemDto IEnumerable object
            return Mapper.Map<IEnumerable<MenuItem>>(menuItemDtos);
        }

        public IEnumerable<MenuItemDto> MapToMenuItemDtos(IEnumerable<MenuItem> menuItems)
        {
            //TODO: AutoMapper Exercise 2 - return a MenuItemDto IEnumerable object mapped from a MenuItem IEnumerable object
            return Mapper.Map<IEnumerable<MenuItemDto>>(menuItems);
        }

        #endregion

        #region AutoMapper Exercise 3 Mappings

        public OrderDto MapToOrderDto(Order order)
        {
            //TODO: Exercise 3 - return an OrderDto class object mapped from an Order object (which could be Drink or Food)
            return Mapper.Map<OrderDto>(order);
        }

        public IEnumerable<OrderDto> MapToOrderDtos(IEnumerable<Order> orders)
        {
            //TODO: Exercise 3 - return an IEnumerable<OrderDto> collection mapped from an IEnumerable<Order> collection 
            return Mapper.Map<IEnumerable<OrderDto>>(orders);
        }

        #endregion

        #region AutoMapper Exercise 4 Mappings

        public MenuItem MapToMenuItem(Order order)
        {
            //TODO: AutoMapper Exercise 4 - return a MenuItem object mapped from an Order class object
            return Mapper.Map<MenuItem>(order);
        }

        public Order MapToOrder(MenuItem menuItem)
        {
            //TODO: AutoMapper Exercise 4 - return either a Drink or Food object depending on menuItem.ItemType, mapped from a MenuItem class object
            //TODO: AutoMapper Exercise 4 - throw an ArgumentException with the ItemType if it’s not “Drink” or “Food”
            if(menuItem.ItemType == typeof(Drink).Name)
            {
                return Mapper.Map<Drink>(menuItem);
            }else if (menuItem.ItemType == typeof(Food).Name)
            {
                return Mapper.Map<Food>(menuItem);
            }
            else
            {
                throw new ArgumentException();
            }
        }

        public Ticket MapToTicket(TicketDto ticketDto)
        {
            //TODO: AutoMapper Exercise 4 - return a Ticket object mapped from a TicketDto class object
            return Mapper.Map<Ticket>(ticketDto);
        }

        public TicketDto MapToTicketDto(Ticket ticket)
        {
            //TODO: AutoMapper Exercise 4 - return a TicketDto object mapped from a Ticket class object
            return Mapper.Map<TicketDto>(ticket);
        }

        public IEnumerable<Ticket> MapToTickets(IEnumerable<TicketDto> ticketDtos)
        {
            //TODO: Exercise 4 - return an IEnumerable<Ticket> collection mapped from an IEnumerable<TicketDto> collection
            return Mapper.Map<IEnumerable<Ticket>>(ticketDtos);
        }

        public IEnumerable<TicketDto> MapToTicketDtos(IEnumerable<Ticket> tickets)
        {
            //TODO: Exercise 4 - return an IEnumerable<TicketDto> collection mapped from an IEnumerable<Ticket> collection
            return Mapper.Map<IEnumerable<TicketDto>>(tickets);
        }

        #endregion
    }
}

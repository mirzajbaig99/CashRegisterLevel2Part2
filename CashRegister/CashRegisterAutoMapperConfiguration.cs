using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;

namespace CashRegister
{
    public static class CashRegisterAutoMapperConfiguration
    {
        private static bool configurationHasRun;

        public static void Configure()
        {
            if (!configurationHasRun)
            {
                // AutoMapper Exercise 1
                ConfigureMappingsForAutoMapperExercise1();

                // AutoMapper Exercise 3
                ConfigureMappingsForAutoMapperExercise3();

                // AutoMapper Exercises 4, 5, and 6
                ConfigureMappingsForAutoMapperExercise4Thru6();

                //TODO: Exercise 1 - add code here to make sure your mappings are configured correctly
                Mapper.AssertConfigurationIsValid();
                configurationHasRun = true;
            }
        }

        /// <summary>
        /// Implements mapping requirements for AutoMapper Exercise 1
        /// </summary>
        private static void ConfigureMappingsForAutoMapperExercise1()
        {
            //TODO: Exercise 1 - define the mapping for MenuItemDto to MenuItem
            //TODO: Exercise 1    => use ReverseMap() to add the mapping for MenuItem to MenuItemDto
            Mapper.CreateMap<MenuItemDto, MenuItem>().ReverseMap();
            //TODO: Exercise 1 - define the mappings for OrderDto to Drink and Food
            Mapper.CreateMap<OrderDto, Drink>();
            Mapper.CreateMap<OrderDto, Food>();

            Mapper.CreateMap<OrderDto, Order>().ConvertUsing(
                x => {
                     if(x.ItemType == typeof(Drink).Name)
                    {
                        return Mapper.Map<Drink>(x);
                    }else
                    {
                        return Mapper.Map<Food>(x);
                    }
            });
        }   

        /// <summary>
        /// Implements mapping requirements for AutoMapper Exercise 3
        /// </summary>
        private static void ConfigureMappingsForAutoMapperExercise3()
        {
            //TODO: Exercise 3 - define the mapping for Order to OrderDto, getting the ItemType from the name of the source type
             Mapper.CreateMap<Order, OrderDto>()
                .ForMember(x => x.ItemType, s => s.ResolveUsing((Order x) => x.GetType().Name));
        }

        /// <summary>
        /// Implements mapping requirements for AutoMapper Exercises 4, 5, and 6
        /// </summary>
        private static void ConfigureMappingsForAutoMapperExercise4Thru6()
        {
            #region AutoMapper Exercise 4 requirements
            //TODO: Exercise 4 - define the mapping for Order to MenuItem
            //TODO: Exercise 4    => get the ItemType from the name of the source type
            //TODO: Exercise 4    => set ServiceType to "All"
            //TODO: Exercise 4    => ignore the Temperature property
            // look under exercise 6
            //Mapper.CreateMap<Order, MenuItem>()
            //   .ForMember(x => x.ServiceType, s => s.UseValue("All"))
            //   .ForMember(x => x.ItemType, s => s.MapFrom( src => src.GetType().Name))
            //   .ForMember(x => x.Temperature, s => s.Ignore());

            //TODO: Exercise 4 - define the mappings for MenuItem to Drink and Food, ignoring the Temperature property
           // Moved to Exercise 6

            //TODO: Exercise 4 - define the mapping for Ticket to TicketDto, ignoring IsPending
            //TODO: Exercise 4 - define the mapping for TicketDto to Ticket
            //TODO: Exercise 4    => ignore IsPending and all readonly properties
            //TODO: Exercise 4    => use .AfterMap() to map the OrderDto collection to the Order collection
            Mapper.CreateMap<Ticket, TicketDto>()
                .ForMember(x => x.IsPending, s => s.Ignore())
                .ReverseMap()
                .ForMember(x => x.Total, s => s.Ignore())
                .AfterMap((x,y) =>
                {
                    y.ItemsOrdered = Mapper.Map<IEnumerable<Order>>(x.ItemsOrdered).ToList();
                    
                }
                );

            /*
               * Mapper.CreateMap<TicketDto, Ticket>()
                  .AfterMap((s, d) =>{
                  d.ItemsOrdered = new List<Order>();
                  d.ItemsOrdered.AddRange(Mapper.Map<IEnumerable<Drink>>((s.ItemsOrdered.Where(i => i.ItemType == "Drink"))));
                  d.ItemsOrdered.AddRange(Mapper.Map<IEnumerable<Food>>((s.ItemsOrdered.Where(i => i.ItemType == "Food"))));
                  }).ForMember(dest => dest.ItemsOrdered, opt => opt.Ignore()).
                  IgnoreAllPropertiesWithAnInaccessibleSetter();
                  // IgnoreAllPropertiesWithAnInaccessibleSetter is for the newer version
               */

            #endregion

            #region AutoMapper Exercise 5 requirements

            //TODO: Exercise 5 - update the mapping for Order to MenuItem
            //TODO:            - convert the Temperature property from decimal to float
            Mapper.CreateMap<decimal, float>().ConvertUsing(Convert.ToSingle);

            //TODO: Exercise 5 - update the mappings for MenuItem to Drink and Food
            //TODO:            - convert the Temperature property from float to decimal
            Mapper.CreateMap<float, decimal>().ConvertUsing(Convert.ToDecimal);
            #endregion

            #region AutoMapper Exercise 6 requirements

            //TODO: Exercise 6 - update the mapping for Order to MenuItem
            //TODO:            - convert the Temperature property from Fahrenheit (decimal) to Celsius (float)
            //TODO:            - use CustomResolverFtoC
            Mapper.CreateMap<Order, MenuItem>()
              .ForMember(x => x.ServiceType, s => s.UseValue("All"))
              .ForMember(x => x.ItemType, s => s.MapFrom(src => src.GetType().Name))
              .ForMember(x => x.Temperature, s => s.ResolveUsing<CustomResolverFtoC>());

            //TODO: Exercise 6 - update the mapping for MenuItem to Drink and Food
            //TODO:            - convert the Temperature property from Celsius (float) to Fahrenheit (decimal)
            //TODO:            - use CustomResolverCtoF
            Mapper.CreateMap<MenuItem, Drink>()
                .ForMember(x => x.Temperature, s => s.ResolveUsing<CustomResolverCtoF>());
            Mapper.CreateMap<MenuItem, Food>()
                 .ForMember(x => x.Temperature, s => s.ResolveUsing<CustomResolverCtoF>());
            #endregion
        }
    }

    #region AutoMapper Exercise 6 Resolver class requirements

    //TODO: Exercise 6 - For the mapping from Order to MenuItem, create a CustomResolverFtoC class:
    //TODO:            - Its ResolveCore method should convert °Fahrenheit to °Celsius
    //TODO:            - Use this formula:  Celsius = ((Fahrenheit - 32) * 5 / 9)
    //TODO:            - Return the Celsius value as float
    public class CustomResolverFtoC : ValueResolver<Order, float>
    {
        protected override float ResolveCore(Order source)
        {
            return (float)((source.Temperature - 32) * 5 / 9);
        }
    }
    //TODO: Exercise 6 - For the mappings from MenuItem to Drink and Food, create a CustomResolverCtoF class
    //TODO:            - Its ResolveCore method should convert °Celsius to °Fahrenheit
    //TODO:            - Use this formula:  Fahrenheit = ((Celsius * 9 / 5) + 32)
    //TODO:            - Return the Fahrenheit value as decimal
    public class CustomResolverCtoF : ValueResolver<MenuItem, decimal>
    {
        protected override decimal ResolveCore(MenuItem source)
        {
            return Convert.ToDecimal(source.Temperature * 9 / 5) + 32;
        }
    }
    //public class CustomResolverCtoF : ITypeConverter<float,decimal>
    //{
    //    public decimal Convert(ResolutionContext context)
    //    {
    //        return System.Convert.ToDecimal((((float)context.SourceValue * 9 / 5) + 32));
    //    }
    //}
    #endregion

}


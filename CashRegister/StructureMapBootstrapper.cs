using System;
using StructureMap;


namespace CashRegister
{
    public static class StructureMapBootstrapper
    {
        public static IContainer Initialize()
        {
            IContainer myContainer = new Container();

            myContainer.Configure(registry =>
            {
                //TODO: Exercise 1 (Basic StructureMap) - create the StructureMap configurations in these four methods:
                ExerciseOne(registry);
                ExerciseTwo(registry);
                ExerciseThree(registry);
                ExerciseFour(registry);

                //TODO: Exercise 2 (Advanced StructureMap) - Add configurations in CashRegister StructureMap registry

                registry.AddRegistry(new CashRegisterRegistry());
            });
            return myContainer;
        }

        /// <summary>
        /// Inject instance of Ticket for ITicket
        /// </summary>
        /// <param name="registry"></param>
        public static void ExerciseOne(ConfigurationExpression registry)
        {
            //TODO - Inject instance of Ticket for ITicket
            throw new NotImplementedException();
        }

        /// <summary>
        /// Inject named instance Kitchen for ITakesOrder
        /// </summary>
        /// <param name="registry"></param>
        public static void ExerciseTwo(ConfigurationExpression registry)
        {
            //TODO - Inject instance of Kitchen for ITakesOrder called "Kitchen"
            throw new NotImplementedException();
        }

        /// <summary>
        /// Inject named instance 
        /// "ExpensiveDrink" of type Drink
        ///  for Order class with Price set to $10.00
        /// </summary>
        /// <param name="registry"></param>
        public static void ExerciseThree(ConfigurationExpression registry)
        {
            //TODO - Use setter injection and set the default price of named instance ExpensiveDrink to $10
            throw new NotImplementedException();
        }

        /// <summary>
        /// Constructor Inject for TicketRepository
        /// with new  instance of CashRegisterMapper
        /// </summary>
        /// <param name="registry"></param>
        public static void ExerciseFour(ConfigurationExpression registry)
        {
            //TODO - use constructor injection for TicketRepository and pass new instance of CashRegisterMapper
            throw new NotImplementedException();
        }
    }
}

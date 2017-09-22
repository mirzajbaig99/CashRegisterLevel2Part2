using StructureMap;
using StructureMap.Configuration.DSL;

namespace CashRegister
{
    public class CashRegisterRegistry : Registry
    {
        public CashRegisterRegistry()
        {
            CashRegisterAutoMapperConfiguration.Configure();

            this.Scan(scan =>
            {
                //TODO - Scan the registry with default convensions and calling assembly

                //TODO Add all types of IRepository<MenuItem> and IRepository<ITicket>

                //TODO - Inject singleton instance of Logger  for ILogger

                //TODO - Inject CashRegister for ICashRegister, Use Constructor injection for bar, kitchen and menu
            });
        }
    }
}

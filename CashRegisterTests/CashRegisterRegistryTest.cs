using CashRegister;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StructureMap;
using System.Collections.Generic;
using Registry = StructureMap.Registry;
using System.Linq;

namespace CashRegisterTests
{
    [TestClass]
    public class CashRegisterRegistryTest
    {
        private static IContainer container;

        [ClassInitialize]
        public static void ClassInit(TestContext context)
        {
            container = StructureMapBootstrapper.Initialize();
        }

        [TestMethod]
        public void TestExerciseOne()
        {
            //Arrange
            var registry = new Registry();
            registry.IncludeRegistry<CashRegisterRegistry>();
            var myContainer = new Container(registry);

            //Act
            var cashRegister = myContainer.GetInstance<IMenu>();

            //Assert
            Assert.AreEqual(typeof(Menu), cashRegister.GetType());
        }

        [TestMethod]
        public void TestExerciseTwo()
        {
            //Arrange, Act
            var ticketInstanceCount = container.GetAllInstances<IRepository<ITicket>>().Count();
            var menuInstanceCount = container.GetAllInstances<IRepository<MenuItem>>().Count();

            //Assert
            Assert.AreEqual(1, ticketInstanceCount);
            Assert.AreEqual(1, menuInstanceCount);
        }

        [TestMethod]
        public void TestExerciseThree()
        {
            //Arrange, Act
            var logger1 = container.GetInstance<ILogger>();
            var logger2 = container.GetInstance<ILogger>();

            //Assert
            Assert.AreSame(logger1, logger2);
        }

        [TestMethod]
        public void TestExerciseFour()
        {
            //Arrange
            var registry = new Registry();
            registry.IncludeRegistry<CashRegisterRegistry>();
            var myContainer = new Container(registry);

            //Act
            var cashRegister = myContainer.GetInstance<ICashRegister>();

            //Assert
            Assert.AreEqual(typeof(CashRegister.CashRegister), cashRegister.GetType());
        }

    }
}

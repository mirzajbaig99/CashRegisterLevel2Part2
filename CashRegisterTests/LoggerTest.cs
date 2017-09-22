using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CashRegister;

namespace CashRegisterTests
{
    [TestClass]
    public class LoggerTest
    {
        [TestMethod]
        public void TestLoggerHasLogInstanceProperty()
        {
            // Arrange
            var type = typeof(Logger);

            // Act
            var propertyInfo = type.GetProperty("Instance");

            // Assert
            Assert.IsNotNull(propertyInfo);
        }

        [TestMethod]
        public void TestLoggerIsSingleton()
        {
            // Arrange
            // Act
            //TODO: Singleton DP Exercise - Update TestLoggerIsSingleton’s Logger class to use the singleton so that this test will pass
            var logger1 = new Logger();
            var logger2 = new Logger();

            // Assert
            //Assert.AreEqual(logger1.GetHashCode(), logger2.GetHashCode());
            Assert.AreSame(logger1, logger2);
        }
    }
}

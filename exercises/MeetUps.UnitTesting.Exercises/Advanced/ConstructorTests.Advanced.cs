using NUnit.Framework;
using System;

namespace Tests
{
    public partial class ConstructorTests
    {
        //Based on MyClassAdvanced's constructor, build the corresponding tests
        [Test]
        public void MyClassAdvancedConstructor_NullLoggerFactory_ThrowsArgumentNullException()
        {
            Assert.Fail();
        }

        [Test]
        public void MyClassAdvancedConstructor_NotNullLoggerFactory_LoggerFactoryCreateLoggerIsCalled()
        {
            Assert.Fail();
        }

        [Test]
        public void MyClassAdvancedConstructor_NotNullLoggerFactory_MyClassAdvancedIsContructed()
        {
            Assert.Fail();
        }
    }

    internal class MyClassAdvanced
    {
        public Logger<MyClassAdvanced> Logger { get; }

        public MyClassAdvanced(ILoggerFactory loggerFactory)
        {
            if(loggerFactory == null)
            {
                throw new ArgumentNullException(nameof(loggerFactory));
            }

            Logger = loggerFactory.CreateLogger<MyClassAdvanced>();
        }
    }

    internal class Logger<T>
    {

    }

    internal interface ILoggerFactory
    {
        Logger<T> CreateLogger<T>();
    }
}
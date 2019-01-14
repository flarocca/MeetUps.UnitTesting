using MeetUps.UnitTesting.Domain.Advanced;
using MeetUps.UnitTesting.UnitTests.Advanced.Dummies;
using MeetUps.UnitTesting.UnitTests.Advanced.Fakes;
using MeetUps.UnitTesting.UnitTests.Advanced.Mocks;
using NUnit.Framework;
using System;

namespace Tests
{
    public class MockingTests
    {
        [Test(Description = "Mock example 1")]
        public void TurnOn_EngineStartIsCalled()
        {
            //Arrange
            var fuelTank = new FuelTank(50, 10);
            var mockEngine = new MockEngine(fuelTank);
            var car = new Car(2019, "Ford", mockEngine, new DummyInstrumental());

            //Act
            car.TurnOn();

            //Assert
            //How many times the function was call is extremely important
            Assert.AreEqual(1, mockEngine.StartCalls);
        }

        [Test(Description = "Mock plus fake example")]
        public void TurnOn_ExceptionIsThrown_EngineStopIsCalled()
        {
            //Arrange
            var fuelTank = new FuelTank(50, 10);
            var mockEngine = new MockEngine(fuelTank);
            var car = new Car(2019, "Ford", mockEngine, new FakeThrowsExceptionInstrumental());

            //Act
            car.TurnOn();

            //Assert
            Assert.AreEqual(1, mockEngine.StopCalls);
        }

        [Test(Description = "Callback example")]
        public void RefillFuelTank_FuncIsCalled()
        {
            //Arrange
            var expectedFuelTank = new FuelTank(50, 10);
            FuelTank actualFuelTank = null;
            var mockEngine = new MockEngine(expectedFuelTank);
            var refillerCallback = new Func<FuelTank, FuelTank>(tank => 
            {
                actualFuelTank = tank;
                return tank;
            }); 
            var car = new Car(2019, "Ford", mockEngine, new DummyInstrumental());

            //Act
            car.RefillFuelTank(refillerCallback);

            //Assert
            Assert.AreEqual(expectedFuelTank, actualFuelTank);
        }
    }
}
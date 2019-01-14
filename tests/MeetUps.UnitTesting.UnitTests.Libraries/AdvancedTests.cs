using FakeItEasy;
using FluentAssertions;
using MeetUps.UnitTesting.Domain.Advanced;
using MeetUps.UnitTesting.UnitTests.Advanced.Fakes;
using NUnit.Framework;
using System;
using Car = MeetUps.UnitTesting.Domain.Advanced.Car;

namespace Tests
{
    public class AdvancedTests
    {
        [Test(Description = "Fake example using FakeItEasy and FLuentAssertions")]
        public void GetFuelTankStatus_FuelTankIsEmpty_ReturnsFuelTankStatusEmpty()
        {
            //Arrange
            var expectedFuelTankStatus = FuelTankStatus.Empty;
            var fakeEngine = A.Fake<IEngine>();
            A.CallTo(() => fakeEngine.GetFuelTank()).Returns(new EmptyFuelTank());

            var car = new Car(2019, "Ford", fakeEngine, A.Fake<IInstrumental>());

            //Act
            var actualFuelTankStatus = car.GetFuelTankStatus();

            //Assert
            actualFuelTankStatus.Should().Be(expectedFuelTankStatus);
        }

        [Test(Description = "Mock example using FakeItEasy and FLuentAssertions")]
        public void TurnOn_EngineStartIsCalled()
        {
            //Arrange
            var fuelTank = new FuelTank(50, 10);
            var mockEngine = A.Fake<IEngine>();
            A.CallTo(() => mockEngine.GetFuelTank()).Returns(fuelTank);

            var car = new Car(2019, "Ford", mockEngine, A.Fake<IInstrumental>());

            //Act
            car.TurnOn();

            //Assert
            A.CallTo(() => mockEngine.Start()).MustHaveHappenedOnceExactly();
        }

        [Test(Description = "Callback example using FakeItEasy and FLuentAssertions")]
        public void RefillFuelTank_FuncIsCalled()
        {
            //Arrange
            var expectedFuelTank = new FuelTank(50, 10);
            var fakeEngine = A.Fake<IEngine>();
            A.CallTo(() => fakeEngine.GetFuelTank()).Returns(expectedFuelTank);

            var refillerCallback = A.Fake<Func<FuelTank, FuelTank>>();
            var car = new Car(2019, "Ford", fakeEngine, A.Fake<IInstrumental>());

            //Act
            car.RefillFuelTank(refillerCallback);

            //Assert
            A.CallTo(() => refillerCallback(expectedFuelTank)).MustHaveHappenedOnceExactly();
        }
    }
}
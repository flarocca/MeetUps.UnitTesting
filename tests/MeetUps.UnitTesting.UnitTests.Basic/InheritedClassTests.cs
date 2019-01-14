using MeetUps.UnitTesting.Domain.Basic;
using NUnit.Framework;

namespace Tests
{
    public class InheritedClassTests
    {
        [Test]
        public void TurnOn_FuelCarHasFuel_FuelCarIsTurnedOn()
        {
            //Arrange
            var car = new FuelCar(2019, "Ford", hasFuel: true);

            //Act
            car.TurnOn();

            //Assert
            Assert.IsTrue(car.IsTurnedOn);
        }

        [Test]
        public void TurnOn_FuelCarDoesNotHaveFuel_FuelCarIsNotTurnedOn()
        {
            //Arrange
            var car = new FuelCar(2019, "Ford", hasFuel: false);

            //Act
            car.TurnOn();

            //Assert
            Assert.IsFalse(car.IsTurnedOn);
        }
    }
}
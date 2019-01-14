using MeetUps.UnitTesting.Domain.Basic;
using NUnit.Framework;

namespace Tests
{
    public class ConstructorTests
    {
        [Test]
        public void Constructor_HasAirConditionAndHasAirbagAreNotPassed_FullEquipedCarIsProperlyConstructed()
        {
            //Act
            var car = new FullEquipedCar(1901, "maker");

            //Assert
            Assert.IsFalse(car.HasAirConditioning);
            Assert.IsFalse(car.HasAirbag);
        }

        [Test]
        public void Constructor_HasAirbagIsFalse_FullEquipedCarIsProperlyConstructed()
        {
            //Act
            var car = new FullEquipedCar(1901, "maker", hasAirConditioning: true);

            //Assert
            Assert.IsTrue(car.HasAirConditioning);
            Assert.IsFalse(car.HasAirbag);
        }

        [Test]
        public void Constructor_HasAirConditionAndHasAirbagArePassed_FullEquipedCarIsProperlyConstructed()
        {
            //Act
            var car = new FullEquipedCar(1901, "maker", hasAirConditioning: true, hasAirbag: true);

            //Assert
            Assert.IsTrue(car.HasAirConditioning);
            Assert.IsTrue(car.HasAirbag);
        }
    }
}
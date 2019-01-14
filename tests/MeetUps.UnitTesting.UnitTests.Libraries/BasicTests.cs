using FakeItEasy;
using FluentAssertions;
using MeetUps.UnitTesting.Domain.Advanced;
using MeetUps.UnitTesting.Domain.Basic;
using NUnit.Framework;
using System;
using Car = MeetUps.UnitTesting.Domain.Advanced.Car;

namespace Tests
{
    public class BasicTests
    {
        [Test(Description = "Libraries - Exceptions")]
        public void CarConstructor_NullEngine_ThrowsArgumentNullException()
        {
            //Arrange
            var fakeInstrumental = A.Fake<IInstrumental>();

            //Act
            var action = new Action(() => new Car(2019, "Ford", null, fakeInstrumental));

            //Arrange
            action.Should().Throw<ArgumentNullException>().WithMessage("*engine*");
        }

        [Test]
        public void Constructor_HasAirConditionAndHasAirbagAreNotPassed_FullEquipedCarIsProperlyConstructed()
        {
            //Act
            var car = new FullEquipedCar(1901, "maker");

            //Assert
            car.HasAirConditioning.Should().BeFalse();
            car.HasAirbag.Should().BeFalse();
        }
    }
}
using MeetUps.UnitTesting.Domain.Basic;
using NUnit.Framework;
using System;

namespace Tests
{
    public class AbstractClassTests
    {
        [Test]
        public void Constructor_ModelLowerThan1900_ThrowsArgumentException()
        {
            try
            {
                //Act
                var car = new TestAbstractCar(1899, "maker");

                Assert.Fail("The expected exception was not thrown.");
            }
            catch (Exception ex)
            {
                //Assert
                Assert.IsTrue(ex.Message.Contains("Model cannot be lower than 1900."));
            }
        }

        [Test]
        public void Constructor_NullMaker_ThrowsArgumentNullException()
        {
            try
            {
                //Act
                var car = new TestAbstractCar(1901, null);

                Assert.Fail("The expected exception was not thrown.");
            }
            catch (Exception ex)
            {
                //Assert
                Assert.IsTrue(ex.Message.Contains("maker"));
            }
        }

        [Test]
        public void Constructor_ModelGreaterThan1900AndNotNullNorEmptyMaker_CarIsConstructed()
        {
            //Arrange
            var model = 1901;
            var maker = "test maker";

            //Act
            var car = new TestAbstractCar(model, maker);

            //Assert
            Assert.AreEqual(maker, car.Maker);
            Assert.AreEqual(model, car.Model);
            Assert.IsFalse(car.IsTurnedOn);
        }
    }

    internal class TestAbstractCar : Car
    {
        public TestAbstractCar(int model, string maker)
            : base(model, maker)
        { }

        public override void TurnOn()
        { }
    }
}
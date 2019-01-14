using MeetUps.UnitTesting.Domain.Advanced;
using MeetUps.UnitTesting.UnitTests.Advanced.Dummies;
using MeetUps.UnitTesting.UnitTests.Advanced.Fakes;
using NUnit.Framework;
using System;

namespace Tests
{
    public class DummiesAndFakesTests
    {
        [Test(Description = "Dummy example 1")]
        public void CarConstructor_NullEngine_ThrowsArgumentNullException()
        {
            try
            {
                //Act
                var car = new Car(2019, "Ford", null, new DummyInstrumental());

                Assert.Fail("The expected exception was not thrown.");
            }
            catch (ArgumentNullException ex)
            {
                //Assert
                Assert.IsTrue(ex.Message.Contains("engine"));
            }
            catch (Exception)
            {
                Assert.Fail("The exception thrown is not the expected one.");
            }
        }

        [Test(Description = "Dummy example 2")]
        public void CarConstructor_NullInstrumental_ThrowsArgumentNullException()
        {
            try
            {
                //Act
                var car = new Car(2019, "Ford", new DummyEngine(), null);

                Assert.Fail("The expected exception was not thrown.");
            }
            catch (ArgumentNullException ex)
            {
                //Assert
                Assert.IsTrue(ex.Message.Contains("instrumental"));
            }
            catch (Exception)
            {
                Assert.Fail("The exception thrown is not the expected one.");
            }
        }

        [Test(Description = "Fake example")]
        public void GetFuelTankStatus_FuelTankIsEmpty_ReturnsFuelTankStatusEmpty()
        {
            //Arrange
            var expectedFuelTankStatus = FuelTankStatus.Empty;
            var fakeEngine = new FakeEngine(new EmptyFuelTank());
            var car = new Car(2019, "Ford", fakeEngine, new DummyInstrumental());

            //Act
            var actualFuelTankStatus = car.GetFuelTankStatus();

            //Assert
            Assert.AreEqual(expectedFuelTankStatus, actualFuelTankStatus);
        }
    }
}
using MeetUps.UnitTesting.Domain.Basic;
using NUnit.Framework;
using System;

namespace Tests
{
    public class ExceptionTests
    {
        [Test]
        public void Constructor_ModelLowerThan1900_ThrowsArgumentException()
        {
            //Arrange
            var expectedExcepcionMessage = "expectedMessage";
            var car = new ExceptionCar(1901, "maker", expectedExcepcionMessage);

            try
            {
                //Act
                car.TurnOn();

                Assert.Fail("The expected exception was not thrown.");
            }
            catch (ArgumentOutOfRangeException ex)
            {
                //Assert
                Assert.IsTrue(ex.Message.Contains(expectedExcepcionMessage));
            }
            catch (Exception)
            {
                Assert.Fail("The exception thrown is not the expected one.");
            }
        }
    }

    internal class ExceptionCar : Car
    {
        private readonly string _exceptionMessage;

        public ExceptionCar(int model, string maker, string exceptionMessage)
            : base(model, maker)
        {
            _exceptionMessage = exceptionMessage;
        }

        public override void TurnOn()
        {
            throw new ArgumentOutOfRangeException(string.Empty, _exceptionMessage);
        }
    }
}
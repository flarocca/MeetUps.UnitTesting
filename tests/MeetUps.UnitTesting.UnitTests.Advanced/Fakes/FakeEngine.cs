using MeetUps.UnitTesting.Domain.Advanced;


namespace MeetUps.UnitTesting.UnitTests.Advanced.Fakes
{
    /// <remarks>
    /// This is a fake because some behavior is forced. In this case
    /// the returning FuelTank can be pre-configured
    /// </remarks>
    internal class FakeEngine : IEngine
    {
        private readonly FuelTank _fuelTank;

        public FakeEngine(FuelTank fuelTank)
        {
            _fuelTank = fuelTank;
        }

        public FuelTank GetFuelTank()
        {
            return _fuelTank;
        }

        public void RefillFuelTank(FuelTank newFuelTank)
        {

        }

        public void Start()
        {

        }

        public void Stop()
        {

        }
    }
}

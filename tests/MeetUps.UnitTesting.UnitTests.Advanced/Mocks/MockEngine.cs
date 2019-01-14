using MeetUps.UnitTesting.Domain.Advanced;

namespace MeetUps.UnitTesting.UnitTests.Advanced.Mocks
{
    public class MockEngine : IEngine
    {
        private readonly FuelTank _fuelTank;

        public int StartCalls { get; private set; }

        public int StopCalls { get; private set; }

        public MockEngine(FuelTank fuelTank)
        {
            _fuelTank = fuelTank;
            StartCalls = 0;
            StopCalls = 0;
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
            StartCalls++;
        }

        public void Stop()
        {
            StopCalls++;
        }
    }
}

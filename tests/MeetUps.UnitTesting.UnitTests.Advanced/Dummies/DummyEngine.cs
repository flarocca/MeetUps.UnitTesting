using MeetUps.UnitTesting.Domain.Advanced;

namespace MeetUps.UnitTesting.UnitTests.Advanced.Dummies
{
    internal class DummyEngine : IEngine
    {
        public FuelTank GetFuelTank()
        {
            return null;
            // Eventually this will have to be
            // return new DummyFuelTank();
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

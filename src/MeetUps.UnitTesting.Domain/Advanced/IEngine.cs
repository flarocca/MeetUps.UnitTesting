namespace MeetUps.UnitTesting.Domain.Advanced
{
    public interface IEngine
    {
        void Start();

        void Stop();

        FuelTank GetFuelTank();
        void RefillFuelTank(FuelTank newFuelTank);
    }
}

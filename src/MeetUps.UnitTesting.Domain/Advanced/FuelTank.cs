namespace MeetUps.UnitTesting.Domain.Advanced
{
    public class FuelTank
    {
        public int CurrentLevel { get; }

        public int MaxCapacity { get; }

        public FuelTank(int currentLevel, int maxCapacity)
        {
            CurrentLevel = currentLevel;
            MaxCapacity = maxCapacity;
        }
    }
}

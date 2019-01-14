namespace MeetUps.UnitTesting.Domain.Basic
{
    public class FuelCar : Car
    {
        private readonly bool _hasFuel;

        public FuelCar(int model, string maker, bool hasFuel)
            : base(model, maker)
        {
            _hasFuel = hasFuel;
        }

        public override void TurnOn()
        {
            if (_hasFuel)
            {
                IsTurnedOn = true;
            }
        }
    }
}

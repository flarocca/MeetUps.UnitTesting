namespace MeetUps.UnitTesting.Domain.Basic
{
    public class FullEquipedCar : Car
    {
        public bool HasAirConditioning { get; }

        public bool HasAirbag { get; }

        public FullEquipedCar(int model, string maker, bool hasAirConditioning, bool hasAirbag)
        : base(model, maker)
        {
            HasAirConditioning = hasAirConditioning;
            HasAirbag = hasAirbag;
        }

        public FullEquipedCar(int model, string maker, bool hasAirConditioning)
        : this(model, maker, hasAirConditioning, false)
        { }

        public FullEquipedCar(int model, string maker)
        : this(model, maker, false, false)
        { }

        public override void TurnOn()
        { }
    }
}

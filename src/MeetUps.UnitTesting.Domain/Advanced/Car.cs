using System;

namespace MeetUps.UnitTesting.Domain.Advanced
{
    public class Car
    {
        public int Model { get; }

        public string Maker { get; }

        private readonly IEngine _engine;

        private readonly IInstrumental _instrumental;

        public Car(int model, string maker, IEngine engine, IInstrumental instrumental)
        {
            // Model and maker are not being validated just for simplicity
            Model = model;
            Maker = maker;
            _engine = engine ?? throw new ArgumentNullException(nameof(engine));
            _instrumental = instrumental ?? throw new ArgumentNullException(nameof(instrumental));
        }

        public void TurnOn()
        {
            /*
             Cases to be tested here:
             1- _engine.Start() is called
             2- _instrumental.TurnOn() is called
             3- If an exception is thrown -> _engine.Stop() is called
            */
            try
            {
                // If _engine.Start() fails, then nothing has changed
                // If _instrumental.TurnOn() fails then _engine has already started
                _engine.Start();
                _instrumental.TurnOn();
            }
            catch (Exception)
            {
                _engine.Stop();
            }
        }

        public FuelTankStatus GetFuelTankStatus()
        {
            var fuelTank = _engine.GetFuelTank();

            if (fuelTank.CurrentLevel == 0)
                return FuelTankStatus.Empty;

            if (fuelTank.CurrentLevel == fuelTank.MaxCapacity)
                return FuelTankStatus.Full;

            return FuelTankStatus.Middle;
        }

        /// <remarks>
        /// Good practice tip:
        /// When calling Funcs or Actions, always wrap them into a try/catch block
        /// An exception thrown in a callback should never take our system down
        /// </remarks>
        public void RefillFuelTank(Func<FuelTank, FuelTank> refiller)
        {
            /*
             Cases to be tested here:
             1- _engine.GetFuelTank() is called
             2- refiller is called using the fuelTank returned by _engine.GetFuelTank()
             3- _engine.RefillFuelTank() is called with:
                If no exception is thrown -> newFuelTank
                if exception is thrown    -> oldFuelTank
            */
            FuelTank newFuelTank;
            var oldFuelTank = _engine.GetFuelTank();

            try
            {
                newFuelTank = refiller(oldFuelTank);
            }
            catch (Exception)
            {
                newFuelTank = oldFuelTank;
            }

            _engine.RefillFuelTank(newFuelTank);
        }
    }
}

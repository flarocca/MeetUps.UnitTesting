using System;

namespace MeetUps.UnitTesting.Domain.Basic
{
    public abstract class Car
    {
        public int Model { get; private set; }

        public string Maker { get; private set; }

        public bool IsTurnedOn { get; protected set; }

        protected Car(int model, string maker)
        {
            if (model < 1900)
            {
                throw new ArgumentException("Model cannot be lower than 1900.");
            }

            if (maker == null)
            {
                throw new ArgumentNullException(nameof(maker));
            }

            if (string.IsNullOrWhiteSpace(maker))
            {
                throw new ArgumentException("Maker cannot be empty.", nameof(maker));
            }

            Model = model;
            Maker = maker;
            IsTurnedOn = false;
        }

        public abstract void TurnOn();
    }
}

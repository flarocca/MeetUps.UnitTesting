using MeetUps.UnitTesting.Domain.Advanced;

namespace MeetUps.UnitTesting.UnitTests.Advanced.Fakes
{
    public class FakeThrowsExceptionInstrumental : IInstrumental
    {
        public void TurnOn()
        {
            throw new System.NotImplementedException();
        }
    }
}

using MeetUps.UnitTesting.Domain.Advanced;

namespace MeetUps.UnitTesting.UnitTests.Advanced.Fakes
{
    /// <remarks>
    /// This is a fake because some behavior is forced. In this case
    /// behaving as an empty tank.
    /// 
    /// This class can be seen as redundant since this could be equally done
    /// using new FuelTank(0, 0)
    /// 
    /// In this way, it is explicitly manifested what the class does.
    /// Semantic is important, provides rediability and reduces complexity
    /// </remarks>
    public class EmptyFuelTank : FuelTank
    {
        public EmptyFuelTank() : base(0, 0)
        {
        }
    }
}

using NUnit.Framework;

namespace Tests
{
    public class FunctionsAndMethodsTests
    {
        [Test]
        public void GetBalance_NoOperations_ReturnsCurrentBalance()
        {
            //Arrange
            var initialBalance = 100;
            var account = new Account(initialBalance);

            //Act
            var actualBalance = account.GetBalance();

            //Assert
            Assert.AreEqual(initialBalance, actualBalance);
        }

        [Test]
        public void Withdraw_PositiveAmmount_BalanceIsModified()
        {
            //Arrange
            var initialBalance = 100;
            var withdrawalAmmount = 50;
            var expectedBalance = initialBalance - withdrawalAmmount;
            var account = new Account(initialBalance);

            //Act
            account.Withdraw(withdrawalAmmount);

            //Assert
            var actualBalance = account.GetBalance();
            Assert.AreEqual(expectedBalance, actualBalance);
        }
    }

    public class Account
    {
        private int _balance;

        public Account(int initialBalance)
        {
            _balance = initialBalance;
        }

        public void Withdraw(int ammount)
        {
            _balance -= ammount;
        }

        public int GetBalance()
        {
            return _balance;
        }
    }
}

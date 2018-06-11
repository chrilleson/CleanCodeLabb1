using CleanCodeLabb1;
using System;
using Xunit;

namespace XUnitTestCleanCodeLabb1
{
    public class UnitTest1
    {
        [Fact]
        public void DepositIncrementBalance()
        {
            Account account = new Account(200.00);

            double deposit = 50.00;
            account.Deposit(deposit);
            double actualBalance = account.Balance;
            double expectedBalance = 250.00;
            Assert.Equal(actualBalance, expectedBalance);
        }

        [Fact]
        public void DepositShouldThrowIfAmountIsUnderLimit()
        {
            Account account = new Account(200.00);

            Assert.Throws<Exception>(() =>
            {
                account.Deposit(-50);
            });
        }

        [Fact]
        public void DepositShouldThrowIfAmountIsNaN()
        {
            Account account = new Account(200.00);

            Assert.Throws<Exception>(() =>
            {
                account.Deposit(double.NaN);
            });
        }

        [Fact]
        public void DepositShouldThrowIfPositiveInfinity()
        {
            Account account = new Account(200.00);

            Assert.Throws<Exception>(() =>
            {
                account.Deposit(double.PositiveInfinity);
            });
        }

        [Fact]
        public void DepositShouldThrowIfNegativeInfinity()
        {
            Account account = new Account(200.00);

            Assert.Throws<Exception>(() =>
            {
                account.Deposit(double.NegativeInfinity);
            });
        }
    }
}

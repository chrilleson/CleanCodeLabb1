using CleanCodeLabb1;
using System;
using Xunit;

namespace XUnitTestCleanCodeLabb1
{
    public class AccountTest
    {

        #region Account
        [Theory]
        [InlineData(-200.00)]
        [InlineData(0)]
        [InlineData(double.NaN)]
        [InlineData(double.PositiveInfinity)]
        [InlineData(double.NegativeInfinity)]
        public void Constructor_ShouldThrowForInalidValuesForBalance(double initialBalance)
        {
            Assert.Throws<Exception>(() =>
            {
                Account account = new Account(initialBalance);
            });
        }

        [Fact]
        public void Accounct_ShouldBeSuccessful()
        {
            Account account = new Account(200.00);
        }

        #endregion

        #region Deposit

        [Theory]
        [InlineData(-50.00)]
        [InlineData(0)]
        [InlineData(double.NaN)]
        [InlineData(double.PositiveInfinity)]
        [InlineData(double.NegativeInfinity)]
        public void Deposit_ShouldThrowForInvalidValues(double amount)
        {
            Account account = new Account(200.00);

            Assert.Throws<Exception>(() =>
            {
                account.Deposit(amount);

            });
        }


        [Fact]
        public void Deposit_ShouldBeSuccessful()
        {
//            const double intiialBalance = 200;
            Account account = new Account(200.00);

            double deposit = 50.00;
            account.Deposit(deposit);
            double actualBalance = account.Balance;
            double expectedBalance = 250.00;
            Assert.Equal(expectedBalance, actualBalance);
        }

        #endregion

        #region Withdraw

        [Theory]
        [InlineData(1000.00)]
        [InlineData(0)]
        [InlineData(-100)]
        [InlineData(double.NaN)]
        [InlineData(double.PositiveInfinity)]
        [InlineData(double.NegativeInfinity)]
        public void Withdraw_ShouldThrowException(double amount)
        {
            Account account = new Account(200.00);

            Assert.Throws<Exception>(() =>
            {
                account.Withdraw(amount);
            });
        }

        [Fact]
        public void Withdraw_ShouldBeSuccessful()
        {
            Account account = new Account(200.00);

            double withdraw = 50.00;
            account.Withdraw(withdraw);
            double actualBalance = account.Balance;
            double expectedBalance = 150.00;

            Assert.Equal(expectedBalance, actualBalance);
        }

        #endregion

        #region Transfer

        [Theory]
        [InlineData(double.NaN)]
        [InlineData(double.PositiveInfinity)]
        [InlineData(double.NegativeInfinity)]
        [InlineData(500.00)]
        public void Transfer_ShouldThrowException(double amount)
        {
            Account account = new Account(200.00);
            Account targetAccount = new Account(1000.00);

            Assert.Throws<Exception>(() =>
            {
                account.Transfer(targetAccount, amount);
            });
        }

        [Fact]
        public void Transfer_ShouldThrowException_InvalidAccount()
        {
            Account account = new Account(200.00);
            double amount = 100.00;

            Assert.Throws<Exception>(() =>
            {
                account.Transfer(account, amount);
            });
        }

        [Fact]
        public void Transfer_ShouldThrowException_TargetAccountNull()
        {
            Account account = new Account(200.00);
            Account targetAccount = null;
            double amount = 100.00;

            Assert.Throws<Exception>(() =>
            {
                account.Transfer(targetAccount, amount);
            });
        }

        [Fact]
        public void Transfer_ShouldBeSuccessful_TotargetAccount()
        {
            Account account = new Account(200.00);
            Account targetAccount = new Account(1000.00);
            double amount = 100.00;

            account.Transfer(targetAccount, amount);

            double expectedTargetAccountBalance = 1100.00;
            double actualTargetAccountBalance = targetAccount.Balance;

            Assert.Equal(expectedTargetAccountBalance, actualTargetAccountBalance);
        }

        [Fact]
        public void Transfer_ShouldBeSuccessful_FromOriginalAccount()
        {
            Account account = new Account(1000.00);
            Account targetAccount = new Account(500.00);
            double amount = 500.00;

            account.Transfer(targetAccount, amount);

            double expectedAccountBalance = 500.00;
            double actualAccountBalance = account.Balance;

            Assert.Equal(expectedAccountBalance, actualAccountBalance);
        }

        #endregion

    }
}

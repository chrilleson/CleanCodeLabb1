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
            Assert.Equal(expectedBalance, actualBalance);
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

        [Fact]
        public void WithdrawDecreaseBalance()
        {
            Account account = new Account(200.00);

            double withdraw = 50.00;
            account.Withdraw(withdraw);
            double actualBalnace = account.Balance;
            double expectedBalance = 150.00;

            Assert.Equal(expectedBalance, actualBalnace);
        }

        [Fact]
        public void WithdrawShouldThrowIfUnavailableFunds()
        {
            Account account = new Account(200.00);

            Assert.Throws<Exception>(() =>
            {
                account.Withdraw(250.00);
            });
        }

        [Fact]
        public void WithdrawShouldThrowIfAmountIsNegative()
        {
            Account account = new Account(200.00);

            Assert.Throws<Exception>(() =>
            {
                account.Withdraw(-50.00);
            });
        }

        [Fact]
        public void WithdrawShouldThrowIfNaN()
        {
            Account account = new Account(200.00);

            Assert.Throws<Exception>(() =>
            {
                account.Withdraw(double.NaN);
            });
        }

        [Fact]
        public void WithdrawShouldThrowIfPositiveInfinity()
        {
            Account account = new Account(200.00);

            Assert.Throws<Exception>(() =>
            {
                account.Withdraw(double.PositiveInfinity);
            });
        }

        [Fact]
        public void WithdrawShouldThrowIfNegativeInfinity()
        {
            Account account = new Account(200.00);

            Assert.Throws<Exception>(() =>
            {
                account.Withdraw(double.NegativeInfinity);
            });
        }

        [Fact]
        public void TransferShouldTransferToSavingsIfSuccessful()
        {
            Account account = new Account(200.00);
            Account savingsAccount = new Account(1000);

            double amount = 100;
            account.Transfer(savingsAccount, amount);
            double actualBalance = savingsAccount.Balance;
            double expectedBalance = 1100;
            Assert.Equal(expectedBalance, actualBalance);
        }

        [Fact]
        public void TransferShouldWithdrawFromAccountIfSuccessful()
        {
            Account account = new Account(200.00);
            Account savingsAccount = new Account(1000);

            double amount = 100;
            account.Transfer(savingsAccount, amount);
            double actualBalance = account.Balance;
            double expectedBalance = 100;
            Assert.Equal(expectedBalance, actualBalance);
        }

        [Fact]
        public void TransferShouldThrowIfAmountToTransferIsNegative()
        {
            Account account = new Account(200.00);
            Account savingsAccount = new Account(50);

            Assert.Throws<Exception>(() =>
            {
                account.Transfer(savingsAccount, -1);
            });
        }

        [Fact]
        public void TransferShouldThrowIfTransferingToSameAccount()
        {
            Account account = new Account(200.00);

            Assert.Throws<Exception>(() =>
            {
                account.Transfer(account, 5);
            });
        }

        [Fact]
        public void TransferShouldThrowIfNull()
        {
            Account account = new Account(200.00);
            Account savingsAccount = new Account(50);

            Assert.Throws<Exception>(() =>
            {
                account.Transfer(null, 0);
            });
        }

        [Fact]
        public void TransferShouldThrowIfNaN()
        {
            Account account = new Account(200.00);
            Account savingsAccount = new Account(50);

            Assert.Throws<Exception>(() =>
            {
                account.Transfer(savingsAccount, double.NaN);
            });
        }

        [Fact]
        public void TransferShouldThrowIfPositiveInfinity()
        {
            Account account = new Account(200.00);
            Account savingsAccount = new Account(50);

            Assert.Throws<Exception>(() =>
            {
                account.Transfer(savingsAccount, double.PositiveInfinity);
            });
        }

        [Fact]
        public void TransferShouldThrowIfNegativeInfinity()
        {
            Account account = new Account(200.00);
            Account savingsAccount = new Account(50);

            Assert.Throws<Exception>(() =>
            {
                account.Transfer(savingsAccount, double.NegativeInfinity);
            });
        }
    }
}

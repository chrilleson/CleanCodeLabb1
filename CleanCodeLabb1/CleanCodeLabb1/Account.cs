using System;
using System.Collections.Generic;
using System.Text;

namespace CleanCodeLabb1
{
    public class Account
    {
        public double Balance { get; private set; }

        public Account(double initialBalance)
        {
            if (initialBalance <= 0)
                throw new Exception("Your balance cannot be under 1 SEK.");
            if (double.IsNaN(initialBalance))
                throw new Exception("Your balance is not a number.");
            if (double.IsPositiveInfinity(initialBalance) || double.IsNegativeInfinity(initialBalance))
                throw new Exception("Your balbance have exceeded the infinity limit.");
            else
                this.Balance = initialBalance;
        }

        public void Deposit(double amount)
        {
            if (amount <= 0)
                throw new Exception("Unable to deposit under 1 SEK.");
            if (double.IsNaN(amount))
                throw new Exception("Unable to deposit. The amount is not a number.");
            if (double.IsPositiveInfinity(amount) || double.IsNegativeInfinity(amount))
                throw new Exception("Unable to deposit. The amount has exceeded the infinity limit.");
            else
                this.Balance = this.Balance + amount;
        }

        public void Withdraw(double amount)
        {
            if (amount > this.Balance)
                throw new Exception("Unable to withdraw. There is not enough balance on the account.");
            if (amount <= 0)
                throw new Exception("Unable to withdraw. The amount cannot be under 1 SEK.");
            if (double.IsNaN(amount))
                throw new Exception("Unable to withdraw. The amount is not a number.");
            if (double.IsPositiveInfinity(amount) || double.IsNegativeInfinity(amount))
                throw new Exception("Unable to withdraw. The amount exceeded the infinity limit.");
            else
                this.Balance = this.Balance - amount;
        }

        public bool Transfer(Account target, double amount)
        {
            if (this == target)
                throw new Exception("Unable to transfer. You cannot transfer to the same accout.");
            if (target == null)
                throw new Exception("Unable to transfer. Your target account is null.");
            if (Balance < amount)
                throw new Exception("Unable to transfer. Your account do not have enough funds for the transfer.");
            if (double.IsNaN(amount))
                throw new Exception("Unable to transfer. The amount is not a number:");
            if (double.IsPositiveInfinity(amount) || double.IsNegativeInfinity(amount))
                throw new Exception("Unable to transfer. The amount exceeded the infinity limit.");

            target.Balance += amount;
            Balance -= amount;

            return true;
        }
    }
}

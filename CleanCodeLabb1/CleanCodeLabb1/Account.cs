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
            this.Balance = initialBalance;
        }

        public void Deposit(double amount)
        {
            if (amount <= 0)
                throw new Exception("Unable to deposit under 1 SEK.");
            if (double.IsNaN(amount))
                throw new Exception("Unable to deposit. The amount is not a number.");
            else if (double.IsPositiveInfinity(amount) || double.IsNegativeInfinity(amount))
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
            else if (double.IsPositiveInfinity(amount) || double.IsNegativeInfinity(amount))
                throw new Exception("Unable to withdraw. The amount exceeded the infinity limit.");
            else
                this.Balance = this.Balance - amount;
        }

        public bool Transfer(Account target, double amount)
        {
            if (this == target)
                throw new Exception("Unable to transfer. You cannot transfer to the same accout.");
            else if (double.IsNaN(amount))
                throw new Exception("Unable to transfer. The amount is not a number:");
            else if (double.IsPositiveInfinity(amount) || double.IsNegativeInfinity(amount))
                throw new Exception("Unable to transfer. The amount exceeded the infinity limit.");
            else if (amount < this.Balance)
            {
                this.Withdraw(amount);
                target.Deposit(amount);
                return true;
            }
            else
                return false;
        }
    }
}

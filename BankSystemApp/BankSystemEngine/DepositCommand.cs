using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankSystemEngine
{
    /// <summary>
    /// Deposite command to do the deposit.
    /// </summary>
    public class DepositCommand : ICommand
    {
        private BankAccount acc;
        private double prevAmount;
        private double depositAmount;

        /// <summary>
        /// Initializes a new instance of the <see cref="DepositCommand"/> class.
        /// Deposit Comma Constructor.
        /// </summary>
        /// <param name="acc"> bank acc. </param>
        /// <param name="amount"> amount deposit. </param>
        public DepositCommand(BankAccount acc, double amount)
        {
            this.acc = acc;
            this.prevAmount = amount;
            this.depositAmount = amount;
        }

        /// <summary>
        /// Execute the deposite.
        /// </summary>
        /// <returns> can execute or not. </returns>
        public bool Execute()
        {
            return this.acc.Deposit(this.depositAmount);
        }

        /// <summary>
        /// Unexecute the deposite.
        /// </summary>
        public void Unexecute()
        {
            this.acc.Withdraw(this.prevAmount);
        }

        /// <summary>
        /// Get the deposit amount.
        /// </summary>
        /// <returns> deposit amount. </returns>
        public double GetDepositAmount()
        {
            return this.depositAmount;
        }
    }
}

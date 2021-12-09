using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankSystemEngine
{
    /// <summary>
    /// Withdraw command class to handle the withdraw.
    /// </summary>
    public class WithdrawCommand : ICommand
    {


        private BankAccount acc;
        private double prevAmount;
        private double withdrawAmount;

        /// <summary>
        /// Initializes a new instance of the <see cref="WithdrawCommand"/> class.
        /// </summary>
        /// <param name="acc"> account number. </param>
        /// <param name="amount"> amount deposit. </param>
        public WithdrawCommand(BankAccount acc, double amount)
        {
            this.acc = acc;
            this.prevAmount = amount;
            this.withdrawAmount = amount;
        }

        /// <summary>
        /// Execute the withdraw.
        /// </summary>
        /// <returns> can withdraw or not. </returns>
        public bool Execute()
        {
            return this.acc.Withdraw(this.withdrawAmount);

        }

        /// <summary>
        /// Unexecute the withdraw.
        /// </summary>
        public void Unexecute()
        {
            this.acc.Deposit(this.prevAmount);
        }

        /// <summary>
        /// Get the withdraw amount.
        /// </summary>
        /// <returns> withdraw amount. </returns>
        public double GetWithdrawAmount()
        {
            return this.withdrawAmount;
        }
    }
}

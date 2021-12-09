using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankSystemEngine
{
    /// <summary>
    /// Loan account inherited from bank account.
    /// </summary>
    public class LoanAccount : BankAccount
    {
        /// <summary>
        /// The loan limit. The constrain of loan amount.
        /// </summary>
        private readonly double loanLimit;

        /// <summary>
        /// The loan interest default rate.
        /// </summary>
        private readonly double interest = 8.8;

        /// <summary>
        /// Initializes a new instance of the <see cref="LoanAccount"/> class.
        /// </summary>
        /// <param name="accNumber"> account number. </param>
        /// <param name="loanLimit"> loan limit. </param>
        public LoanAccount(int accNumber, double loanLimit)
            : base(accNumber)
        {
            this.loanLimit = loanLimit;
        }

        /// <summary>
        /// Loan acc borrow money interface by command pattern.
        /// </summary>
        /// <param name="command">Deposit command. </param>
        /// <returns>can borrow or cannot. </returns>
        public bool RequestLoan(DepositCommand command)
        {
            bool canBorrow = this.EnsureLoanLimitBound(command.GetDepositAmount());
            if (canBorrow)
            {
                // distribute the load amount to the balance.
                command.Execute();
            }

            return canBorrow;
        }

        /// <summary>
        /// Loan acc pay load interface by command pattern.
        /// </summary>
        /// <param name="command">Withdraw command. </param>
        /// <returns> can pay or cannot. </returns>
        public bool PayOffLoan(WithdrawCommand command)
        {
            bool success = command.Execute();
            return success;
        }

        /// <summary>
        /// Show client the interest rate.
        /// </summary>
        /// <returns> string of interest rate. </returns>
        public string GetAccountInterestRate()
        {
            return string.Empty;
        }

        /// <summary>
        /// Thrid Party Interface: interest accumulates from borrowed amount.
        /// </summary>
        private void InterestAccumulation()
        {
        }

        /// <summary>
        /// To ensure that exceed the loan limit.
        /// </summary>
        /// <param name="amount"> amount borrow. </param>
        /// <returns> exceed the limit or not. </returns>
        private bool EnsureLoanLimitBound(double amount)
        {
            if ((this.GetAccBalance() + amount) > this.loanLimit)
            {
                Console.WriteLine("* <Failure>: The amount loan request exceed your loan limit. Your remaining limit is: $" + (this.loanLimit - this.GetAccBalance()));
                return false;
            }

            return true;
        }
    }
}

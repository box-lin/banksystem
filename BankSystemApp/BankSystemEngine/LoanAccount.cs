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
    }
}

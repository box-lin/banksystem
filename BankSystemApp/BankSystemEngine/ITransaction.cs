using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankSystemEngine
{

    /// <summary>
    /// A interface that required bank account to implement the transaction info.
    /// </summary>
    public interface ITransaction
    {
        /// <summary>
        /// Method that required for bank account to keep update the transcation record after each transaction.
        /// </summary>
        /// <param name="accNumber"> bank account number. </param>
        /// <param name="transactionType"> transaction type. </param>
        /// <param name="transactionAmount"> amount transaction. </param>
        /// <param name="balance"> balance after transaction. </param>
        /// <param name="transactionTime"> time transaction occur. </param>
        void UpdateTransaction(int accNumber, string transactionType, double transactionAmount, double balance, string transactionTime);
    }
}

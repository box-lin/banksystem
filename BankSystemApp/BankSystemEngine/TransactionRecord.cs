// <copyright file="TransactionRecord.cs" company="Boxiang Lin - WSU 011601661">
// Copyright (c) Boxiang Lin - WSU 011601661. All rights reserved.
// </copyright>

namespace BankSystemEngine
{
    /// <summary>
    /// A class container to store the information capture in each transaction.
    /// </summary>
    public class TransactionRecord
    {
        private readonly int accNumber;
        private readonly string transactionType;
        private readonly double transactionAmount;
        private readonly double balance;
        private readonly string transactionTime;

        /// <summary>
        /// Initializes a new instance of the <see cref="TransactionRecord"/> class.
        /// </summary>
        /// <param name="accNumber"> bank account number. </param>
        /// <param name="transactionType"> transaction type. </param>
        /// <param name="transactionAmount"> amount transaction. </param>
        /// <param name="balance"> balance after transaction. </param>
        /// <param name="transactionTime"> time transaction occur. </param>
        public TransactionRecord(int accNumber, string transactionType, double transactionAmount, double balance, string transactionTime)
        {
            this.accNumber = accNumber;
            this.transactionType = transactionType;
            this.transactionAmount = transactionAmount;
            this.balance = balance;
            this.transactionTime = transactionTime;
        }

        /// <summary>
        /// Overrides the tostring for the use of print object.
        /// </summary>
        /// <returns> string representation. </returns>
        public override string ToString()
        {
            return "--> Account Number: #" + this.accNumber +
                   ", \tTransaction Type: " + this.transactionType +
                   ", \tTransaction Amount: $" + this.transactionAmount
                    + ", \tBalance After: $" + this.balance + ", \tDate: " + this.transactionTime;
        }
    }
}

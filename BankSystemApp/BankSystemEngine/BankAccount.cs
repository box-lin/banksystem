// <copyright file="BankAccount.cs" company="Boxiang Lin - WSU 011601661">
// Copyright (c) Boxiang Lin - WSU 011601661. All rights reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankSystemEngine
{
    /// <summary>
    /// Generic bankaccount abstract.
    /// </summary>
    public abstract class BankAccount
    {
        private int accNumber;
        private double accBalance;

        /// <summary>
        /// Initializes a new instance of the <see cref="BankAccount"/> class.
        /// </summary>
        /// <param name="accNumber"> int acc number.</param>
        public BankAccount(int accNumber)
        {
            this.accNumber = accNumber;
            this.accBalance = 0.0;
        }

        /// <summary>
        /// Use to set the acc number.
        /// </summary>
        /// <param name="accNumber"> int acc number. </param>
        public void SetAccNumber(int accNumber)
        {
        }

        /// <summary>
        /// Use to get the acc number.
        /// </summary>
        /// <returns> acc number. </returns>
        public int GetAccNumber()
        {
            return 0;
        }

        /// <summary>
        /// Use to get the account balance.
        /// </summary>
        /// <returns> acc balance. </returns>
        public double GetAccBalance()
        {
            return 0;
        }

        /// <summary>
        /// Use to deposit amount into the acc balance.
        /// </summary>
        /// <param name="amount"> amount of money. </param>
        /// <returns> can deposit or not. </returns>
        public bool Deposit(double amount)
        {
            return true;
        }

        /// <summary>
        /// Use to withdraw amount from acc balance.
        /// </summary>
        /// <param name="amount"> amount of money. </param>
        /// <returns> can withdraw or not. </returns>
        public bool Withdraw(double amount)
        {
            return true;
        }

        /// <summary>
        /// Use to set the account balance.
        /// Protected usage for only deriving classes.
        /// </summary>
        /// <param name="result"> the specific amount. </param>
        protected void SetAccBalance(double result)
        {
        }
    }
}

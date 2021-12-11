// <copyright file="SavingAccount.cs" company="Boxiang Lin - WSU 011601661">
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
    /// Saving account inherited from bankaccount.
    /// </summary>
    public class SavingAccount : BankAccount
    {
        /// <summary>
        /// Default interest rate gain for saving account.
        /// </summary>
        private readonly double interest = 0.5;

        /// <summary>
        /// Initializes a new instance of the <see cref="SavingAccount"/> class.
        /// </summary>
        /// <param name="accNumber"> account number. </param>
        public SavingAccount(int accNumber)
            : base(accNumber)
        {
        }

        /// <summary>
        /// Saving acc deposit interface by Command pattern.
        /// </summary>
        /// <param name="command"> Deposit command. </param>
        /// <returns> can deposit or not. </returns>
        public bool DepositSaving(DepositCommand command)
        {
            bool isSuccess = command.Execute();
            if (isSuccess)
            {
                this.NewCommandAdd(command);
            }

            return isSuccess;
        }

        /// <summary>
        /// Saving acc withdraw interface by COmmand pattern.
        /// </summary>
        /// <param name="command"> Withdraw Command. </param>
        /// <returns> can withdraw or not. </returns>
        public bool WithdrawSaving(WithdrawCommand command)
        {
            bool isSuccess = command.Execute();
            if (isSuccess)
            {
                this.NewCommandAdd(command);
            }
            else
            {
                Console.WriteLine("* <Failure>: Sorry there is no sufficient amount for withdraw. Your balance is: " + this.GetAccBalance());
            }

            return isSuccess;
        }

        /// <summary>
        /// Show user the interest rate.
        /// </summary>
        /// <returns> interest rate in string. </returns>
        public string GetAccountInterestRate()
        {
            return this.interest + "%";
        }
    }
}

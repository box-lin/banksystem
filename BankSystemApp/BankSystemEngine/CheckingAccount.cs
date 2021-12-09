// <copyright file="CheckingAccount.cs" company="Boxiang Lin - WSU 011601661">
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
    /// Checking Account inherited from bankaccount.
    /// </summary>
    public class CheckingAccount : BankAccount
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CheckingAccount"/> class.
        /// </summary>
        /// <param name="accNumber"> account number. </param>
        public CheckingAccount(int accNumber)
            : base(accNumber)
        {
        }

        /// <summary>
        /// Check acc deposit interface by command pattern.
        /// </summary>
        /// <param name="command"> Deposit command. </param>
        /// <returns> can deposit or not. </returns>
        public bool DepositChecking(DepositCommand command)
        {
            bool isSuccess = command.Execute();
            return isSuccess;
        }

        /// <summary>
        /// Check acc withdraw interface by command pattern.
        /// </summary>
        /// <param name="command"> Withdraw command. </param>
        /// <returns> can withdraw or not. </returns>
        public bool WithdrawChecking(WithdrawCommand command)
        {
            bool isSuccess = command.Execute();
            return isSuccess;
        }
    }
}

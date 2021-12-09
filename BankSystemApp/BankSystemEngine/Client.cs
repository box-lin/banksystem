// <copyright file="Client.cs" company="Boxiang Lin - WSU 011601661">
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
    /// Client class.
    /// </summary>
    public class Client : User
    {
        /// <summary>
        /// These dictionaries to store different type of account a client composes of.
        /// </summary>
        private Dictionary<int, SavingAccount> savingAccounts;
        private Dictionary<int, CheckingAccount> checkingAccounts;
        private Dictionary<int, LoanAccount> loanAccounts;

        /// <summary>
        /// Initializes a new instance of the <see cref="Client"/> class.
        /// </summary>
        /// <param name="userName"> username. </param>
        /// <param name="passWord"> password. </param>
        /// <param name="firstName"> firstname. </param>
        /// <param name="lastName"> lastname. </param>
        /// <param name="email"> email. </param>
        public Client(string userName, string passWord, string firstName, string lastName, string email)
            : base(userName, passWord, firstName, lastName, email)
        {
            this.savingAccounts = new Dictionary<int, SavingAccount>();
            this.checkingAccounts = new Dictionary<int, CheckingAccount>();
            this.loanAccounts = new Dictionary<int, LoanAccount>();
        }

        // ------------------------------ Accounts Creation Interfaces -------------------------------//

        /// <summary>
        /// Create the saving account instance.
        /// <NOTE> Limit of saving acount balance depending on the clients. </NOTE>
        /// </summary>
        /// <param name="accNumber"> account number. </param>
        /// <param name="initialDeposit"> initil deposit when create account. </param>
        /// <returns> can create or not. </returns>
        public bool CreateSavingAcc(int accNumber, double initialDeposit)
        {
            return false;
        }

        /// <summary>
        /// Create the checking account instance.
        /// </summary>
        /// <param name="accNumber"> account number. </param>
        /// <param name="initialDeposit"> initial deposit. </param>
        public void CreateCheckingAcc(int accNumber, double initialDeposit)
        {
        }

        /// <summary>
        /// Create the loan account instance.
        /// </summary>
        /// <param name="accNumber"> account number. </param>
        /// <param name="loanLimit"> loan limit. </param>
        public void CreateLoanAcc(int accNumber, double loanLimit)
        {
        }

        // -------------------------------------------------------------------------------------------//
        // ---------------------- Account Operation Interfaces ---------------------------------------//

        /// <summary>
        /// Client to accesing deposit in saving account.
        /// </summary>
        /// <param name="accNumber"> account number. </param>
        /// <param name="amount"> amount deposit. </param>
        /// <returns> can deposit or not. </returns>
        public bool DepositSavingAcc(int accNumber, double amount)
        {
            return false;
        }

        /// <summary>
        /// Client to accesing deposit in checking account.
        /// </summary>
        /// <param name="accNumber"> account number. </param>
        /// <param name="amount"> amount deposit. </param>
        /// <returns> can deposit or not. </returns>
        public bool DepositCheckingAcc(int accNumber, double amount)
        {
            return false;
        }

        /// <summary>
        /// Client to acess request loan (borrow loan) in loan account.
        /// </summary>
        /// <param name="accNumber"> account number. </param>
        /// <param name="amount"> amount deposit. </param>
        /// <returns> can borrow or not. </returns>
        public bool RequestLoanLoanAcc(int accNumber, double amount)
        {
            return false;
        }

        /// <summary>
        /// Client to acess withdraw from saving account.
        /// </summary>
        /// <param name="accNumber"> account number. </param>
        /// <param name="amount"> amount withdraw. </param>
        /// <returns> can withdraw or not. </returns>
        public bool WithdrawSavingAcc(int accNumber, double amount)
        {
            return false;
        }

        /// <summary>
        /// Client to acess withdraw from checking account.
        /// </summary>
        /// <param name="accNumber"> account number. </param>
        /// <param name="amount"> amount withdraw. </param>
        /// <returns> can withdraw or not. </returns>
        public bool WithdrawCheckingAcc(int accNumber, double amount)
        {
            return false;
        }

        /// <summary>
        /// Client to make payment to loan account.
        /// </summary>
        /// <param name="accNumber"> account number. </param>
        /// <param name="amount"> amount pay. </param>
        /// <returns> can pay or not. </returns>
        public bool PayPymentLoanAcc(int accNumber, double amount)
        {
            return false;
        }
    }
}

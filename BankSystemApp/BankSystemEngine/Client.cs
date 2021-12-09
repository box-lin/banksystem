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

        // specific on clients.
        private readonly double minSavingBalanceReq = 15000.00;


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
            bool okRule = this.EnsureMinBalanceRequirement(initialDeposit);
            if (!okRule)
            {
                Console.WriteLine("* < Failure >: Fail to open saving account, initial deposit must greater than $" + this.minSavingBalanceReq);
                return false;
            }

            SavingAccount saveAcc = new SavingAccount(accNumber);
            DepositCommand depositCommand = new DepositCommand(saveAcc, initialDeposit);
            saveAcc.DepositSaving(depositCommand);
            saveAcc.UpdateTransaction(accNumber, "Save Account Open", initialDeposit, saveAcc.GetAccBalance(), DateTime.Now.ToLocalTime().ToString());
            this.savingAccounts[accNumber] = saveAcc;
            return true;
        }

        /// <summary>
        /// Create the checking account instance.
        /// </summary>
        /// <param name="accNumber"> account number. </param>
        /// <param name="initialDeposit"> initial deposit. </param>
        public void CreateCheckingAcc(int accNumber, double initialDeposit)
        {
            CheckingAccount checkAcc = new CheckingAccount(accNumber);
            DepositCommand depositCommand = new DepositCommand(checkAcc, initialDeposit);
            checkAcc.DepositChecking(depositCommand);
            checkAcc.UpdateTransaction(accNumber, "Check Account Open", initialDeposit, checkAcc.GetAccBalance(), DateTime.Now.ToLocalTime().ToString());
            this.checkingAccounts[accNumber] = checkAcc;
        }

        /// <summary>
        /// Create the loan account instance.
        /// </summary>
        /// <param name="accNumber"> account number. </param>
        /// <param name="loanLimit"> loan limit. </param>
        public void CreateLoanAcc(int accNumber, double loanLimit)
        {
            LoanAccount loanAcc = new LoanAccount(accNumber, loanLimit);
            loanAcc.UpdateTransaction(accNumber, "Loan Account Open", 0.0, loanAcc.GetAccBalance(), DateTime.Now.ToLocalTime().ToString());
            this.loanAccounts[accNumber] = loanAcc;
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
            SavingAccount acc = this.savingAccounts[accNumber];
            DepositCommand dCommand = new DepositCommand(acc, amount);
            return acc.DepositSaving(dCommand);
        }

        /// <summary>
        /// Client to accesing deposit in checking account.
        /// </summary>
        /// <param name="accNumber"> account number. </param>
        /// <param name="amount"> amount deposit. </param>
        /// <returns> can deposit or not. </returns>
        public bool DepositCheckingAcc(int accNumber, double amount)
        {
            CheckingAccount acc = this.checkingAccounts[accNumber];
            DepositCommand dCommand = new DepositCommand(acc, amount);
            return acc.DepositChecking(dCommand);
        }

        /// <summary>
        /// Client to acess request loan (borrow loan) in loan account.
        /// </summary>
        /// <param name="accNumber"> account number. </param>
        /// <param name="amount"> amount deposit. </param>
        /// <returns> can borrow or not. </returns>
        public bool RequestLoanLoanAcc(int accNumber, double amount)
        {
            LoanAccount acc = this.loanAccounts[accNumber];
            DepositCommand dCommand = new DepositCommand(acc, amount);
            return acc.RequestLoan(dCommand);
        }

        /// <summary>
        /// Client to acess withdraw from saving account.
        /// </summary>
        /// <param name="accNumber"> account number. </param>
        /// <param name="amount"> amount withdraw. </param>
        /// <returns> can withdraw or not. </returns>
        public bool WithdrawSavingAcc(int accNumber, double amount)
        {
            SavingAccount acc = this.savingAccounts[accNumber];
            bool okRule = this.EnsureMinBalanceRequirement(acc.GetAccBalance() - amount);
            if (!okRule)
            {
                Console.WriteLine("* < Failure >: Fail to withdraw, saving account balance must maintain greater than $" + this.minSavingBalanceReq);
                return false;
            }

            WithdrawCommand wCommand = new WithdrawCommand(acc, amount);
            return acc.WithdrawSaving(wCommand);
        }

        /// <summary>
        /// Client to acess withdraw from checking account.
        /// </summary>
        /// <param name="accNumber"> account number. </param>
        /// <param name="amount"> amount withdraw. </param>
        /// <returns> can withdraw or not. </returns>
        public bool WithdrawCheckingAcc(int accNumber, double amount)
        {
            CheckingAccount acc = this.checkingAccounts[accNumber];
            WithdrawCommand wCommand = new WithdrawCommand(acc, amount);
            return acc.WithdrawChecking(wCommand);
        }

        /// <summary>
        /// Client to make payment to loan account.
        /// </summary>
        /// <param name="accNumber"> account number. </param>
        /// <param name="amount"> amount pay. </param>
        /// <returns> can pay or not. </returns>
        public bool PayPymentLoanAcc(int accNumber, double amount)
        {
            LoanAccount acc = this.loanAccounts[accNumber];
            WithdrawCommand wCommand = new WithdrawCommand(acc, amount);
            return acc.PayOffLoan(wCommand);
        }

        /// <summary>
        /// Gets all the saving account.
        /// </summary>
        /// <returns> saving account dict. </returns>
        public Dictionary<int, SavingAccount> GetAllSavingAccount()
        {
            return this.savingAccounts;
        }

        /// <summary>
        /// Gets all the checking account.
        /// </summary>
        /// <returns> checking account dict. </returns>
        public Dictionary<int, CheckingAccount> GetAllCheckingAccount()
        {
            return this.checkingAccounts;
        }

        /// <summary>
        /// Gets all the loan account.
        /// </summary>
        /// <returns> loan account dict. </returns>
        public Dictionary<int, LoanAccount> GetAllLoanAccount()
        {
            return this.loanAccounts;
        }

        /// <summary>
        /// To ensure that the saving account always satisfy the min balance requirement.
        /// </summary>
        /// <param name="afterBalance"> predicted balance. </param>
        /// <returns> satisfy or not. </returns>
        private bool EnsureMinBalanceRequirement(double afterBalance)
        {
            if (afterBalance < this.minSavingBalanceReq)
            {
                return false;
            }

            return true;
        }
    }
}

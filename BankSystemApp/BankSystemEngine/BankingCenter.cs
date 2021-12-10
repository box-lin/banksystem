// <copyright file="BankingCenter.cs" company="Boxiang Lin - WSU 011601661">
// Copyright (c) Boxiang Lin - WSU 011601661. All rights reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BankSystemEngine
{
    /// <summary>
    /// The center of the bank that handles the request from users.
    /// </summary>
    public class BankingCenter
    {
        // client with set of acc nums.
        private Dictionary<Client, HashSet<int>> clientAccount;

        // register user here receive commands from bank center.
        private RegisterUser reg;

        // let the account number starts at 999 and keep increment each time account created.
        private int accNumber = 999;

        /// <summary>
        /// Initializes a new instance of the <see cref="BankingCenter"/> class.
        /// </summary>
        public BankingCenter()
        {
            this.reg = new RegisterUser();
            this.clientAccount = new Dictionary<Client, HashSet<int>>();

            // create some accounts.
            this.DummyRegistration();

            // init client to acc num dictionary.
            this.InitClientDict();
        }

        /// <summary>
        /// Determine if the input username and password correctness and existence for client instance.
        /// </summary>
        /// <param name="username"> username. </param>
        /// <param name="password"> password. </param>
        /// <returns> found client or not. </returns>
        public bool LoginClient(string username, string password)
        {
            Client client = this.reg.GetClient(username);
            if (client == null)
            {
                return false;
            }

            if (password != client.GetPassWord())
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// Determine if the input username and password correctness and existence for employee instance.
        /// </summary>
        /// <param name="username"> username. </param>
        /// <param name="password"> password. </param>
        /// <returns> found employee or not. </returns>
        public bool LoginEmployee(string username, string password)
        {
            Employee employee = this.reg.GetEmployee(username);
            if (employee == null)
            {
                return false;
            }

            if (password != employee.GetPassWord())
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// Get the Client instance by username and password.
        /// </summary>
        /// <param name="username"> username. </param>
        /// <param name="password"> password. </param>
        /// <returns> client instance. </returns>
        public Client GetClientAcc(string username, string password)
        {
            return this.reg.GetClient(username);
        }

        /// <summary>
        /// Gets the employee instance.
        /// </summary>
        /// <param name="username"> username. </param>
        /// <param name="password"> password. </param>
        /// <returns> employee instance. </returns>
        public Employee GetEmployeeAcc(string username, string password)
        {
            return this.reg.GetEmployee(username);
        }

        /// <summary>
        /// Transfer money from one account to another.
        /// </summary>
        /// <param name="loggedClient"> logged in client. </param>
        /// <param name="myAccNumber"> client's account number. </param>
        /// <param name="targetAccNumber"> receiver's account number. </param>
        /// <param name="transferAmount"> transfer amount. </param>
        /// <returns> can transfer or not. </returns>
        public bool MoneyTransfer(Client loggedClient, int myAccNumber, int targetAccNumber, double transferAmount)
        {
            bool undo = false;

            // 1) check if the targetAccNumber belongs to some client.
            Client receiver = this.GetClientByAccountNum(targetAccNumber);

            if (receiver == null)
            {
                Console.WriteLine("* <Failure>: The account doesn't exist!");
                return false;
            }

            // 2) such receiver's account exist in system then check for the withdraw condition (if sufficient amount in packet).
            BankAccount transferOutAcc = this.TransferOut(loggedClient, myAccNumber, transferAmount);

            if (transferOutAcc == null)
            {
                Console.WriteLine("* <Failure>: You don't have sufficient balance for transfer!");
                return false;
            }

            // 3) account exist and balance enough, proceed transfer process.
            BankAccount transferInAcc = this.TransferIn(receiver, targetAccNumber, transferAmount);

            if (transferOutAcc != null && transferInAcc != null)
            {
                // perform redo undo.
                undo = this.RunUndoRedoTransferCommand(transferOutAcc, transferInAcc);
            }

            // if undo, nothing really happen, transfer transaction didnt made.
            if (undo)
            {
                return false;
            }

            // not undo, we add record.
            transferOutAcc.UpdateTransaction(myAccNumber, "Transfer Out", transferAmount, transferOutAcc.GetAccBalance(), DateTime.Now.ToLocalTime().ToString());
            transferInAcc.UpdateTransaction(targetAccNumber, "Transfer In", transferAmount, transferInAcc.GetAccBalance(), DateTime.Now.ToLocalTime().ToString());
            return true;
        }

        /// <summary>
        /// Account deposite wrapper.
        /// </summary>
        /// <param name="loggedClient"> logined client. </param>
        /// <param name="accNumber"> account number. </param>
        /// <param name="amount"> amount deposit. </param>
        /// <returns> can deposit or not. </returns>
        public bool AccountDeposit(Client loggedClient, int accNumber, double amount)
        {
            bool deposited = false;
            bool undo = false;

            if (loggedClient.GetAllSavingAccount().ContainsKey(accNumber))
            {
                deposited = loggedClient.DepositSavingAcc(accNumber, amount);
                SavingAccount saveAcc = loggedClient.GetAllSavingAccount()[accNumber];
                if (deposited)
                {
                    undo = this.RunUndoRedoCommand(saveAcc);
                }

                if (!undo)
                {
                    saveAcc.UpdateTransaction(accNumber, "Deposit", amount, saveAcc.GetAccBalance(), DateTime.Now.ToLocalTime().ToString());
                }

                return deposited && (!undo);
            }
            else if (loggedClient.GetAllCheckingAccount().ContainsKey(accNumber))
            {
                deposited = loggedClient.DepositCheckingAcc(accNumber, amount);
                CheckingAccount checkAcc = loggedClient.GetAllCheckingAccount()[accNumber];
                if (deposited)
                {
                    undo = this.RunUndoRedoCommand(checkAcc);
                }

                if (!undo)
                {
                    checkAcc.UpdateTransaction(accNumber, "Deposit", amount, checkAcc.GetAccBalance(), DateTime.Now.ToLocalTime().ToString());
                }

                return deposited && (!undo);
            }
            else if (loggedClient.GetAllLoanAccount().ContainsKey(accNumber))
            {
                deposited = loggedClient.RequestLoanLoanAcc(accNumber, amount); // balance here is what owed.
                LoanAccount loanAcc = loggedClient.GetAllLoanAccount()[accNumber];
                if (deposited)
                {
                    undo = this.RunUndoRedoCommand(loanAcc);
                }

                if (!undo)
                {
                    loanAcc.UpdateTransaction(accNumber, "Borrow", amount, loanAcc.GetAccBalance(), DateTime.Now.ToLocalTime().ToString());
                }

                return deposited && (!undo);
            }

            Console.WriteLine("* <Failure>: The account doesn't exist!");
            return false;
        }

        /// <summary>
        /// Account withdraw wrapper.
        /// </summary>
        /// <param name="loggedClient"> logined client. </param>
        /// <param name="accNumber"> account number. </param>
        /// <param name="amount"> amount withdraw. </param>
        /// <returns> can withdraw or not. </returns>
        public bool AccountWithdraw(Client loggedClient, int accNumber, double amount)
        {
            bool withdraw = false;
            bool undo = false;
            if (loggedClient.GetAllSavingAccount().ContainsKey(accNumber))
            {
                withdraw = loggedClient.WithdrawSavingAcc(accNumber, amount);
                SavingAccount saveAcc = loggedClient.GetAllSavingAccount()[accNumber];
                if (withdraw)
                {
                    undo = this.RunUndoRedoCommand(saveAcc);
                }

                // if user didnt undo we add the transaction to record.
                if (!undo)
                {
                    saveAcc.UpdateTransaction(accNumber, "Withdraw", amount, saveAcc.GetAccBalance(), DateTime.Now.ToLocalTime().ToString());
                }

                return withdraw && (!undo);
            }
            else if (loggedClient.GetAllCheckingAccount().ContainsKey(accNumber))
            {
                withdraw = loggedClient.WithdrawCheckingAcc(accNumber, amount);
                CheckingAccount checkAcc = loggedClient.GetAllCheckingAccount()[accNumber];
                if (withdraw)
                {
                    undo = this.RunUndoRedoCommand(checkAcc);
                }

                // if user didnt undo we add the transaction to record.
                if (!undo)
                {
                    checkAcc.UpdateTransaction(accNumber, "Withdraw", amount, checkAcc.GetAccBalance(), DateTime.Now.ToLocalTime().ToString());
                }

                return withdraw && (!undo);
            }
            else if (loggedClient.GetAllLoanAccount().ContainsKey(accNumber))
            {
                withdraw = loggedClient.PayPymentLoanAcc(accNumber, amount);
                LoanAccount loanAcc = loggedClient.GetAllLoanAccount()[accNumber];
                if (withdraw)
                {
                    undo = this.RunUndoRedoCommand(loanAcc);
                }

                if (!undo)
                {
                    loanAcc.UpdateTransaction(accNumber, "PayLoan", amount, loanAcc.GetAccBalance(), DateTime.Now.ToLocalTime().ToString());
                }

                return withdraw && (!undo);
            }

            Console.WriteLine("* <Failure>: The amount doesn't exist!");
            return false;
        }

        /// <summary>
        /// Create checking account wrapper with respected to logined client.
        /// </summary>
        /// <param name="loggedClient"> logined client. </param>
        /// <param name="initAmount"> intial deposit. </param>
        public void CreateCheckingAccount(Client loggedClient, double initAmount)
        {
            int accNumber = this.GetNextAccountNumber();
            loggedClient.CreateCheckingAcc(accNumber, initAmount);
            if (!this.clientAccount.ContainsKey(loggedClient))
            {
                this.clientAccount[loggedClient] = new HashSet<int>();
            }

            this.clientAccount[loggedClient].Add(accNumber);
            Console.WriteLine("* Your checking account with account number:  #" + accNumber + " has been created!");
        }

        /// <summary>
        /// Create saving account wrapper with respected to logined client.
        /// </summary>
        /// <param name="loggedClient"> logined client. </param>
        /// <param name="initAmount"> initial deposit. </param>
        public void CreateSavingAccount(Client loggedClient, double initAmount)
        {
            int accNumber = this.GetNextAccountNumber();
            bool okRegiter = loggedClient.CreateSavingAcc(accNumber, initAmount);
            if (okRegiter)
            {
                if (!this.clientAccount.ContainsKey(loggedClient))
                {
                    this.clientAccount[loggedClient] = new HashSet<int>();
                }

                this.clientAccount[loggedClient].Add(accNumber);
                Console.WriteLine("* Your saving account with account number:  #" + accNumber + " has been created!");
            }
        }

        /// <summary>
        /// Create loan account wrapper with respected to logined client.
        /// </summary>
        /// <param name="loggedClient"> logined client. </param>
        /// <param name="loanLimit"> loan limit. </param>
        public void CreateLoanAccount(Client loggedClient, double loanLimit)
        {
            int accNumber = this.GetNextAccountNumber();
            loggedClient.CreateLoanAcc(accNumber, loanLimit);
            if (!this.clientAccount.ContainsKey(loggedClient))
            {
                this.clientAccount[loggedClient] = new HashSet<int>();
            }

            this.clientAccount[loggedClient].Add(accNumber);
            Console.WriteLine("* Your loan account with account number:  #" + accNumber + " has been created!");
        }

        /// <summary>
        /// Gets all client account in RegisterUser container.
        /// </summary>
        /// <returns> dict of client. </returns>
        public Dictionary<string, Client> GetAllClientAcc()
        {
            return this.reg.GetAllClientAccount();
        }

        /// <summary>
        /// Gets all employee account in RegistgerUser container.
        /// </summary>
        /// <returns>dict of employee. </returns>
        public Dictionary<string, Employee> GetAllEmplopyeeAcc()
        {
            return this.reg.GetAllEmployeeAccount();
        }

        /// <summary>
        /// Gets the current account number counter.
        /// </summary>
        /// <returns> account number. </returns>
        public int GetCurrentAccountNumber()
        {
            return this.accNumber;
        }

        /// <summary>
        /// hard coded few accounts for this version.
        /// </summary>
        private void DummyRegistration()
        {
            this.reg.RegisterClient("boxiang", "123", "Boxiang", "Lin", "boxiang.lin@wsu.edu");
            this.reg.RegisterClient("sam", "123", "Sam", "Sam", "sam@wsu.edu");
            this.reg.RegisterEmployee("john", "321", "John", "John", "john@wsu.edu");
        }

        /// <summary>
        /// Account number Iterator.
        /// </summary>
        /// <returns> next distinct accout number. </returns>
        private int GetNextAccountNumber()
        {
            this.accNumber += 1;
            return this.accNumber;
        }

        /// <summary>
        /// Init the client:accnums dictionary.
        /// </summary>
        private void InitClientDict()
        {
            foreach (Client c in this.reg.GetAllClientAccount().Values)
            {
                this.clientAccount[c] = new HashSet<int>();
            }
        }

        /// <summary>
        /// Run the undo redo by user input.
        /// </summary>
        /// <param name="acc"> generic bank account. </param>
        /// <returns> undo or not. </returns>
        private bool RunUndoRedoCommand(BankAccount acc)
        {
            // seperate thread to run the counter of 10 seconds.
            Thread timer = new Thread(() => this.RunTimer(acc));
            string command = string.Empty;
            bool undo = false;
            timer.Start();
            while (timer.IsAlive)
            {
                command = Console.ReadLine();
                if (command == "r")
                {
                    acc.RunRedoCommand();
                    undo = false;
                }
                else if (command == "u")
                {
                    acc.RunUndoCommand();
                    undo = true;
                }
                else
                {
                    // if user enter q, or something else we just end the thread and process the transaction.
                    timer.Abort();
                    return undo;
                }
            }

            return undo;
        }

        /// <summary>
        /// Thread sleep runner.
        /// </summary>
        /// <param name="acc"> bank account. </param>
        private void RunTimer(BankAccount acc)
        {
            for (int i = 10; i > 0; i--)
            {
                Thread.Sleep(1000);
                if (acc.GetRedoStackSize() > 0)
                {
                    Console.Write("\r* Your can redo last transaction by 'r' within " + i + " seconds or 'q' to quit: ");
                }
                else if (acc.GetUndoStackSize() > 0)
                {
                    Console.Write("\r* Your can undo last transaction by 'u' within " + i + " seconds or 'q' to quit: ");
                }
            }

            Console.WriteLine();
            Console.WriteLine("* Session ended, ---------------------------------> press q key to exist!");
        }

        /// <summary>
        /// Helper to get client instance by account number.
        /// </summary>
        /// <param name="accNum"> account number. </param>
        /// <returns> client. </returns>
        private Client GetClientByAccountNum(int accNum)
        {
            foreach (Client c in this.clientAccount.Keys)
            {
                if (this.clientAccount[c].Contains(accNum))
                {
                    return c;
                }
            }

            return null;
        }

        /// <summary>
        /// This handles the withdraw from sender's account (similar to accountwithdraw).
        /// </summary>
        /// <param name="loggedClient"> logged client. </param>
        /// <param name="accNumber"> account number. </param>
        /// <param name="amount"> amount. </param>
        /// <returns> can transfer out or not. </returns>
        private BankAccount TransferOut(Client loggedClient, int accNumber, double amount)
        {
            bool withdraw = false;
            if (loggedClient.GetAllSavingAccount().ContainsKey(accNumber))
            {
                withdraw = loggedClient.WithdrawSavingAcc(accNumber, amount);
                SavingAccount saveAcc = loggedClient.GetAllSavingAccount()[accNumber];
                TransactionRecord record = new TransactionRecord(accNumber, "Transfer out", amount, saveAcc.GetAccBalance(), DateTime.Now.ToLocalTime().ToString());

                if (withdraw)
                {
                    return saveAcc;
                }
            }
            else if (loggedClient.GetAllCheckingAccount().ContainsKey(accNumber))
            {
                withdraw = loggedClient.WithdrawCheckingAcc(accNumber, amount);
                CheckingAccount checkAcc = loggedClient.GetAllCheckingAccount()[accNumber];

                if (withdraw)
                {
                    return checkAcc;
                }
            }
            else if (loggedClient.GetAllLoanAccount().ContainsKey(accNumber))
            {
                withdraw = loggedClient.PayPymentLoanAcc(accNumber, amount);
                LoanAccount loanAcc = loggedClient.GetAllLoanAccount()[accNumber];
                if (withdraw)
                {
                    return loanAcc;
                }
            }

            Console.WriteLine("* <Failure>: The account doesn't exist!");
            return null;
        }

        /// <summary>
        /// Handles the deposit for receiver account (similar to account deposit).
        /// </summary>
        /// <param name="receiver"> receiver instance. </param>
        /// <param name="accNumber"> receiver account number. </param>
        /// <param name="amount"> amount transfer. </param>
        /// <returns> can transfer in to a receiver account or not. </returns>
        private BankAccount TransferIn(Client receiver, int accNumber, double amount)
        {
            bool deposited = false;
            if (receiver.GetAllSavingAccount().ContainsKey(accNumber))
            {
                deposited = receiver.DepositSavingAcc(accNumber, amount);
                SavingAccount saveAcc = receiver.GetAllSavingAccount()[accNumber];
                if (deposited)
                {
                    return saveAcc;
                }
            }
            else if (receiver.GetAllCheckingAccount().ContainsKey(accNumber))
            {
                deposited = receiver.DepositCheckingAcc(accNumber, amount);
                CheckingAccount checkAcc = receiver.GetAllCheckingAccount()[accNumber];
                if (deposited)
                {
                    return checkAcc;
                }
            }
            else if (receiver.GetAllLoanAccount().ContainsKey(accNumber))
            {
                deposited = receiver.RequestLoanLoanAcc(accNumber, amount); // balance here is what owed.
                LoanAccount loanAcc = receiver.GetAllLoanAccount()[accNumber];
                if (deposited)
                {
                    return loanAcc;
                }
            }

            Console.WriteLine("* <Failure>: The account doesn't exist!");
            return null;
        }

        /// <summary>
        /// UndoRedo command for transfer.
        /// </summary>
        /// <param name="senderAcc"> sender account. </param>
        /// <param name="receiverAcc"> receiver account. </param>
        /// <returns> can undo or not. </returns>
        private bool RunUndoRedoTransferCommand(BankAccount senderAcc, BankAccount receiverAcc)
        {
            // seperate thread to run the counter of 10 seconds.
            Thread timer = new Thread(() => this.TransferRunTimer(senderAcc, receiverAcc));
            string command = string.Empty;
            bool undo = false;
            timer.Start();
            while (timer.IsAlive)
            {
                command = Console.ReadLine();
                if (command == "r")
                {
                    senderAcc.RunRedoCommand();
                    receiverAcc.RunRedoCommand();
                    undo = false;
                }
                else if (command == "u")
                {
                    senderAcc.RunUndoCommand();
                    receiverAcc.RunUndoCommand();
                    undo = true;
                }
                else
                {
                    // if user enter q, or something else we just end the thread and process the transaction.
                    timer.Abort();
                    return undo;
                }
            }

            return undo;
        }

        /// <summary>
        /// Use for transfer timer of redo/undo.
        /// </summary>
        /// <param name="sender"> sender account. </param>
        /// <param name="receiver"> receiver account. </param>
        private void TransferRunTimer(BankAccount sender, BankAccount receiver)
        {
            for (int i = 10; i > 0; i--)
            {
                Thread.Sleep(1000);
                if (sender.GetRedoStackSize() > 0 && receiver.GetRedoStackSize() > 0)
                {
                    Console.Write("\r* Your can redo the transfer transaction by 'r' within " + i + " seconds or 'q' to quit: ");
                }
                else if (sender.GetUndoStackSize() > 0 && receiver.GetUndoStackSize() > 0)
                {
                    Console.Write("\r* Your can undo the transfer transaction  by 'u' within " + i + " seconds or 'q' to quit: ");
                }
            }

            Console.WriteLine();
            Console.WriteLine("* Session ended, ---------------------------------> press q key to exist!");
        }
    }
}

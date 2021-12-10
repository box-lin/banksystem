// <copyright file="Program.cs" company="Boxiang Lin - WSU 011601661">
// Copyright (c) Boxiang Lin - WSU 011601661. All rights reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.Text;
using BankSystemEngine;

namespace BankSystemApp
{
    /// <summary>
    /// Entry of the program.
    /// Console UI message displayer (view components).
    /// </summary>
    public class Program
    {
        private BankingCenter bc;

        /// <summary>
        /// Initializes a new instance of the <see cref="Program"/> class.
        /// </summary>
        public Program()
        {
            this.bc = new BankingCenter();
        }

        /// <summary>
        /// Main entry.
        /// </summary>
        /// <param name="args"> command line args. </param>
        public static void Main(string[] args)
        {
            Program program = new Program();
            program.Run();
        }

        /// <summary>
        /// Login menu display, user input receive and proceed to other message display.
        /// </summary>
        private void Run()
        {
            this.ShowUserMenu();
            string accountType = Console.ReadLine();
            if (accountType == "1")
            {
                string username = this.ShowLoginUsernameMenu();
                string password = this.ShowLoginPasswordMenu();
                Console.WriteLine();
                bool isOkLogin = this.ClientLoginVerify(username, password);
                if (!isOkLogin)
                {
                    Console.WriteLine();
                    this.Run();
                }
                else
                {
                    Client loggedClient = this.bc.GetClientAcc(username, password);
                    this.ShowClientMenu(loggedClient);
                }
            }
            else if (accountType == "2")
            {
                // TODO: employee login.
                string username = this.ShowLoginUsernameMenu();
                string password = this.ShowLoginPasswordMenu();
                Console.WriteLine();
                bool isOkLogin = this.EmployeeLoginVerify(username, password);
                if (!isOkLogin)
                {
                    Console.WriteLine();
                    this.Run();
                }
                else
                {
                    Employee loggedEmployee = this.bc.GetEmployeeAcc(username, password);
                    this.ShowEmployeeMenu(loggedEmployee);
                }
            }
            else
            {
                this.Run();
            }

            Console.Read();
        }

        /// <summary>
        /// Shows the user selection menu.
        /// </summary>
        private void ShowUserMenu()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(" --------------------------------- Welcome to the Banking System ---------------------------------");
            sb.AppendLine("* 1. Type 1 to login with a client account                                                        *");
            sb.AppendLine("* 2. Type 2 to login with an employee account                                                     *");
            Console.Write(sb.ToString());
        }

        /// <summary>
        /// Shows the login with username menu.
        /// </summary>
        /// <returns> username. </returns>
        private string ShowLoginUsernameMenu()
        {
            Console.Write(">> Please enter the username: ");
            string username = Console.ReadLine();
            return username;
        }

        /// <summary>
        /// Shows the login with password menu.
        /// </summary>
        /// <returns> password. </returns>
        private string ShowLoginPasswordMenu()
        {
            Console.Write(">> Please ener the password: ");
            string password = this.EnterPassword();
            return password;
        }

        /// <summary>
        /// Verify the username and password first.
        /// </summary>
        /// <param name="username"> username. </param>
        /// <param name="password"> password. </param>
        /// <returns> can login or not. </returns>
        private bool ClientLoginVerify(string username, string password)
        {
            bool clientFounded = this.bc.LoginClient(username, password);
            if (!clientFounded)
            {
                Console.WriteLine(">>Error: Username OR Password Incorrect!                                                          *");
                return false;
            }

            return true;
        }

        /// <summary>
        /// Verify the username and password first for emplpyee.
        /// </summary>
        /// <param name="username"> username. </param>
        /// <param name="password"> password. </param>
        /// <returns> can login or not. </returns>
        private bool EmployeeLoginVerify(string username, string password)
        {
            bool employeeFounded = this.bc.LoginEmployee(username, password);
            if (!employeeFounded)
            {
                Console.WriteLine(">>Error: Username OR Password Incorrect!                                                          *");
                return false;
            }

            return true;
        }

        /// <summary>
        /// To show the employee menu page.
        /// </summary>
        /// <param name="loggedEmployee"> logged emploee. </param>
        private void ShowEmployeeMenu(Employee loggedEmployee)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(" --------------------------------- You've Logged in as Employee, " + loggedEmployee.GetFirstName() + "! --------------------------");
            sb.AppendLine("* <NOTE>                                                                                          *");
            sb.AppendLine("* : The functionalities of employee doesn't not include in this version.                          *");
            sb.AppendLine("* </NOTE>                                                                                         *");
            sb.AppendLine("* Enter Any Key back to the login page                                                            *");
            sb.AppendLine("* ----------------------------------------------------------------------------------------------- *");
            Console.Write(sb.ToString());
            string op = Console.ReadLine();
            if (op != string.Empty)
            {
                this.Run();
            }
        }

        /// <summary>
        /// Shows the client operation menu.
        /// </summary>
        /// <param name="loggedClient"> logined client. </param>
        private void ShowClientMenu(Client loggedClient)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(" --------------------------------- You've Logged in as Client, " + loggedClient.GetFirstName() + "! --------------------------");
            sb.AppendLine("* 1. Type 1 to view your exiting accounts' status                                                 *");
            sb.AppendLine("* 2. Type 2 to create a checking account                                                          *");
            sb.AppendLine("* 3. Type 3 to create a saving account                                                            *");
            sb.AppendLine("* 4. Type 4 to create a loan account                                                              *");
            sb.AppendLine("* 5. Type 5 to deposit to your account(checking/saving)                                           *");
            sb.AppendLine("* 6. Type 6 to withdraw from your account(checking/saving)                                        *");
            sb.AppendLine("* 7. Type 7 to make payment to your loan account                                                  *");
            sb.AppendLine("* 8. Type 8 to borrow from your loan account                                                      *");
            sb.AppendLine("* 9. Type 9 to transfer funds                                                                     *");
            sb.AppendLine("* 0. Type 0 to login page                                                                         *");
            Console.Write(sb.ToString());
            string op = Console.ReadLine();
            this.DisplayClientSelectedOpMenu(op, loggedClient);
        }

        /// <summary>
        /// Transition method that direct to specific operation.
        /// </summary>
        /// <param name="op"> operation. </param>
        /// <param name="loggedClient"> loggied client. </param>
        private void DisplayClientSelectedOpMenu(string op, Client loggedClient)
        {
            if (op == "0")
            {
                this.Run();
            }
            else if (op == "1")
            {
                this.ViewAllAccountMenu(loggedClient);
            }
            else if (op == "2")
            {
                this.CreateCheckingAccountMenu(loggedClient);
            }
            else if (op == "3")
            {
                this.CreateSavingAccountMenu(loggedClient);
            }
            else if (op == "4")
            {
                this.CreateLoanAccountMenu(loggedClient);
            }
            else if (op == "5")
            {
                this.AccountDepositMenu(loggedClient);
            }
            else if (op == "6")
            {
                this.AccountWithdrawMenu(loggedClient);
            }
            else if (op == "7")
            {
                this.PayLoanMenu(loggedClient);
            }
            else if (op == "8")
            {
                this.LoanBorrowMenu(loggedClient);
            }
            else if (op == "9")
            {
                this.TransferFundMenu(loggedClient);
            }
            else
            {
                this.ShowClientMenu(loggedClient);
            }
        }

        /// <summary>
        /// Menu for seeing all accounts info.
        /// </summary>
        /// <param name="loggedClient"> logged client. </param>
        private void ViewAllAccountMenu(Client loggedClient)
        {
            Console.WriteLine("------------------------------------------------------------------------------- Status Page ------------------------------------------------------------------------");

            //---------------------------------- UI for seeing checking account status ------------------------------------//
            Console.WriteLine("* Please view the checking accounts under your name below: ");
            if (loggedClient.GetAllCheckingAccount().Count == 0)
            {
                Console.WriteLine("[*] Ops, no checking accounts under your name yet!");
            }

            foreach (var acc in loggedClient.GetAllCheckingAccount())
            {
                Console.WriteLine("[*] Account Type: Checking, \t" + "Account Number: [#" + acc.Value.GetAccNumber() + "], \tAccount Balance: $" + acc.Value.GetAccBalance());
                foreach (TransactionRecord tr in acc.Value.GetTransactionRecords())
                {
                    Console.WriteLine(tr);
                }
            }

            Console.WriteLine();

            //---------------------------------- UI for seeing saving account status ------------------------------------//
            Console.WriteLine("* Please view the saving accounts under your name below: ");
            if (loggedClient.GetAllSavingAccount().Count == 0)
            {
                Console.WriteLine("[*] Ops, no saving accounts under your name yet!");
            }

            foreach (var acc in loggedClient.GetAllSavingAccount())
            {
                Console.WriteLine("[*] Account Type: Saving, \t" + "Account Number: [#" + acc.Value.GetAccNumber() + "], \tAccount Balance: $" + acc.Value.GetAccBalance()
                    + ", \tInterest Rate: " + acc.Value.GetAccountInterestRate() + ", \tInterest Gained: ");
                foreach (TransactionRecord tr in acc.Value.GetTransactionRecords())
                {
                    Console.WriteLine(tr);
                }
            }

            Console.WriteLine();

            //---------------------------------- UI for seeing loan account status ------------------------------------//
            Console.WriteLine("* Please view the loan accounts under your name below: ");
            if (loggedClient.GetAllLoanAccount().Count == 0)
            {
                Console.WriteLine("[*] Ops, no loan accounts under your name yet!");
            }

            foreach (var acc in loggedClient.GetAllLoanAccount())
            {
                Console.WriteLine("[*] Account Type: Loan, \t" + "Account Number: [#" + acc.Value.GetAccNumber() + "], \tAmount Owed: $" + acc.Value.GetAccBalance()
                    + ", \tInterest Rate: " + acc.Value.GetAccountInterestRate());
                foreach (TransactionRecord tr in acc.Value.GetTransactionRecords())
                {
                    Console.WriteLine(tr);
                }
            }

            Console.WriteLine();
            Console.WriteLine("------------------------------------------------------------------------------ End Status --------------------------------------------------------------------------");
            Console.WriteLine();
            this.ClientOpCycle(loggedClient);
        }

        /// <summary>
        /// Create checking account menu for logged client.
        /// </summary>
        /// <param name="loggedClient"> logged client. </param>
        private void CreateCheckingAccountMenu(Client loggedClient)
        {
            Console.Write("* Please enter the initial deposite amount: $");
            double initialDeposit = double.Parse(Console.ReadLine());
            this.bc.CreateCheckingAccount(loggedClient, initialDeposit);
            Console.WriteLine();
            this.ClientOpCycle(loggedClient);
        }

        /// <summary>
        /// Create saving account menu for logged client.
        /// </summary>
        /// <param name="loggedClient"> logged client. </param>
        private void CreateSavingAccountMenu(Client loggedClient)
        {
            Console.Write("* Please enter the initial deposite amount: $");
            double initialDeposit = double.Parse(Console.ReadLine());
            this.bc.CreateSavingAccount(loggedClient, initialDeposit);
            Console.WriteLine();
            this.ClientOpCycle(loggedClient);
        }

        /// <summary>
        /// Create loan account menu for logged client.
        /// </summary>
        /// <param name="loggedClient"> logged client. </param>
        private void CreateLoanAccountMenu(Client loggedClient)
        {
            Console.Write("* Please enter the loan limit you want: $");
            double loanLimit = double.Parse(Console.ReadLine());
            this.bc.CreateLoanAccount(loggedClient, loanLimit);
            Console.WriteLine();
            this.ClientOpCycle(loggedClient);
        }

        /// <summary>
        /// Account deposit menu.
        /// </summary>
        /// <param name="loggedClient"> logged client. </param>
        private void AccountDepositMenu(Client loggedClient)
        {
            Console.Write("* Please the account number: #");
            int accNumber = int.Parse(Console.ReadLine());
            Console.Write("* Please enter the deposit amount: $");
            double depositAmount = double.Parse(Console.ReadLine());
            bool success = this.bc.AccountDeposit(loggedClient, accNumber, depositAmount);
            if (success)
            {
                Console.WriteLine("The amount $" + depositAmount + " has been sucessfullt deposited into Account #" + accNumber);
            }

            Console.WriteLine();
            this.ClientOpCycle(loggedClient);
        }

        /// <summary>
        /// Account withdraw menu.
        /// </summary>
        /// <param name="loggedClient"> logged menu. </param>
        private void AccountWithdrawMenu(Client loggedClient)
        {
            Console.Write("* Please the account number: #");
            int accNumber = int.Parse(Console.ReadLine());
            Console.Write("* Please enter the withdraw amount: $");
            double withdrawAmount = double.Parse(Console.ReadLine());
            bool success = this.bc.AccountWithdraw(loggedClient, accNumber, withdrawAmount);
            if (success)
            {
                Console.WriteLine("The amount $" + withdrawAmount + " has been sucessfullt withdraw from the Account #" + accNumber);
            }

            Console.WriteLine();
            this.ClientOpCycle(loggedClient);
        }

        /// <summary>
        /// Loan borrow menu.
        /// </summary>
        /// <param name="loggedClient"> logged client. </param>
        private void LoanBorrowMenu(Client loggedClient)
        {
            Console.Write("* Please the account number: #");
            int accNumber = int.Parse(Console.ReadLine());
            Console.Write("* Please enter the amount you want to borrow from the account: $");
            double borrowAmount = double.Parse(Console.ReadLine());
            bool success = this.bc.AccountDeposit(loggedClient, accNumber, borrowAmount);
            if (success)
            {
                Console.WriteLine("The amount $" + borrowAmount + " has been sucessfullt borrow and deposit into the Account #" + accNumber);
            }

            Console.WriteLine();
            this.ClientOpCycle(loggedClient);
        }

        /// <summary>
        /// Client Payloan menu.
        /// </summary>
        /// <param name="loggedClient"> logged client. </param>
        private void PayLoanMenu(Client loggedClient)
        {
            Console.Write("* Please the account number: #");
            int accNumber = int.Parse(Console.ReadLine());
            Console.Write("* Please enter the amount you want pay to your loan account: $");
            double payAmount = double.Parse(Console.ReadLine());
            bool success = this.bc.AccountWithdraw(loggedClient, accNumber, payAmount);
            if (success)
            {
                Console.WriteLine("The amount $" + payAmount + " has been sucessfullt pay into the Account #" + accNumber);
            }

            Console.WriteLine();
            this.ClientOpCycle(loggedClient);
        }

        /// <summary>
        /// Transfer money to account menu.
        /// </summary>
        /// <param name="loggedClient"> logged client. </param>
        private void TransferFundMenu(Client loggedClient)
        {
            Console.Write("* Please enter your account number: #");
            int myAccNumber = int.Parse(Console.ReadLine());
            Console.Write("* Please enter the receiver's account number: #");
            int targerAccNumber = int.Parse(Console.ReadLine());
            Console.Write("* Please enter the amount you want to transfer: $");
            double transferAmount = double.Parse(Console.ReadLine());
            bool success = this.bc.MoneyTransfer(loggedClient, myAccNumber, targerAccNumber, transferAmount);
            if (success)
            {
                Console.WriteLine("The amount $" + transferAmount + " has been sucessfullt transfer from Account # " + myAccNumber +
                    " into the Account #" + targerAccNumber);
            }

            Console.WriteLine();
            this.ClientOpCycle(loggedClient);
        }

        /// <summary>
        /// The cycle menu back to operation page or login page.
        /// </summary>
        /// <param name="loggedClient"> logged client. </param>
        private void ClientOpCycle(Client loggedClient)
        {
            Console.WriteLine("****** System Command:");
            Console.WriteLine("* Enter 'p' to return back to the previous Page. ");
            Console.WriteLine("* Enter '0' to return back to the login Page. ");
            string command = Console.ReadLine();
            if (command == "p")
            {
                this.ShowClientMenu(loggedClient);
            }
            else if (command == "0")
            {
                this.Run();
            }
            else
            {
                this.ShowClientMenu(loggedClient);
            }
        }

        /// <summary>
        /// To Display the Console "*" for password input.
        /// </summary>
        /// <returns> a password. </returns>
        private string EnterPassword()
        {
            Stack<string> input = new Stack<string>();
            while (true)
            {
                ConsoleKeyInfo ck = Console.ReadKey(true);
                if (ck.Key != ConsoleKey.Enter)
                {
                    if (ck.Key != ConsoleKey.Backspace)
                    {
                        input.Push(ck.KeyChar.ToString());
                        Console.Write("*");
                    }
                    else
                    {
                        if (input.Count > 0)
                        {
                            input.Pop();
                        }

                        Console.Write("\b \b");
                    }
                }
                else
                {
                    break;
                }
            }

            string password = string.Empty;
            foreach (string code in input)
            {
                password = code.ToString() + password;
            }

            Console.WriteLine();
            return password;
        }
    }
}

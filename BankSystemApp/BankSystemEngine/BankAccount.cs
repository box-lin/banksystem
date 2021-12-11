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
    public abstract class BankAccount : ITransaction
    {
        // holds the transaction records for each account in a list.
        private Queue<TransactionRecord> records;
        private int accNumber;
        private double accBalance;

        // undo stack track of command to undo.
        private Stack<ICommand> undo;

        // redo  stack track of command to redo.
        private Stack<ICommand> redo;

        /// <summary>
        /// Initializes a new instance of the <see cref="BankAccount"/> class.
        /// </summary>
        /// <param name="accNumber"> int acc number.</param>
        public BankAccount(int accNumber)
        {
            this.accNumber = accNumber;
            this.accBalance = 0.0;
            this.undo = new Stack<ICommand>(1);
            this.redo = new Stack<ICommand>(1);
            this.records = new Queue<TransactionRecord>(10);
        }

        /// <summary>
        /// Use to set the acc number.
        /// </summary>
        /// <param name="accNumber"> int acc number. </param>
        public void SetAccNumber(int accNumber)
        {
            this.accNumber = accNumber;
        }

        /// <summary>
        /// Use to get the acc number.
        /// </summary>
        /// <returns> acc number. </returns>
        public int GetAccNumber()
        {
            return this.accNumber;
        }

        /// <summary>
        /// Use to get the account balance.
        /// </summary>
        /// <returns> acc balance. </returns>
        public double GetAccBalance()
        {
            return this.accBalance;
        }

        /// <summary>
        /// Use to deposit amount into the acc balance.
        /// </summary>
        /// <param name="amount"> amount of money. </param>
        /// <returns> can deposit or not. </returns>
        public bool Deposit(double amount)
        {
            this.SetAccBalance(this.GetAccBalance() + amount);
            return true;
        }

        /// <summary>
        /// Use to withdraw amount from acc balance.
        /// </summary>
        /// <param name="amount"> amount of money. </param>
        /// <returns> can withdraw or not. </returns>
        public bool Withdraw(double amount)
        {
            if (this.GetAccBalance() < amount)
            {
                return false;
            }

            this.SetAccBalance(this.GetAccBalance() - amount);
            return true;
        }

        /// <summary>
        /// Command object that add to the undo stack at first.
        /// </summary>
        /// <param name="command"> command. </param>
        public void NewCommandAdd(ICommand command)
        {
            this.redo.Clear();
            this.undo.Push(command);
        }

        /// <summary>
        /// Run the command object at the top of undo.
        /// </summary>
        public void RunUndoCommand()
        {
            if (this.undo.Count > 0)
            {
                ICommand c = this.undo.Pop();
                c.Unexecute();
                this.redo.Push(c);
            }
        }

        /// <summary>
        /// Run the command object at the top of redo.
        /// </summary>
        public void RunRedoCommand()
        {
            if (this.redo.Count > 0)
            {
                ICommand c = this.redo.Pop();
                c.Execute();
                this.undo.Push(c);
            }
        }

        /// <summary>
        /// Capture the transaction info into a TransactionRecord Class.
        /// </summary>
        /// <param name="accNumber"> bank account number. </param>
        /// <param name="transactionType"> transaction type. </param>
        /// <param name="transactionAmount"> amount transaction. </param>
        /// <param name="balance"> balance after transaction. </param>
        /// <param name="transactionTime"> time transaction occur. </param>
        public void UpdateTransaction(int accNumber, string transactionType, double transactionAmount, double balance, string transactionTime)
        {
            TransactionRecord record = new TransactionRecord(accNumber, transactionType, transactionAmount, balance, transactionTime);

            if (this.records.Count >= 10)
            {
                this.records.Dequeue();
            }

            this.records.Enqueue(record);
        }

        /// <summary>
        /// Gets the transaction records.
        /// </summary>
        /// <returns> queue of records. </returns>
        public Queue<TransactionRecord> GetTransactionRecords()
        {
            return this.records;
        }

        /// <summary>
        /// Get numbers of transaction data stored.
        /// </summary>
        /// <returns> length of records queue. </returns>
        public int GetTransactionCount()
        {
            return this.records.Count;
        }

        /// <summary>
        /// Gets the undo stack size.
        /// </summary>
        /// <returns> undo stack size. </returns>
        public int GetUndoStackSize()
        {
            return this.undo.Count;
        }

        /// <summary>
        /// Gets the redo stack size.
        /// </summary>
        /// <returns> redo stack size. </returns>
        public int GetRedoStackSize()
        {
            return this.redo.Count;
        }

        /// <summary>
        /// Use to set the account balance.
        /// Protected usage for only deriving classes.
        /// </summary>
        /// <param name="result"> the specific amount. </param>
        protected void SetAccBalance(double result)
        {
            this.accBalance = result;
        }
    }
}

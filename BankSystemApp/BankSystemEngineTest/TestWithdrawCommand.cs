// <copyright file="TestWithdrawCommand.cs" company="Boxiang Lin - WSU 011601661">
// Copyright (c) Boxiang Lin - WSU 011601661. All rights reserved.
// </copyright>

using BankSystemEngine;
using NUnit.Framework;

namespace BankSystemEngineTest
{
    /// <summary>
    /// Test the deposit command.
    /// </summary>
    [TestFixture]
    public class TestWithdrawCommand
    {
        /// <summary>
        /// Test Execute command.
        /// </summary>
        [Test]
        public void TestExecute()
        {
            SavingAccount acc = new SavingAccount(123);
            acc.Deposit(100.0);
            WithdrawCommand dc = new WithdrawCommand(acc, 50.0);
            dc.Execute();
            Assert.AreEqual(acc.GetAccBalance(), 50.0);
        }

        /// <summary>
        /// Test Unexecute command.
        /// </summary>
        [Test]
        public void TestUnexecute()
        {
            SavingAccount acc = new SavingAccount(123);
            acc.Deposit(100.0);
            WithdrawCommand dc = new WithdrawCommand(acc, 50.0);
            dc.Execute();
            dc.Unexecute();
            Assert.AreEqual(acc.GetAccBalance(), 100.0);
        }
    }
}

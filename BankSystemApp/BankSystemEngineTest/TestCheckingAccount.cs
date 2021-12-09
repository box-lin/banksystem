// <copyright file="TestCheckingAccount.cs" company="Boxiang Lin - WSU 011601661">
// Copyright (c) Boxiang Lin - WSU 011601661. All rights reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BankSystemEngine;
using NUnit.Framework;

namespace BankSystemEngineTest
{
    /// <summary>
    /// Class to test the checking account.
    /// </summary>
    [TestFixture]
    public class TestCheckingAccount
    {
        /// <summary>
        /// Test get account number.
        /// </summary>
        [Test]
        public void TestGetAccountNumber()
        {
            /// <summary>
            /// checking account instance.
            /// </summary>
            CheckingAccount checkAcc = new CheckingAccount(123);
            Assert.AreEqual(checkAcc.GetAccNumber(), 123);
        }

        /// <summary>
        /// Test set account number.
        /// </summary>
        [Test]
        public void TestSetAccountNumber()
        {
            /// <summary>
            /// checking account instance.
            /// </summary>
            CheckingAccount checkAcc = new CheckingAccount(123);
            checkAcc.SetAccNumber(321);
            Assert.AreEqual(checkAcc.GetAccNumber(), 321);
        }

        /// <summary>
        /// Test get account balance.
        /// </summary>
        [Test]
        public void TestGetAccountBalance()
        {
            /// <summary>
            /// checking account instance.
            /// </summary>
            CheckingAccount checkAcc = new CheckingAccount(123);
            Assert.AreEqual(0.0, checkAcc.GetAccBalance());
        }

        /// <summary>
        /// Test deposit to balance..
        /// </summary>
        [Test]
        public void TestDeposit()
        {
            /// <summary>
            /// checking account instance.
            /// </summary>
            CheckingAccount checkAcc = new CheckingAccount(123);
            checkAcc.Deposit(100.0);
            Assert.AreEqual(100.0, checkAcc.GetAccBalance());
        }

        /// <summary>
        /// Test balance withdraw.
        /// </summary>
        [Test]
        public void TestWithdrawFail()
        {
            /// <summary>
            /// checking account instance.
            /// </summary>
            CheckingAccount checkAcc = new CheckingAccount(123);
            bool isSucess = checkAcc.Withdraw(100.0);
            Assert.AreEqual(false, isSucess);
        }

        /// <summary>
        /// Test balance withdraw.
        /// </summary>
        [Test]
        public void TestWithdrawSucess()
        {
            /// <summary>
            /// checking account instance.
            /// </summary>
            CheckingAccount checkAcc = new CheckingAccount(123);
            checkAcc.Deposit(500.0);
            bool isSucess = checkAcc.Withdraw(100.0);
            Assert.AreEqual(true, isSucess);
        }

        /// <summary>
        /// Test the check acc deposit with the command object.
        /// </summary>
        [Test]
        public void TestCheckingDepositWithCommand()
        {
            CheckingAccount checkAcc = new CheckingAccount(123);
            DepositCommand dc = new DepositCommand(checkAcc, 100.0);
            checkAcc.DepositChecking(dc);
            Assert.AreEqual(checkAcc.GetAccBalance(), 100.0);
        }

        /// <summary>
        /// Test the check acc withdraw with the command object.
        /// </summary>
        [Test]
        public void TestCheckingWIthdrawWithCommand()
        {
            CheckingAccount checkAcc = new CheckingAccount(123);
            checkAcc.Deposit(100.0);
            WithdrawCommand dc = new WithdrawCommand(checkAcc, 50.0);
            checkAcc.WithdrawChecking(dc);
            Assert.AreEqual(checkAcc.GetAccBalance(), 50.0);
        }
    }
}

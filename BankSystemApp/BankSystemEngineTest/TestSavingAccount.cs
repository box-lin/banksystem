// <copyright file="TestSavingAccount.cs" company="Boxiang Lin - WSU 011601661">
// Copyright (c) Boxiang Lin - WSU 011601661. All rights reserved.
// </copyright>

using BankSystemEngine;
using NUnit.Framework;

namespace BankSystemEngineTest
{
    /// <summary>
    /// Test saving account.
    /// </summary>
    [TestFixture]
    public class TestSavingAccount
    {

        /// <summary>
        /// Test get account number.
        /// </summary>
        [Test]
        public void TestGetAccountNumber()
        {
            /// <summary>
            /// saving account instance.
            /// </summary>
            SavingAccount checkAcc = new SavingAccount(123);
            Assert.AreEqual(checkAcc.GetAccNumber(), 123);
        }

        /// <summary>
        /// Test set account number.
        /// </summary>
        [Test]
        public void TestSetAccountNumber()
        {
            /// <summary>
            /// saving account instance.
            /// </summary>
            SavingAccount checkAcc = new SavingAccount(123);
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
            /// saving account instance.
            /// </summary>
            SavingAccount checkAcc = new SavingAccount(123);
            Assert.AreEqual(0.0, checkAcc.GetAccBalance());

        }

        /// <summary>
        /// Test deposit to balance..
        /// </summary>
        [Test]
        public void TestDeposit()
        {
            /// <summary>
            /// saving account instance.
            /// </summary>
            SavingAccount checkAcc = new SavingAccount(123);
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
            /// saving account instance.
            /// </summary>
            SavingAccount checkAcc = new SavingAccount(123);
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
            /// saving account instance.
            /// </summary>
            SavingAccount checkAcc = new SavingAccount(123);
            checkAcc.Deposit(500.0);
            bool isSucess = checkAcc.Withdraw(100.0);
            Assert.AreEqual(true, isSucess);
        }
    }
}

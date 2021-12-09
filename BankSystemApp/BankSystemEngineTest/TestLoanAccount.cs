// <copyright file="TestLoanAccount.cs" company="Boxiang Lin - WSU 011601661">
// Copyright (c) Boxiang Lin - WSU 011601661. All rights reserved.
// </copyright>

using BankSystemEngine;
using NUnit.Framework;

namespace BankSystemEngineTest
{
    /// <summary>
    /// Class to test the loan account.
    /// </summary>
    [TestFixture]
    public class TestLoanAccount
    {

        /// <summary>
        /// Test the Sucess request loan with command.
        /// </summary>
        [Test]
        public void TestGoodRequestLoandWithCommand()
        {
            LoanAccount la = new LoanAccount(123,1000.0);
            DepositCommand cmd = new DepositCommand(la, 300.0);
            bool success = la.RequestLoan(cmd);

            Assert.IsTrue(success);

            // note that the acc balance for loan is the amount owed.
            Assert.AreEqual(la.GetAccBalance(), 300.0);
        }


        /// <summary>
        /// Test the failure of request loan with command.
        /// </summary>
        [Test]
        public void TestBadRequestLoandWithCommand()
        {
            LoanAccount la = new LoanAccount(123, 1000.0);
            DepositCommand cmd = new DepositCommand(la, 1200.0);

            // out of limit so false
            bool success = la.RequestLoan(cmd);
            Assert.IsFalse(success);
            Assert.AreEqual(la.GetAccBalance(), 0.0);
        }

        /// <summary>
        /// Test the loan account with good pay amount as long as "pay amount". <= "Balance".
        /// </summary>
        [Test]
        public void TestGoodPayLoanWithCommand()
        {
            LoanAccount la = new LoanAccount(123, 1000.0);

            // suppose owed $200.00;
            la.Deposit(200.00); 

            WithdrawCommand cmd = new WithdrawCommand(la, 200.0);

            // pay $200 so not more owed.
            bool success = la.PayOffLoan(cmd);

            Assert.IsTrue(success);
            Assert.AreEqual(la.GetAccBalance(), 0.0);
        }

        /// <summary>
        /// Test the loan account with bad pay amount.
        /// </summary>
        [Test]
        public void TestBadPayLoanWithCommand()
        {
            LoanAccount la = new LoanAccount(123, 1000.0);
            la.Deposit(200.00);

            WithdrawCommand cmd = new WithdrawCommand(la, 201.0);

            // only owed 200 cannot pay 201 back.
            bool success = la.PayOffLoan(cmd);
            Assert.IsFalse(success);

            // did not pay successfully.
            Assert.AreEqual(la.GetAccBalance(), 200.00);
        }
    }
}

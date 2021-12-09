// <copyright file="TestClient.cs" company="Boxiang Lin - WSU 011601661">
// Copyright (c) Boxiang Lin - WSU 011601661. All rights reserved.
// </copyright>

using BankSystemEngine;
using NUnit.Framework;

namespace BankSystemEngineTest
{
    /// <summary>
    /// Test the client class.
    /// </summary>
    [TestFixture]
    public class TestClient
    {
        /// <summary>
        /// Test success the creation of saving account.
        /// </summary>
        [Test]
        public void TestSucessCreateSavingAccount()
        {
            Client client = new Client("c", "123", "ccc", "aaa", "c@wsu.edu");
            client.CreateSavingAcc(1, 15000.00);
            Assert.AreEqual(client.GetAllSavingAccount().Count, 1);
            Assert.IsTrue(client.GetAllSavingAccount().ContainsKey(1));
        }

        /// <summary>
        /// Test fail the creation of saving account, because of the default limit balance constrain.
        /// </summary>
        [Test]
        public void TestFailCreateSavingAccount()
        {
            Client client = new Client("c", "123", "ccc", "aaa", "c@wsu.edu");
            bool sucess = client.CreateSavingAcc(1, 100.00);
            Assert.IsFalse(sucess);
            Assert.IsFalse(client.GetAllSavingAccount().ContainsKey(1));
        }

        /// <summary>
        /// Test the creation of checking account.
        /// </summary>
        [Test]
        public void TestCreateCheckingAccount()
        {
            Client client = new Client("c", "123", "ccc", "aaa", "c@wsu.edu");
            client.CreateCheckingAcc(1, 15000.00);
            Assert.AreEqual(client.GetAllCheckingAccount().Count, 1);
            Assert.IsTrue(client.GetAllCheckingAccount().ContainsKey(1));
        }

        /// <summary>
        /// Test the creation of loan account.
        /// </summary>
        [Test]
        public void TestCreateLoanAccount()
        {
            Client client = new Client("c", "123", "ccc", "aaa", "c@wsu.edu");
            client.CreateLoanAcc(1, 1000.00);
            Assert.AreEqual(client.GetAllLoanAccount().Count, 1);
            Assert.IsTrue(client.GetAllLoanAccount().ContainsKey(1));
        }

        /// <summary>
        /// Test the deposit saving acc.
        /// </summary>
        [Test]
        public void TestDepositSavingAcc()
        {
            Client client = new Client("c", "123", "ccc", "aaa", "c@wsu.edu");
            client.CreateSavingAcc(1, 15000.00);
            Assert.AreEqual(client.GetAllSavingAccount().Count, 1);
            bool success = client.DepositSavingAcc(1, 500.0);
            Assert.IsTrue(success);
            Assert.AreEqual(client.GetAllSavingAccount()[1].GetAccBalance(), 15500.0);
        }

        /// <summary>
        /// Test the deposit checking acc.
        /// </summary>
        [Test]
        public void TestDepositCheckingAcc()
        {
            Client client = new Client("c", "123", "ccc", "aaa", "c@wsu.edu");
            client.CreateCheckingAcc(1, 15000.00);
            Assert.AreEqual(client.GetAllCheckingAccount().Count, 1);
            bool success = client.DepositCheckingAcc(1, 500.0);
            Assert.IsTrue(success);
            Assert.AreEqual(client.GetAllCheckingAccount()[1].GetAccBalance(), 15500.0);
        }

        /// <summary>
        /// Test the deposit checking acc.
        /// </summary>
        [Test]
        public void TestRequestLoanLoanAcc()
        {
            Client client = new Client("c", "123", "ccc", "aaa", "c@wsu.edu");
            client.CreateLoanAcc(1, 15000.00);
            Assert.AreEqual(client.GetAllLoanAccount().Count, 1);
            Assert.IsTrue(client.GetAllLoanAccount().ContainsKey(1));
            bool success = client.RequestLoanLoanAcc(1, 200.0);
            Assert.IsTrue(success);
            Assert.AreEqual(client.GetAllLoanAccount()[1].GetAccBalance(), 200.0);
        }

        /// <summary>
        /// Test the withdraw saving acc.
        /// </summary>
        [Test]
        public void TestWithdrawSavingAcc()
        {
            Client client = new Client("c", "123", "ccc", "aaa", "c@wsu.edu");
            client.CreateSavingAcc(1, 18000.00);
            Assert.AreEqual(client.GetAllSavingAccount().Count, 1);
            bool success = client.WithdrawSavingAcc(1, 100.0);
            Assert.IsTrue(success);
            Assert.AreEqual(client.GetAllSavingAccount()[1].GetAccBalance(), 17900.0);
        }

        /// <summary>
        /// Test withdraw from checking acc.
        /// </summary>
        [Test]
        public void TestWithdrawCheckingAcc()
        {
            Client client = new Client("c", "123", "ccc", "aaa", "c@wsu.edu");
            client.CreateCheckingAcc(1, 15000.00);
            Assert.AreEqual(client.GetAllCheckingAccount().Count, 1);
            bool success = client.WithdrawCheckingAcc(1, 200.0);
            Assert.IsTrue(success);
            Assert.AreEqual(client.GetAllCheckingAccount()[1].GetAccBalance(), 14800.0);
        }

        /// <summary>
        /// Test the pay loan to loan acc.
        /// </summary>
        [Test]
        public void TestPayPaymentLoanAcc()
        {
            Client client = new Client("c", "123", "ccc", "aaa", "c@wsu.edu");
            client.CreateLoanAcc(1, 15000.00);
            Assert.AreEqual(client.GetAllLoanAccount().Count, 1);
            Assert.IsTrue(client.GetAllLoanAccount().ContainsKey(1));
            bool success = client.RequestLoanLoanAcc(1, 200.0);
            Assert.IsTrue(success);
            Assert.AreEqual(client.GetAllLoanAccount()[1].GetAccBalance(), 200.0);

            client.PayPymentLoanAcc(1, 200.0);
            Assert.AreEqual(client.GetAllLoanAccount()[1].GetAccBalance(), 0.0);

        }
    }
}

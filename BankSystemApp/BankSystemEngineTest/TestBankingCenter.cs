// <copyright file="TestBankingCenter.cs" company="Boxiang Lin - WSU 011601661">
// Copyright (c) Boxiang Lin - WSU 011601661. All rights reserved.
// </copyright>

using BankSystemEngine;
using NUnit.Framework;
using System.IO;

namespace BankSystemEngineTest
{
    /// <summary>
    /// Test BankingCenter class.
    /// </summary>
    [TestFixture]
    public class TestBankingCenter
    {
        /// <summary>
        /// Test the existence of dummy accounts.
        /// </summary>
        [Test]
        public void TestDummyAccounts()
        {
            // when BankingCenter instantiated, dummy account has been registered
            BankingCenter bc = new BankingCenter();
            Assert.AreEqual(bc.GetAllClientAcc().Count, 2);
            Assert.AreEqual(bc.GetAllEmplopyeeAcc().Count, 1);
        }

        /// <summary>
        /// Test success login determination.
        /// </summary>
        [Test]
        public void TestSuccessLoginClient()
        {
            BankingCenter bc = new BankingCenter();
            bool login = bc.LoginClient("boxiang", "123");
            Assert.IsTrue(login);
        }

        /// <summary>
        /// Test failed login determination.
        /// </summary>
        [Test]
        public void TestFailedLoginClient()
        {
            BankingCenter bc = new BankingCenter();
            bool login = bc.LoginClient("box", "123");
            Assert.IsFalse(login);
        }

        /// <summary>
        /// Test success login determination.
        /// </summary>
        [Test]
        public void TestSuccessLoginEmployee()
        {
            BankingCenter bc = new BankingCenter();
            bool login = bc.LoginEmployee("john", "321");
            Assert.IsTrue(login);
        }

        /// <summary>
        /// Test failed login determination.
        /// </summary>
        [Test]
        public void TestFailedLoginEmployee()
        {
            BankingCenter bc = new BankingCenter();
            bool login = bc.LoginEmployee("box", "123");
            Assert.IsFalse(login);
        }

        /// <summary>
        /// Test create cheking account wrapper.
        /// </summary>
        [Test]
        public void TestCreateCheckingAccount()
        {
            BankingCenter bc = new BankingCenter();
            Client client = bc.GetAllClientAcc()["boxiang"];
            bc.CreateCheckingAccount(client, 16000.00);
            Assert.AreEqual(client.GetAllCheckingAccount().Count, 1);
        }

        /// <summary>
        /// Test create saving account wrapper.
        /// </summary>
        [Test]
        public void TestCreateSavingAccount()
        {
            BankingCenter bc = new BankingCenter();
            Client client = bc.GetAllClientAcc()["boxiang"];
            bc.CreateSavingAccount(client, 16000.00);
            Assert.AreEqual(client.GetAllSavingAccount().Count, 1);
        }

        /// <summary>
        /// Test create loan account wrapper.
        /// </summary>
        [Test]
        public void TestCreateLoanAccount()
        {
            BankingCenter bc = new BankingCenter();
            Client client = bc.GetAllClientAcc()["boxiang"];
            bc.CreateLoanAccount(client, 16000.00);
            Assert.AreEqual(client.GetAllLoanAccount().Count, 1);
        }

        /// <summary>
        /// Test the wrote file in diretory of BankSystemApp project.
        /// </summary>
        [Test]
        public void TestFailWriteAccountToLocal()
        {
            BankingCenter bc = new BankingCenter();
            var path = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase);
            path = path.Substring(6);
            StreamReader sr = new StreamReader(path + "/accounts.txt");
            Assert.IsTrue(sr != null);
        }

        /*Due to the design that required user input (console.readline()) for undo and redo command inside of these method,
         * now comment them out.
        /// <summary>
        /// Test account deposit wrapper.
        /// </summary>
        [Test]
        public void TestAccountDeposit()
        {
            BankingCenter bc = new BankingCenter();
            Client client = bc.GetAllClientAcc()["boxiang"];
            bc.CreateCheckingAccount(client, 16000.00);
            int accNum = bc.GetCurrentAccountNumber();
            bc.AccountDeposit(client, accNum, 500.0);
            Assert.AreEqual(bc.GetAllClientAcc()["boxiang"].GetAllCheckingAccount()[accNum].GetAccBalance(), 16500.0);
        }

        /// <summary>
        /// Test account withdraw wrapper.
        /// </summary>
        [Test]
        public void TestAccountWithdraw()
        {
            BankingCenter bc = new BankingCenter();
            Client client = bc.GetAllClientAcc()["boxiang"];
            bc.CreateCheckingAccount(client, 16000.00);
            int accNum = bc.GetCurrentAccountNumber();
            bc.AccountWithdraw(client, accNum, 500.0);
            Assert.AreEqual(bc.GetAllClientAcc()["boxiang"].GetAllCheckingAccount()[accNum].GetAccBalance(), 15500.0);
        }*/
    }
}

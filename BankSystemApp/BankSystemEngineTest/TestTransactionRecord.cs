// <copyright file="TestTransactionRecord.cs" company="Boxiang Lin - WSU 011601661">
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
    /// This is to test the transaction record collection.
    /// </summary>
    [TestFixture]
    public class TestTransactionRecord
    {
        /// <summary>
        /// Test within 10 transaction count.
        /// </summary>
        [Test]
        public void TestGeneralCountTransactionRecord()
        {
            // note: the update transaction is provided our outter access, here we just hard updated.
            DummyAccount acc = new DummyAccount(123);
            acc.UpdateTransaction(acc.GetAccNumber(), "Deposit", 1.0, 0.0, DateTime.Now.ToLocalTime().ToString());
            acc.UpdateTransaction(acc.GetAccNumber(), "Deposit", 1.0, 0.0, DateTime.Now.ToLocalTime().ToString());
            acc.UpdateTransaction(acc.GetAccNumber(), "Deposit", 1.0, 0.0, DateTime.Now.ToLocalTime().ToString());
            acc.UpdateTransaction(acc.GetAccNumber(), "Deposit", 1.0, 0.0, DateTime.Now.ToLocalTime().ToString());
            Assert.AreEqual(4, acc.GetTransactionCount());
        }

        /// <summary>
        /// Test more than 10 transaction.
        /// </summary>
        [Test]
        public void TestOverflowCountTransactionrecord()
        {
            DummyAccount acc = new DummyAccount(123);
            for (int i = 0; i < 20; i++)
            {
                acc.UpdateTransaction(acc.GetAccNumber(), "Deposit", 1.0, 0.0, DateTime.Now.ToLocalTime().ToString());
            }

            Assert.AreEqual(10, acc.GetTransactionCount());
        }

        /// <summary>
        /// Dummy account use to test collections of transaction record.
        /// </summary>
        internal class DummyAccount : BankAccount
        {
            /// <summary>
            /// Initializes a new instance of the <see cref="DummyAccount"/> class.
            /// </summary>
            /// <param name="accNumber"> acc number. </param>
            public DummyAccount(int accNumber)
                : base(accNumber)
            {
            }
        }
    }
}

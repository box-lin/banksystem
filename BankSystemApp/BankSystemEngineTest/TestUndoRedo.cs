// <copyright file="TestUndoRedo.cs" company="Boxiang Lin - WSU 011601661">
// Copyright (c) Boxiang Lin - WSU 011601661. All rights reserved.
// </copyright>

using BankSystemEngine;
using NUnit.Framework;

namespace BankSystemEngineTest
{
    /// <summary>
    /// Test the undo and redo for operation of deposit and withdraw.
    /// </summary>
    public class TestUndoRedo
    {
        /// <summary>
        /// Test to see if we can undo the most recent operation.
        /// </summary>
        [Test]
        public void TestTheUndoOfLastTransaction()
        {
            DummyAccount acc = new DummyAccount(123);
            DepositCommand cmd = new DepositCommand(acc, 100.00);
            acc.DummyDeposit(cmd);
            Assert.AreEqual(100.0, acc.GetAccBalance());

            // test to see the undo stack has something or not.
            Assert.AreEqual(1, acc.GetUndoStackSize());

            // undo it.
            acc.RunUndoCommand();

            // balance back to 0.0;
            Assert.AreEqual(0.0, acc.GetAccBalance());

            // undo should be 0.
            Assert.AreEqual(0, acc.GetUndoStackSize());
        }

        /// <summary>
        /// Test the redo of last transaction.
        /// </summary>
        [Test]
        public void TestTheRedoOfLastTransaction()
        {
            DummyAccount acc = new DummyAccount(123);
            DepositCommand cmd = new DepositCommand(acc, 100.00);
            acc.DummyDeposit(cmd);
            Assert.AreEqual(100.0, acc.GetAccBalance());

            // test to see the undo stack has something or not.
            Assert.AreEqual(1, acc.GetUndoStackSize());

            // undo it.
            acc.RunUndoCommand();

            // balance back to 0.0;
            Assert.AreEqual(0.0, acc.GetAccBalance());

            // redo should be 1.
            Assert.AreEqual(1, acc.GetRedoStackSize());

            acc.RunRedoCommand();

            // back to 100.0 balance.
            Assert.AreEqual(100.0, acc.GetAccBalance());
        }

        /// <summary>
        /// Dummy bank account.
        /// </summary>
        private class DummyAccount : BankAccount
        {
            /// <summary>
            /// Initializes a new instance of the <see cref="DummyAccount"/> class.
            /// </summary>
            /// <param name="accNumber"> account number. </param>
            public DummyAccount(int accNumber)
                : base(accNumber)
            {
            }

            /// <summary>
            /// deposit interface by command pattern.
            /// </summary>
            /// <param name="command"> command object. </param>
            /// <returns>can deposit or not. </returns>
            public bool DummyDeposit(DepositCommand command)
            {
                bool isSuccess = command.Execute();
                if (isSuccess)
                {
                    this.NewCommandAdd(command);
                }

                return isSuccess;
            }

            /// <summary>
            /// withdraw interface by command pattern.
            /// </summary>
            /// <param name="command"> Withdraw command. </param>
            /// <returns> can withdraw or not. </returns>
            public bool DummyWithdraw(WithdrawCommand command)
            {
                bool isSuccess = command.Execute();
                if (isSuccess)
                {
                    this.NewCommandAdd(command);
                }

                return isSuccess;
            }
        }
    }
}

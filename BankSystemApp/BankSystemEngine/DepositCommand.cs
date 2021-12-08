using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankSystemEngine
{
    /// <summary>
    /// Deposite command to do the deposit.
    /// </summary>
    public class DepositCommand : ICommand
    {
        public DepositCommand(BankAccount acc, double amount)
        {

        }

        /// <summary>
        /// Execute the deposite.
        /// </summary>
        /// <returns> can execute or not. </returns>
        public bool Execute()
        {
            return false;
        }

        /// <summary>
        /// Unexecute the deposite.
        /// </summary>
        public void Unexecute()
        {
        }
    }
}

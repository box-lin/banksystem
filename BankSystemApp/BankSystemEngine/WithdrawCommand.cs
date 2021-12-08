using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankSystemEngine
{
    /// <summary>
    /// Withdraw command class to handle the withdraw.
    /// </summary>
    public class WithdrawCommand : ICommand
    {

        /// <summary>
        /// Execute the withdraw.
        /// </summary>
        /// <returns> can withdraw or not. </returns>
        public bool Execute()
        {
            return false;
        }

        /// <summary>
        /// Unexecute the withdraw.
        /// </summary>
        public void Unexecute()
        {
            throw new NotImplementedException();
        }
    }
}

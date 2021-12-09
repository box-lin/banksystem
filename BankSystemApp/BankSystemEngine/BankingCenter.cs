using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankSystemEngine
{
    /// <summary>
    /// The center of the bank that handles the request from users.
    /// </summary>
    public class BankingCenter
    {
        // register user here receive commands from bank center.
        private RegisterUser reg;

        // let the account number starts at 999 and keep increment each time account created.
        private int accNumber = 999;

        /// <summary>
        /// Initializes a new instance of the <see cref="BankingCenter"/> class.
        /// </summary>
        public BankingCenter()
        {
            // create some accounts.
            this.DummyRegistration();
        }

        /// <summary>
        /// Determine if the input username and password correctness and existence.
        /// </summary>
        /// <param name="username"> username. </param>
        /// <param name="password"> password. </param>
        /// <returns> found client or not. </returns>
        public bool LoginClient(string username, string password)
        {
            return false;
        }

        /// <summary>
        /// Account deposite wrapper.
        /// </summary>
        /// <param name="loggedClient"> logined client. </param>
        /// <param name="accNumber"> account number. </param>
        /// <param name="amount"> amount deposit. </param>
        /// <returns> can deposit or not. </returns>
        public bool AccountDeposit(Client loggedClient, int accNumber, double amount)
        {
            return false;
        }

        /// <summary>
        /// Account withdraw wrapper.
        /// </summary>
        /// <param name="loggedClient"> logined client. </param>
        /// <param name="accNumber"> account number. </param>
        /// <param name="amount"> amount withdraw. </param>
        /// <returns> can withdraw or not. </returns>
        public bool AccountWithdraw(Client loggedClient, int accNumber, double amount)
        {
            return false;
        }

        /// <summary>
        /// Create checking account wrapper with respected to logined client.
        /// </summary>
        /// <param name="loggedClient"> logined client. </param>
        /// <param name="initAmount"> intial deposit. </param>
        public void CreateCheckingAccount(Client loggedClient, double initAmount)
        {
        }

        /// <summary>
        /// Create saving account wrapper with respected to logined client.
        /// </summary>
        /// <param name="loggedClient"> logined client. </param>
        /// <param name="initAmount"> initial deposit. </param>
        public void CreateSavingAccount(Client loggedClient, double initAmount)
        {
        }

        /// <summary>
        /// Create loan account wrapper with respected to logined client.
        /// </summary>
        /// <param name="loggedClient"> logined client. </param>
        /// <param name="loanLimit"> loan limit. </param>
        public void CreateLoanAccount(Client loggedClient, double loanLimit)
        {
        }

        /// <summary>
        /// hard coded few accounts for this version.
        /// </summary>
        private void DummyRegistration()
        {
            this.reg.RegisterClient("boxiang", "123", "Boxiang", "Lin", "boxiang.lin@wsu.edu");
            this.reg.RegisterClient("sam", "123", "Sam", "Sam", "sam@wsu.edu");
            this.reg.RegisterEmployee("john", "321", "John", "John", "john@wsu.edu");
        }

        /// <summary>
        /// Account number Iterator.
        /// </summary>
        /// <returns> next distinct accout number. </returns>
        private int GetNextAccountNumber()
        {
            return -1;
        }
    }
}

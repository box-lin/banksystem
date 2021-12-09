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

        // client with set of acc nums.
        private Dictionary<Client, HashSet<int>> clientAccount;

        // register user here receive commands from bank center.
        private RegisterUser reg;

        // let the account number starts at 999 and keep increment each time account created.
        private int accNumber = 999;

        /// <summary>
        /// Initializes a new instance of the <see cref="BankingCenter"/> class.
        /// </summary>
        public BankingCenter()
        {
            this.reg = new RegisterUser();
            this.clientAccount = new Dictionary<Client, HashSet<int>>();

            // create some accounts.
            this.DummyRegistration();

            // init client to acc num dictionary.
            this.InitClientDict();
        }

        /// <summary>
        /// Determine if the input username and password correctness and existence.
        /// </summary>
        /// <param name="username"> username. </param>
        /// <param name="password"> password. </param>
        /// <returns> found client or not. </returns>
        public bool LoginClient(string username, string password)
        {
            Client client = this.reg.GetClient(username);
            if (client == null)
            {
                return false;
            }

            if (password != client.GetPassWord())
            {
                return false;
            }

            return true;
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
            bool deposited = false;
            bool undo = false;

            if (loggedClient.GetAllSavingAccount().ContainsKey(accNumber))
            {
                deposited = loggedClient.DepositSavingAcc(accNumber, amount);
                SavingAccount saveAcc = loggedClient.GetAllSavingAccount()[accNumber];
                if (deposited)
                {
                    // later.
                    undo = false;
                }

                if (!undo)
                {
                    saveAcc.UpdateTransaction(accNumber, "Deposit", amount, saveAcc.GetAccBalance(), DateTime.Now.ToLocalTime().ToString());
                }

                return deposited && (!undo);
            }
            else if (loggedClient.GetAllCheckingAccount().ContainsKey(accNumber))
            {
                deposited = loggedClient.DepositCheckingAcc(accNumber, amount);
                CheckingAccount checkAcc = loggedClient.GetAllCheckingAccount()[accNumber];
                if (deposited)
                {
                    undo = false;
                }

                if (!undo)
                {
                    checkAcc.UpdateTransaction(accNumber, "Deposit", amount, checkAcc.GetAccBalance(), DateTime.Now.ToLocalTime().ToString());
                }

                return deposited && (!undo);
            }
            else if (loggedClient.GetAllLoanAccount().ContainsKey(accNumber))
            {
                deposited = loggedClient.RequestLoanLoanAcc(accNumber, amount); // balance here is what owed.
                LoanAccount loanAcc = loggedClient.GetAllLoanAccount()[accNumber];
                if (deposited)
                {
                    undo = false;
                }

                if (!undo)
                {
                    loanAcc.UpdateTransaction(accNumber, "Borrow", amount, loanAcc.GetAccBalance(), DateTime.Now.ToLocalTime().ToString());
                }

                return deposited && (!undo);
            }

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
            bool withdraw = false;
            bool undo = false;
            if (loggedClient.GetAllSavingAccount().ContainsKey(accNumber))
            {
                withdraw = loggedClient.WithdrawSavingAcc(accNumber, amount);
                SavingAccount saveAcc = loggedClient.GetAllSavingAccount()[accNumber];
                if (withdraw)
                {
                    undo = false;
                }

                if (!undo)
                {
                    saveAcc.UpdateTransaction(accNumber, "Withdraw", amount, saveAcc.GetAccBalance(), DateTime.Now.ToLocalTime().ToString());
                }

                return withdraw && (!undo);
            }
            else if (loggedClient.GetAllCheckingAccount().ContainsKey(accNumber))
            {
                withdraw = loggedClient.WithdrawCheckingAcc(accNumber, amount);
                CheckingAccount checkAcc = loggedClient.GetAllCheckingAccount()[accNumber];
                if (withdraw)
                {
                    undo = false;
                }

                if (!undo)
                {
                    checkAcc.UpdateTransaction(accNumber, "Withdraw", amount, checkAcc.GetAccBalance(), DateTime.Now.ToLocalTime().ToString());
                }

                return withdraw && (!undo);
            }
            else if (loggedClient.GetAllLoanAccount().ContainsKey(accNumber))
            {
                withdraw = loggedClient.PayPymentLoanAcc(accNumber, amount);
                LoanAccount loanAcc = loggedClient.GetAllLoanAccount()[accNumber];
                if (withdraw)
                {
                    undo = false;
                }

                if (!undo)
                {
                    loanAcc.UpdateTransaction(accNumber, "PayLoan", amount, loanAcc.GetAccBalance(), DateTime.Now.ToLocalTime().ToString());
                }

                return withdraw && (!undo);
            }

            return false;
        }

        /// <summary>
        /// Create checking account wrapper with respected to logined client.
        /// </summary>
        /// <param name="loggedClient"> logined client. </param>
        /// <param name="initAmount"> intial deposit. </param>
        public void CreateCheckingAccount(Client loggedClient, double initAmount)
        {
            int accNumber = this.GetNextAccountNumber();
            loggedClient.CreateCheckingAcc(accNumber, initAmount);
            if (!this.clientAccount.ContainsKey(loggedClient))
            {
                this.clientAccount[loggedClient] = new HashSet<int>();
            }

            this.clientAccount[loggedClient].Add(accNumber);
            Console.WriteLine("* Your checking account with account number:  #" + accNumber + " has been created!");
        }

        /// <summary>
        /// Create saving account wrapper with respected to logined client.
        /// </summary>
        /// <param name="loggedClient"> logined client. </param>
        /// <param name="initAmount"> initial deposit. </param>
        public void CreateSavingAccount(Client loggedClient, double initAmount)
        {
            int accNumber = this.GetNextAccountNumber();
            bool okRegiter = loggedClient.CreateSavingAcc(accNumber, initAmount);
            if (okRegiter)
            {
                if (!this.clientAccount.ContainsKey(loggedClient))
                {
                    this.clientAccount[loggedClient] = new HashSet<int>();
                }

                this.clientAccount[loggedClient].Add(accNumber);
                Console.WriteLine("* Your saving account with account number:  #" + accNumber + " has been created!");
            }
        }

        /// <summary>
        /// Create loan account wrapper with respected to logined client.
        /// </summary>
        /// <param name="loggedClient"> logined client. </param>
        /// <param name="loanLimit"> loan limit. </param>
        public void CreateLoanAccount(Client loggedClient, double loanLimit)
        {
            int accNumber = this.GetNextAccountNumber();
            loggedClient.CreateLoanAcc(accNumber, loanLimit);
            if (!this.clientAccount.ContainsKey(loggedClient))
            {
                this.clientAccount[loggedClient] = new HashSet<int>();
            }

            this.clientAccount[loggedClient].Add(accNumber);
            Console.WriteLine("* Your loan account with account number:  #" + accNumber + " has been created!");
        }

        /// <summary>
        /// Gets all client account in RegisterUser container.
        /// </summary>
        /// <returns> dict of client. </returns>
        public Dictionary<string, Client> GetAllClientAcc()
        {
            return this.reg.GetAllClientAccount();
        }

        /// <summary>
        /// Gets all employee account in RegistgerUser container.
        /// </summary>
        /// <returns>dict of employee. </returns>
        public Dictionary<string, Employee> GetAllEmplopyeeAcc()
        {
            return this.reg.GetAllEmployeeAccount();
        }

        /// <summary>
        /// Gets the current account number counter.
        /// </summary>
        /// <returns> account number. </returns>
        public int GetCurrentAccountNumber()
        {
            return this.accNumber;
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
            this.accNumber += 1;
            return this.accNumber;
        }

        /// <summary>
        /// Init the client:accnums dictionary.
        /// </summary>
        private void InitClientDict()
        {
            foreach (Client c in this.reg.GetAllClientAccount().Values)
            {
                this.clientAccount[c] = new HashSet<int>();
            }
        }
    }
}

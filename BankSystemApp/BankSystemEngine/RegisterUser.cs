using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankSystemEngine
{
    /// <summary>
    /// A register class that performs the registration request send from bank center.
    /// ---> A placeholder class for thrid party registration library.
    /// </summary>
    public class RegisterUser
    {
        // unique username helper.
        private HashSet<string> uniqueUsername;

        // unique email helper.
        private HashSet<string> uniqueEmail;

        // storage of client users with respect to username, so can later use in login.
        private Dictionary<string, Client> clientUsers;

        // storage of employee users with respect to username, so can later use in login.
        private Dictionary<string, Employee> employeeUsers;


        /// <summary>
        /// Initializes a new instance of the <see cref="RegisterUser"/> class.
        /// </summary>
        public RegisterUser()
        {
            this.uniqueUsername = new HashSet<string>();
            this.uniqueEmail = new HashSet<string>();
            this.clientUsers = new Dictionary<string, Client>();
            this.employeeUsers = new Dictionary<string, Employee>();
        }

        /// <summary>
        /// Register the client. (should replace with professional thrid party registration interface).
        /// </summary>
        /// <param name="userName"> username. </param>
        /// <param name="passWord"> password. </param>
        /// <param name="firstName"> firstname. </param>
        /// <param name="lastName"> lastname. </param>
        /// <param name="email"> email. </param>
        public void RegisterClient(string userName, string passWord, string firstName, string lastName, string email)
        {
        }

        /// <summary>
        /// Register the employee (should replace with professional thrid party registration interface).
        /// </summary>
        /// <param name="userName"> username. </param>
        /// <param name="passWord"> password. </param>
        /// <param name="firstName"> firstname.</param>
        /// <param name="lastName"> lastname. </param>
        /// <param name="email"> email. </param>
        public void RegisterEmployee(string userName, string passWord, string firstName, string lastName, string email)
        {
        }

        /// <summary>
        /// Get client by username.
        /// </summary>
        /// <param name="username"> username. </param>
        /// <returns> loggined client. </returns>
        public Client GetClient(string username)
        {
            return null;
        }

        /// <summary>
        /// Get all client accounts.
        /// </summary>
        /// <returns> client dict. </returns>
        public Dictionary<string, Client> GetAllClientAccount()
        {
            return this.clientUsers;
        }

        /// <summary>
        /// Get all employee accounts.
        /// </summary>
        /// <returns> employee dict. </returns>
        public Dictionary<string, Employee> GetAllEmployeeAccount()
        {
            return this.employeeUsers;
        }
    }
}

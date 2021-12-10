// <copyright file="User.cs" company="Boxiang Lin - WSU 011601661">
// Copyright (c) Boxiang Lin - WSU 011601661. All rights reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankSystemEngine
{
    /// <summary>
    /// The generic user class.
    /// </summary>
    public abstract class User
    {
        private string userName;
        private string passWord;
        private string firstName;
        private string lastName;
        private string email;

        /// <summary>
        /// Initializes a new instance of the <see cref="User"/> class.
        /// </summary>
        /// <param name="userName"> user's username. </param>
        /// <param name="passWord"> user's password. </param>
        /// <param name="firstName"> user firstname. </param>
        /// <param name="lastName"> user lastname. </param>
        /// <param name="email"> user email. </param>
        public User(string userName, string passWord, string firstName, string lastName, string email)
        {
            this.userName = userName;
            this.passWord = passWord;
            this.firstName = firstName;
            this.lastName = lastName;
            this.email = email;
        }

        /// <summary>
        /// Get user name.
        /// </summary>
        /// <returns> User name. </returns>
        public string GetUserName()
        {
            return this.userName;
        }

        /// <summary>
        /// Set username.
        /// </summary>
        /// <param name="userName"> username. </param>
        public void SetUserName(string userName)
        {
            this.userName = userName;
        }

        /// <summary>
        /// Get the password of the user.
        /// </summary>
        /// <returns> password. </returns>
        public string GetPassWord()
        {
            return this.passWord;
        }

        /// <summary>
        /// Set user's password.
        /// </summary>
        /// <param name="passWord"> new password. </param>
        public void SetPassWord(string passWord)
        {
            this.passWord = passWord;
        }

        /// <summary>
        /// Get user last name.
        /// </summary>
        /// <returns> last name. </returns>
        public string GetFirstName()
        {
            return this.firstName;
        }

        /// <summary>
        /// Get user first name.
        /// </summary>
        /// <param name="firstName"> user firstname. </param>
        public void SetFirstName(string firstName)
        {
            this.firstName = firstName;
        }

        /// <summary>
        /// Get user last name.
        /// </summary>
        /// <returns> lastname. </returns>
        public string GetLastName()
        {
            return this.lastName;
        }

        /// <summary>
        /// Set user lastname.
        /// </summary>
        /// <param name="lastName"> lastname. </param>
        public void SetLastName(string lastName)
        {
            this.lastName = lastName;
        }

        /// <summary>
        /// Get user email.
        /// </summary>
        /// <returns> email. </returns>
        public string GetEmail()
        {
            return this.email;
        }

        /// <summary>
        /// Set user email.
        /// </summary>
        /// <param name="email"> email. </param>
        public void SetEmail(string email)
        {
            this.email = email;
        }

        /// <summary>
        /// Overrides the tostring.
        /// </summary>
        /// <returns> info about the user. </returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("username: " + this.userName);
            sb.AppendLine("password: " + this.passWord);
            return sb.ToString();
        }
    }
}

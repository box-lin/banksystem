// <copyright file="Employee.cs" company="Boxiang Lin - WSU 011601661">
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
    /// Employee class.
    /// </summary>
    public class Employee : User
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Employee"/> class.
        /// </summary>
        /// <param name="userName"> username. </param>
        /// <param name="passWord"> password. </param>
        /// <param name="firstName"> firstname. </param>
        /// <param name="lastName"> lastname. </param>
        /// <param name="email"> email. </param>
        public Employee(string userName, string passWord, string firstName, string lastName, string email)
         : base(userName, passWord, firstName, lastName, email)
        {
        }
    }
}

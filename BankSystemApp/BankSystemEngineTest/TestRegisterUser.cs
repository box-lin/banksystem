// <copyright file="TestRegisterUser.cs" company="Boxiang Lin - WSU 011601661">
// Copyright (c) Boxiang Lin - WSU 011601661. All rights reserved.
// </copyright>

using BankSystemEngine;
using NUnit.Framework;

namespace BankSystemEngineTest
{
    /// <summary>
    /// Test the RegisterUser class.
    /// </summary>
    [TestFixture]
    public class TestRegisterUser
    {
        /// <summary>
        /// Test register client with no duplicates in username or email.
        /// </summary>
        [Test]
        public void TestSuccessRegisterClient()
        {
            RegisterUser reg = new RegisterUser();
            reg.RegisterClient("boxiang", "123", "Boxiang", "Lin", "boxiang.lin@wsu.edu");
            Assert.AreEqual(1, reg.GetAllClientAccount().Count);
            Assert.IsTrue(reg.GetAllClientAccount().ContainsKey("boxiang"));
        }

        /// <summary>
        /// Test register client with duplicates in username or email.
        /// </summary>
        [Test]
        public void TestFailRegisterClient()
        {
            RegisterUser reg = new RegisterUser();
            reg.RegisterClient("boxiang", "123", "Boxiang", "Lin", "boxiang.lin@wsu.edu");

            // duplicate name.
            reg.RegisterClient("boxiang", "123", "Boxiang", "Lin", "s.lin@wsu.edu");

            // duplicate email.
            reg.RegisterClient("boxig", "123", "Boxiang", "Lin", "boxiang.lin@wsu.edu");

            // should only have one in system.
            Assert.AreEqual(1, reg.GetAllClientAccount().Count);
            Assert.IsTrue(reg.GetAllClientAccount().ContainsKey("boxiang"));

            // is the first client in data, duplicate username not sucess.
            Assert.AreEqual(reg.GetAllClientAccount()["boxiang"].GetEmail(), "boxiang.lin@wsu.edu");

            // duplicate email registration not success.
            Assert.IsFalse(reg.GetAllClientAccount().ContainsKey("boxig"));
        }

        /// <summary>
        /// Test for employee registration with no duplicates.
        /// </summary>
        [Test]
        public void TestSucessRegisterEmployee()
        {
            RegisterUser reg = new RegisterUser();
            reg.RegisterEmployee("boxiang", "123", "Boxiang", "Lin", "boxiang.lin@wsu.edu");
            Assert.AreEqual(1, reg.GetAllEmployeeAccount().Count);
            Assert.IsTrue(reg.GetAllEmployeeAccount().ContainsKey("boxiang"));
        }

        /// <summary>
        /// Test for employee registration with duplicates username.
        /// </summary>
        [Test]
        public void TestFailRegisterEmplpyee()
        {
            RegisterUser reg = new RegisterUser();
            reg.RegisterEmployee("boxiang", "123", "Boxiang", "Lin", "boxiang.lin@wsu.edu");

            // duplicate username, registration failed.
            reg.RegisterEmployee("boxiang", "123", "Boxiang", "Lin", "bo.lin@wsu.edu");

            // duplicate email, registration failed.
            reg.RegisterEmployee("box", "123", "Boxiang", "Lin", "boxiang.lin@wsu.edu");

            // only one employee in system.
            Assert.AreEqual(1, reg.GetAllEmployeeAccount().Count);
            Assert.IsTrue(reg.GetAllEmployeeAccount().ContainsKey("boxiang"));

            // is the first register employee in data, duplicate username registration failed.
            Assert.AreEqual(reg.GetAllEmployeeAccount()["boxiang"].GetEmail(), "boxiang.lin@wsu.edu");

            // duplicate in email also failed.
            Assert.IsFalse(reg.GetAllEmployeeAccount().ContainsKey("box"));
        }

        /// <summary>
        /// Test get client method.
        /// </summary>
        [Test]
        public void TestGetClientAcc()
        {
            RegisterUser reg = new RegisterUser();
            reg.RegisterClient("boxiang", "123", "Boxiang", "Lin", "boxiang.lin@wsu.edu");
            Client client = reg.GetClient("boxiang");
            Assert.AreEqual("123", client.GetPassWord());
            Assert.AreEqual("Boxiang", client.GetFirstName());
            Assert.AreEqual("Lin", client.GetLastName());
            Assert.AreEqual("boxiang.lin@wsu.edu", client.GetEmail());
        }

        /// <summary>
        /// Test get employee method.
        /// </summary>
        [Test]
        public void TestGetEmployeeAcc()
        {
            RegisterUser reg = new RegisterUser();
            reg.RegisterEmployee("boxiang", "123", "Boxiang", "Lin", "boxiang.lin@wsu.edu");
            Employee employee = reg.GetEmployee("boxiang");
            Assert.AreEqual("123", employee.GetPassWord());
            Assert.AreEqual("Boxiang", employee.GetFirstName());
            Assert.AreEqual("Lin", employee.GetLastName());
            Assert.AreEqual("boxiang.lin@wsu.edu", employee.GetEmail());
        }
    }
}

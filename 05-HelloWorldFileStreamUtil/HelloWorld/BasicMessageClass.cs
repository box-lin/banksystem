/// <summary>
/// 
/// Name: Boxiang Lin 
/// ID: 011601661
/// In-Class Exercise 1
/// 
/// </summary>
using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace HelloWorld
{
    public class BasicMessageClass
    {

        private readonly string message;
        
        //default constructor 
        public BasicMessageClass()
        {
            this.message = "(Default Message)";
        }

        public BasicMessageClass(string message)
        {
            this.message = message;
        }

        /// <summary>
        /// Show the message upon the parameter of TextWriter
        ///     - Could show it on console 
        ///     - Could show it on streamwriter
        ///     - More operations that inheirted from TextWriter
        /// </summary>
        public void showMessage(TextWriter tw) => tw.WriteLine(this.message);
    
    }
}

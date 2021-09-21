// <copyright file="Utils.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace HelloWorldFileStream
{
    using System;
    using System.IO;
    using System.Text;

    /// <summary>
    /// Static useful methods are in this class.
    /// </summary>
    public class Utils
    {
        /// <summary>
        /// Write content into the file.
        /// </summary>
        /// <param name="s"> FileStream instance. </param>
        public static void WriteFile(FileStream s)
        {
            Console.WriteLine("Please enter the content that you want to write into the file below: ");
            byte[] helloWorldBytes = Encoding.UTF8.GetBytes(Console.ReadLine());
            s.Write(helloWorldBytes, 0, helloWorldBytes.Length);
        }
    }
}

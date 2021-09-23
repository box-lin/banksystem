// <copyright file="TheStream.cs" company="Boxiang Lin - WSU 011601661">
// Copyright (c) Boxiang Lin - WSU 011601661. All rights reserved.
// </copyright>

using System;
using System.IO;
using System.Text;

namespace StreamUtil
{
    /// <summary>
    /// DLL the stream class for file writes.
    /// </summary>
    public class StreamWrite
    {
        /// <summary>
        /// Write to File with console input.
        /// </summary>
        /// <param name="s"> FileStream object. </param>
        public static void WriteFile(FileStream s)
        {
            Console.WriteLine("Please enter the content that you want to write into the file below: ");
            byte[] helloWorldBytes = Encoding.UTF8.GetBytes(Console.ReadLine());
            s.Write(helloWorldBytes, 0, helloWorldBytes.Length);
        }
    }
}

﻿// <copyright file="Program.cs" company="Boxiang Lin - WSU 011601661">
// Copyright (c) Boxiang Lin - WSU 011601661. All rights reserved.
// </copyright>

using System;
using System.IO;
using StreamUtil;

namespace DLLwithStreamsDemo
{
    /// <summary>
    /// Program entry.
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Main entry to run the program.
        /// </summary>
        /// <param name="args"> optional string array input. </param>
        public static void Main(string[] args)
        {
            Program program = new Program();
            Console.WriteLine("Please enter the file name with .txt that you want to create: ");
            string fileName = Console.ReadLine();
            program.CreateAndSaveFile(fileName);
            Console.WriteLine("The {0}.txt has been created! Please now enter the content that you want to write into the file: ", fileName);

            // Design for content modification option in a loop, can press Q to quit.
            bool run = true;
            while (run)
            {
                Console.WriteLine("The content has been saved into the file, enter Q to quit and M to modify ");
                string op = Console.ReadLine();

                if (op == "Q")
                {
                    run = false;
                }

                if (op == "M")
                {
                    // create and write to a file one pass.
                    program.CreateAndSaveFile(fileName);
                }
            }
        }

        /// <summary>
        /// Create the file and save the file.
        /// </summary>
        /// <param name="fileName"> file name. </param>
        public void CreateAndSaveFile(string fileName)
        {
            FileStream fs = new FileStream(fileName, FileMode.Create, FileAccess.Write); // the Create FileMode will overload the file.
            StreamWrite.WriteFile(fs);
            fs.Dispose();
        }
    }
}

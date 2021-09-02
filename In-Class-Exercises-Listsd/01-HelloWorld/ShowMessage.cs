using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace _01_HelloWorld
{
    public class ShowMessage
    {
        private string message;
        
        public ShowMessage()
        {
            this.message = null;
        }

        public ShowMessage(string message)
        {
            this.message = message;
            showMessage("Result: " + message);
        }

        public void showMessage(string message)
        {
            Console.WriteLine("Result: " + message);
        }

        public void writeMessage(string message)
        {
            string path = "C:\\Users\\boxiang\\Desktop\\Fall2021\\CPTS321\\cpts321-in-class-exercises\\In-Class-Exercises-Listsd";
            FileStream fs = new FileStream(path + "\\01-HelloWorld.txt", FileMode.Create);
            StreamWriter sw = new StreamWriter(fs);
            sw.Write(message);
            Console.WriteLine("Please check the file at this directory: " + path);
            sw.Flush();
            sw.Close();
            fs.Close();

        }
    }
}

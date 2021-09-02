using System;

namespace _01_HelloWorld
{
    public class Program
    {

        static ShowMessage sm;
        //Constructor
        public Program()
        {
            sm = new ShowMessage();
            while (true)
            {
                Console.WriteLine("Please enter the commands below: ");
                Console.WriteLine("1 = Show the pass by reference and pass by value scenario ");
                Console.WriteLine("2 = Show Hello World on the screen ");
                Console.WriteLine("3 = Write Hello in a file ");
                Console.WriteLine("4 = Adding two numbers in a Linked List");
                Console.WriteLine("0 = Quit");


                string command = Console.ReadLine();

                if (command == "0")
                {
                    return;
                }

                run(command);
                Console.WriteLine("");//new line

            }

        }

        private static void run(string c)
        {
            if (c == null)
            {
                Console.WriteLine("No Command Founded!");
            }
            switch (c)
            {
                case "1":
                    Console.WriteLine("case 1！");
                    break;
                case "2":
                    sm.showMessage("Hello World!");
                    break;
                case "3":
                    sm.writeMessage("Hello World");
                    break;
                case "4":
                    Console.WriteLine("!");
                    break;
                default:
                    Console.WriteLine("Invalid Command!");
                    break;
            }
        }

        static void Main(string[] args)
        {
            Program pg = new Program();
        }
    }
}

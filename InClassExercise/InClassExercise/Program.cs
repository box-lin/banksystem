using System;

namespace InClassExercise
{
    class Program
    {
        static void Main(string[] args)
        { 
            while (true)
            {
                Console.WriteLine("Please enter the commands below: ");
                Console.WriteLine("1 = Show the pass by reference and pass by value scenario ");
                Console.WriteLine("2 = Show Hello World on the screen ");
                Console.WriteLine("3 = Write Hello in a file ");
                Console.WriteLine("4 = Adding two numbers in a Linked List");
                Console.WriteLine("0 = Quit");

                string commands = Console.ReadLine();
                run(commands);
            }
        }
        //Constructor
        public Program()
        {
            
        }

        private static void run(string c)
        {
            if (c == null){
                Console.WriteLine("No Command Founded!");
            }
            switch (c)
            {
                case "0":
                    Console.WriteLine("quit");
                    break;
                case "1":
                    Console.WriteLine("case 1！");
                    break;
                case "2":
                    Console.WriteLine("case 2！");
                    break;
                case "3":
                    Console.WriteLine("case 3！");
                    break;
                case "4":
                    Console.WriteLine("case 4！");
                    break;

            }
               

        }
    }
}

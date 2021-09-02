using System;

namespace _01_HelloWorld
{
    public class Program
    {

        private ShowMessage sm;
        private LinkedList list;
        //Constructor
        public Program()
        {
            this.sm = new ShowMessage();
            this.list = new LinkedList();
            
            while (true)
            {
                
                Console.WriteLine("Please enter the commands below: ");
                Console.WriteLine("1 = Show the pass by reference and pass by value scenario ");
                Console.WriteLine("2 = Show Hello World on the screen ");
                Console.WriteLine("3 = Write Hello in a file ");
                Console.WriteLine("4 = Adding two numbers in a Linked List");
                Console.WriteLine("0 = Quit");
                Console.Write("Please Enter The Command (0-4): ");

                string command = Console.ReadLine();

                if (command == "0")
                {
                    return;
                }

                run(command);
                Console.WriteLine("");//new line

            }

        }

        private void run(string c)
        {
            if (c == null)
            {
                Console.WriteLine("No Command Founded!");
                return;
            }
            switch (c)
            {
                case "1":
                    Console.WriteLine("<<<<<<<< Class >>>>>>>>>>>  Initially, angle1 degree = 180.");
                    Angle angle1 = new Angle();
                    angle1.angleDegree = 180;
                    Angle angle2 = angle1;
                    Console.WriteLine("<<<<<<<< Class >>>>>>>>>>>  angle2 = angle 1 (reference address copy)");
                    angle2.angleDegree = 360;
                    Console.WriteLine("<<<<<<<< Class >>>>>>>>>>>  angle2 degree = 360");
                    Console.WriteLine("<<<<<<<< Class >>>>>>>>>>>  Now the info of angle 1 and algle 2 as below: ");
                    angle1.showInfo("angle1");
                    angle2.showInfo("angle2");
                    Console.WriteLine("<<<<<<<< Class >>>>>>>>>>>  Now both angle 1 and angle 2 composes the same angle degree = 360, they referenced the same address");

                    Console.WriteLine();
                    Console.WriteLine("<<<<<<<< Struct >>>>>>>>>>>  Initially, angleS1 degree = 180.");
                    AngleStruc angleS1 = new AngleStruc();
                    angleS1.angleDegree = 180;
                    Console.WriteLine("<<<<<<<< Struct >>>>>>>>>>> angleS2 = angleS1 (deep copy, angleS2 has its own memory address now ");
                    AngleStruc angleS2 = angleS1;
                    Console.WriteLine("<<<<<<<< Struct >>>>>>>>>>> angleS2 degree = 360");
                    angleS2.angleDegree = 360;
                    Console.WriteLine("<<<<<<<< Struct >>>>>>>>>>>  Now the info of angleS 1 and algleS 2 as below: ");
                    angleS1.showInfo("angleS1");
                    angleS2.showInfo("angleS2");
                    Console.WriteLine("<<<<<<<< Struct >>>>>>>>>>> angleS1 degree = 180, angleS2 = 360, they are independent");
                    break;
                case "2":
                    this.sm.showMessage("Hello World!");
                    break;
                case "3":
                    this.sm.writeMessage("Hello World");
                    break;
                case "4":
                    Console.Write("Please Type in the 1st number: ");
                    string num1 = Console.ReadLine();
                    Console.Write("Please Type in the 2nd number: ");
                    string num2 = Console.ReadLine();
                    this.list.add(int.Parse(num1));
                    this.list.add(int.Parse(num2));
                    Console.WriteLine("The numbers have been added to the LinkedList: " + list);
                    break;
                default:
                    Console.WriteLine("Invalid Command!");
                    break;
            }
        }
        static void Main(string[] args)
        {
            new Program();
        }
    }
}

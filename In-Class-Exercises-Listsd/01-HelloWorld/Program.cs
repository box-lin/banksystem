using System;

namespace _01_HelloWorld
{
    public class Program
    {

        private BasicMessageClass sm;
        private LinkedList list;
        

        public Program()
        {
            this.sm = new BasicMessageClass();
            this.list = new LinkedList();
            
            while (true)
            {
                showMenu();
                string command = Console.ReadLine();

                //If enter 0, application terminated.
                if (command == "0")
                {
                    return;
                }

                run(command);//run and get result
                Console.WriteLine("");//new line after each result
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
                    referenceVsValue();
                    break;
                case "2":
                    showMessage();
                    break;
                case "3":
                    writeMessage();
                    break;
                case "4":
                    linkedListOperation();
                    break;
                default:
                    Console.WriteLine("Invalid Command!");
                    break;
            }
        }

        private void showMenu()
        {
            Console.WriteLine("C# Demo: ");
            Console.WriteLine("1 = Show the pass by reference and pass by value scenario ");
            Console.WriteLine("2 = Show Hello World on the screen ");
            Console.WriteLine("3 = Write Hello in a file ");
            Console.WriteLine("4 = Adding two numbers in a Linked List");
            Console.WriteLine("0 = Quit");
            Console.Write("Please Enter The Command (0-4): ");
        }


        private void referenceVsValue()
        {
            Console.WriteLine("<<<<<<<< Class >>>>>>>>>>>  Initially, angle1 degree = 180.");
            AngleClass angleClass1 = new AngleClass();
            angleClass1.angleDegree = 180;
            AngleClass angleClass2 = angleClass1;
            Console.WriteLine("<<<<<<<< Class >>>>>>>>>>>  angle2 = angle 1 (reference address copy)");
            angleClass2.angleDegree = 360;
            Console.WriteLine("<<<<<<<< Class >>>>>>>>>>>  angle2 degree = 360");
            Console.WriteLine("<<<<<<<< Class >>>>>>>>>>>  Now the info of angle 1 and algle 2 as below: ");
            angleClass1.showInfo("angle1");
            angleClass2.showInfo("angle2");
            Console.WriteLine("<<<<<<<< Class >>>>>>>>>>>  Now both angle 1 and angle 2 composes the same angle degree = 360, they referenced the same address");

            Console.WriteLine();
            Console.WriteLine("<<<<<<<< Struct >>>>>>>>>>>  Initially, angleS1 degree = 180.");
            AngleStruc angleStruct1 = new AngleStruc();
            angleStruct1.angleDegree = 180;
            Console.WriteLine("<<<<<<<< Struct >>>>>>>>>>> angleS2 = angleS1 (deep copy, angleS2 has its own memory address now ");
            AngleStruc angleS2 = angleStruct1;
            Console.WriteLine("<<<<<<<< Struct >>>>>>>>>>> angleS2 degree = 360");
            angleS2.angleDegree = 360;
            Console.WriteLine("<<<<<<<< Struct >>>>>>>>>>>  Now the info of angleS 1 and algleS 2 as below: ");
            angleStruct1.showInfo("angleS1");
            angleS2.showInfo("angleS2");
            Console.WriteLine("<<<<<<<< Struct >>>>>>>>>>> angleS1 degree = 180, angleS2 = 360, they are independent");
        }

        private void showMessage()
        {
            this.sm.showMessage("Hello World!");
        }

        private void writeMessage()
        {
            this.sm.writeMessage("Hello World");
        }

        private void linkedListOperation()
        {
            Console.Write("Please Type in the 1st number: ");
            string num1 = Console.ReadLine();
            Console.Write("Please Type in the 2nd number: ");
            string num2 = Console.ReadLine();
            this.list.add(int.Parse(num1));
            this.list.add(int.Parse(num2));
            Console.WriteLine("The numbers have been added to the LinkedList: " + list);
        }

        static void Main(string[] args)
        {
            new Program();
        }
    }
}

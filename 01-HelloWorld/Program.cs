/// <summary>
/// 
/// Name: Boxiang Lin 
/// ID: 011601661
/// In-Class Exercise 1
/// 
/// </summary>


using System;
namespace _01_HelloWorld
{
    public class Program
    {

        public Program()
        {
            
            //Keep showing menu until "0" command
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

                Console.WriteLine();
                Console.WriteLine("Continue? Please any key! ");
                Console.ReadKey();

                Console.WriteLine();
            }

        }

        /// <summary>
        /// We will determine which command pass in and distribute specific task for each command.
        /// Using switch to filter commands.
        /// </summary>
        /// <param name="c"></param>
        private void run(string c)
        {
            if (c == null)
            {
                Console.WriteLine("No Command Founded!");
                return;
            }
            Console.WriteLine();  
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


        /// <summary>
        /// Console print the menu options
        /// </summary>
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

        /// <summary>
        /// Scenario that show different between (pass by reference) vs (pass by value)
        /// </summary>
        private void referenceVsValue()
        {
            Console.WriteLine("<<<<<<<< Class >>>>>>>>>>>  angleClass1 instance created.");
            AngleClass angleClass1 = new AngleClass();
            Console.WriteLine("<<<<<<<< Class >>>>>>>>>>>  angleClass1 set angleDegree 180, see info: ");
            angleClass1.angleDegree = 180;
            angleClass1.showInfo("angleClass1");
             
            Console.WriteLine("<<<<<<<< Class >>>>>>>>>>>  Now angleClass2 instance created and set angleClass2 = angleClass1 (reference stack address copy)");
            AngleClass angleClass2 = angleClass1;
            Console.WriteLine("<<<<<<<< Class >>>>>>>>>>>  angleClass2 set angleDegree 360, see info: ");
            angleClass2.angleDegree = 360;
            angleClass2.showInfo("angleClass2");
            
            Console.WriteLine("<<<<<<<< Class >>>>>>>>>>>  Now lets angleClass1 and angleClass2, see their info: ");
            angleClass1.showInfo("angle1Class");
            angleClass2.showInfo("angle2Class");
            Console.WriteLine("<<<<<<<< Class >>>>>>>>>>>  Both angle 1 and angle 2 composes the same angle degree = 360 and corresponding radian because they referenced the same address");

            Console.WriteLine("------------------------------------------------------------------------------------------------------------------------------------------------------");

            Console.WriteLine("<<<<<<<< Struct >>>>>>>>>>>  angleStruct1 created.");
            AngleStruc angleStruct1 = new AngleStruc();
            Console.WriteLine("<<<<<<<< Struct >>>>>>>>>>>  angleStruct1 set angleDegree 180, see info: ");
            angleStruct1.angleDegree = 180;
            angleStruct1.showInfo("angleStruct1");

            Console.WriteLine("<<<<<<<< Struct >>>>>>>>>>>  angleStruct2 = angleStruct1 (deep copy, angleS2 has its own memory address now, they stored in heap ");
            AngleStruc angleStruct2 = angleStruct1;
            Console.WriteLine("<<<<<<<< Struct >>>>>>>>>>>  angleStruct2 set angleDegree = 360, see info: ");
            angleStruct2.angleDegree = 360;
            angleStruct2.showInfo("angleStruct2");

            Console.WriteLine("<<<<<<<< Struct >>>>>>>>>>>  Now lets compare angleStruct1 and angleStruct2, see their info: ");
            angleStruct1.showInfo("angleStruct1");
            angleStruct2.showInfo("angleStruct2");
            Console.WriteLine("<<<<<<<< Struct >>>>>>>>>>>  angleS1 degree = 180, angleS2 = 360, we conclude they are independent and is pass by value");
        }

        /// <summary>
        /// Show message to the console
        /// </summary>
        private void showMessage()
        {
            BasicMessageClass message = new BasicMessageClass("Hello World! ");
            message.showMessage(Console.Out);
        }

        /// <summary>
        /// Write message to a txt file
        /// </summary>
        private void writeMessage()
        {
            var file = "HelloWorld.txt";
            BasicMessageClass message = new BasicMessageClass("Hello World!");
            using (System.IO.StreamWriter sw = new System.IO.StreamWriter(file))
            {
                message.showMessage(sw);
            }
            Console.WriteLine("Wrote in file {0}", file);
        }


        /// <summary>
        /// LinkedList Operations
        /// </summary>
        private void linkedListOperation()
        {
            Console.Write("Please Type in the 1st number: ");
            string num1 = Console.ReadLine();
            Console.Write("Please Type in the 2nd number: ");
            string num2 = Console.ReadLine();
            LinkedList list = new LinkedList();
            list.add(int.Parse(num1));
            list.add(int.Parse(num2));
            Console.WriteLine("The numbers have been added to the LinkedList: " + list);

        }


        /// <summary>
        /// Program Start!
        /// </summary>
        static void Main(string[] args)
        {
            new Program();
        }
    }
}

// CptS 321: Expression Tree Code Demo of how NOT to code your assignements
// Problems and sollutions of this code will be discussed in class
// Note that if you sumbit this code you will not get ANY points for the assignments

using System;

namespace ExpressionTreeCodeDemo
{
	class MainClass
	{
		public static void Main(string[] args)
		{

            while (true)
            {
                Console.Write("Enter expression: ");
                string line = Console.ReadLine();
                Expression exp = new Expression(line);
                Console.WriteLine(exp.Evaluate().ToString());

                Console.ReadKey();
            }
		}
	}
}

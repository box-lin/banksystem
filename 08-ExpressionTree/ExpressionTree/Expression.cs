// CptS 321: Expression Tree Code Demo of how NOT to code your assignements
// Problems and sollutions of this code will be discussed in class
// Note that if you sumbit this code you will not get ANY points for the assignments

using System;
using System.Collections.Generic;

namespace ExpressionTreeCodeDemo
{
	public class Expression
	{
		private abstract class Node
		{

		}

		private class ConstantNode : Node
		{
			public double Value { get; set; }
        }

		private class VariableNode : Node
		{
			public string Name { get; set; }
        }

		private class OperatorNode : Node
		{
			public OperatorNode(char c)
            {
                Operator = c;
                Left = Right = null;
            }
            
            public char Operator { get; set; }

            public Node Left { get; set; }
            public Node Right { get; set; }
    }

		private Node root;

		private Dictionary<string, double> variables = new Dictionary<string, double>();

		/// <summary>
		/// Initializes a new instance of the <see cref="ExpressionTreeCodeDemo.Expression"/> class.
		/// </summary>
		public Expression(string expression)
		{
			root = Compile(expression);
		}

		private static Node Compile(string s)
		{
			if (string.IsNullOrEmpty(s))
            {
                return null;
            }

            // Check for extra parentheses and get rid of them, e.g. (((((2+3)-(4+5)))))
            if ('(' == s[0])
            {
                int parenthesisCounter = 1;
                for (int characterIndex = 1; characterIndex < s.Length; characterIndex++)
                {
                    // if open parenthisis increment a counter
                    if ('(' == s[characterIndex])
                    {
                        parenthesisCounter++;
                    }
                    // if closed parenthisis decrement the counter
                    else if (')' == s[characterIndex])
                    {
                        parenthesisCounter--;
                        // if the counter is 0 check where we are
                        if (0 == parenthesisCounter)
                        {
                            if (characterIndex != s.Length - 1)
                            {
                                // if we are not at the end, then get out (there are no extra parentheses)
                                break;
                            }
                            else
                            {
                                // Else get rid of the outer most parentheses and start over
                                return Compile(s.Substring(1, s.Length - 2));
                            }
                        }
                    }
                }
            }
            
            // define the operators we want to look for in that order
            char[] operators = { '+', '-', '*', '/', '^' };
            foreach (char op in operators)
            {
                Node n = Compile(s, op);
                if (n != null) return n;
            }

            // what can we see here?  
            double number;
            // a constant
            if (double.TryParse(s, out number))
            {
                // We need a ConstantNode
                return new ConstantNode()
                {
                    Value = number
                };
            }
            // or variable
            else
            {
                // We need a VariableNode
                return new VariableNode()
                {
                    Name = s
                };
            }
		}

        private static Node Compile(string expression, char op)
        {
            // track the parentheses
            int parenthesisCounter = 0;
            // iterate from back to front
            for (int expressionIndex = expression.Length - 1; expressionIndex >= 0; expressionIndex--)
            {
                // if closed parenthisis INcrement the counter
                if (')' == expression[expressionIndex])
                {
                    parenthesisCounter++;
                }
                // if open parenthisis DEcrement the counter
                else if ('(' == expression[expressionIndex])
                {
                    parenthesisCounter--;
                }
                // if the counter is at 0 and we have the operator that we are looking for
                if (0 == parenthesisCounter && op == expression[expressionIndex])
                {
                    // build an operator node
                    OperatorNode operatorNode = new OperatorNode(expression[expressionIndex]);
                    // and start over with the left and right sub-expressions
                    operatorNode.Left = Compile(expression.Substring(0, expressionIndex));
                    operatorNode.Right = Compile(expression.Substring(expressionIndex + 1));
                    return operatorNode;
                }
            }

            // if the counter is not at 0 something was off
            if (parenthesisCounter != 0)
            {
                // throw a general exception
                throw new Exception();
            }
            // we did not find the operator
            return null;
        }

		// Precondition: n is non-null
		private double Evaluate(Node node)
		{
            // try to evaluate the node as a constant
            // the "as" operator is evaluated to null 
            // as opposed to throwing an exception
            ConstantNode constantNode = node as ConstantNode;
			if (null != constantNode)
			{
				return constantNode.Value;
			}
            
            // as a variable
            VariableNode variableNode = node as VariableNode;
			if (null != variableNode)
			{
				return variables[variableNode.Name];
			}

			// it is an operator node if we came here
			OperatorNode operatorNode = node as OperatorNode;
			if (null != operatorNode)
			{
                // but which one?
				switch (operatorNode.Operator)
				{
				case '+':
					return Evaluate(operatorNode.Left) + Evaluate(operatorNode.Right);
                case '-':
                    return Evaluate(operatorNode.Left) - Evaluate(operatorNode.Right);
                case '*':
                    return Evaluate(operatorNode.Left) * Evaluate(operatorNode.Right);
                case '/':
                    return Evaluate(operatorNode.Left) / Evaluate(operatorNode.Right);
                case '^':
                    return Math.Pow(Evaluate(operatorNode.Left), Evaluate(operatorNode.Right));
				default: // if it is not any of the operators that we support, throw an exception:
                    throw new NotSupportedException(
                        "Operator " + operatorNode.Operator.ToString() + " not supported.");
				}
			}

			throw new NotSupportedException();
		}

        public double Evaluate()
        {
            return Evaluate(root);
        }

        public void SetVariable(string name, double value)
        {
            variables[name] = value;
        }
	}
}


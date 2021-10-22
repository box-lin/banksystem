// <copyright file="ExpressionTree.cs" company="Boxiang Lin - WSU 011601661">
// Copyright (c) Boxiang Lin - WSU 011601661. All rights reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.Linq;

namespace CptS321
{
    /// <summary>
    /// ExpressionTree class.
    /// </summary>
    public class ExpressionTree
    {
        private Node root;
        private Dictionary<string, double> variables;
        private OpNodeFactory factory;

        /// <summary>
        /// Initializes a new instance of the <see cref="ExpressionTree"/> class.
        /// </summary>
        /// <param name="expression"> input expression. </param>
        public ExpressionTree(string expression)
        {
            this.variables = new Dictionary<string, double>();
            this.factory = new OpNodeFactory();
            this.root = this.BuildExpTree(expression);
        }

        /// <summary>
        /// Evaluate the expression.
        /// </summary>
        /// <returns> result. </returns>
        public double Evaluate()
        {
            return this.root.Evaluate();
        }

        /// <summary>
        /// Sets the specific variable within the ExpressionTree variable dictionary.
        /// </summary>
        /// <param name="variableName"> Variables key. </param>
        /// <param name="variableValue"> Variables val. </param>
        public void SetVariable(string variableName, double variableValue)
        {
            this.variables[variableName] = variableValue;
        }

        /// <summary>
        /// Builds an expression tree from expression string.
        /// Returns the root node of the expression tree.
        /// </summary>
        /// <param name="expression">Expression string.</param>
        /// <returns>Root of built expression tree.</returns>
        private Node BuildExpTree(string expression)
        {
            var postfixList = this.GetPostfixList(expression);
            Stack<Node> stack = new Stack<Node>();

            // Read the elements in post fix order.
            foreach (var item in postfixList)
            {
                // if the element is length 1, since (,) are not include in postlist, check if it is a op.
                if (item.Length == 1 && this.IsParenthesisOrOp(item[0]))
                {
                    // create the op node.
                    OpNode node = this.factory.CreateOperatorNode(item[0]);
                    node.Right = stack.Pop();
                    node.Left = stack.Pop();

                    // node has its right and left childeren setup, prepare for another pop.
                    stack.Push(node);
                }
                else
                {
                    // not a op, prepare them into the stack, when later encounter op, pop two each time for op's left and right node.
                    double num = 0.0;
                    if (double.TryParse(item, out num))
                    {
                        stack.Push(new ConstantNode(num));
                    }
                    else
                    {
                        stack.Push(new VariableNode(item, ref this.variables));
                    }
                }
            }

            return stack.Pop();
        }

        /// <summary>
        /// Using Dijkstra's Shunting Yard algorithm to compute the Post Fix String List.
        /// </summary>
        /// <param name="expression"> An infix string expression. </param>
        /// <returns> Post fix string list.</returns>
        private List<string> GetPostfixList(string expression)
        {
            Stack<char> stack = new Stack<char>();
            List<string> postfixList = new List<string>();

            // loops over each char in expression string
            for (int i = 0; i < expression.Length; i++)
            {
                char c = expression[i];
                if (c.Equals('('))
                {
                    stack.Push(c);
                }
                else if (c.Equals(')'))
                {
                    // while the top of the stack is not a left parenthesis, pop and add to list
                    while (!stack.Peek().Equals('('))
                    {
                        postfixList.Add(stack.Pop().ToString());
                    }

                    stack.Pop(); // pop the left parenthesis from the top of the stack
                }

                // If the current char is a valid operator
                else if (this.factory.IsOperator(c))
                {
                    // if the stack is empty or the next char is a left parenthesis
                    if (stack.Count == 0 || stack.Peek().Equals('('))
                    {
                        stack.Push(c);
                    }
                    else if (this.IsHigherPrecedence(c, stack.Peek()) ||
                               (this.IsSamePrecedence(c, stack.Peek()) && this.IsRightAssociative(c)))
                    {
                        stack.Push(c);
                    }
                    else if (this.IsLowerPrecedence(c, stack.Peek()) ||
                        (this.IsSamePrecedence(c, stack.Peek()) && this.IsLeftAssociative(c)))
                    {
                        // Stack not empty && Stack peek is a operator && the c and stack peek precedence check.
                        while (stack.Count > 0 && this.factory.IsOperator(stack.Peek())
                            && (this.IsLowerPrecedence(c, stack.Peek()) || (this.IsSamePrecedence(c, stack.Peek()) && this.IsLeftAssociative(c))))
                        {
                            char op = stack.Pop();
                            postfixList.Add(op.ToString());
                        }

                        stack.Push(c);
                    }
                }

                // if the current c begins with digits, it is a constant number.
                else if (char.IsDigit(c))
                {
                    string constant = c.ToString();

                    // we have to loop throup all consecutive constant number.
                    for (int j = i + 1; j < expression.Length; j++)
                    {
                        if (char.IsDigit(expression[j]))
                        {
                            constant += expression[j].ToString();

                            // update the i counter as well since we have ealier process some consecutive constants.
                            i++;
                        }
                        else
                        {
                            break;
                        }
                    }

                    postfixList.Add(constant);
                }

                // Not a (, ), op, and constant, then it should be the variable.
                else
                {
                    string variable = c.ToString();
                    for (int j = i + 1; j < expression.Length; j++)
                    {
                        // check again not a (, ), or op, then it is part of variable.
                        if (!this.IsParenthesisOrOp(expression[j]))
                        {
                            variable += expression[j].ToString();
                            i++;
                        }
                        else
                        {
                            break;
                        }
                    }

                    postfixList.Add(variable);
                }
            }

            // We add the rest of the operator into a postFixList.
            while (stack.Count > 0)
            {
                postfixList.Add(stack.Pop().ToString());
            }

            return postfixList;
        }

        /// <summary>
        /// Check if the char is part of parenthesis or operator.
        /// </summary>
        /// <param name="c"> char c. </param>
        /// <returns> true or false. </returns>
        private bool IsParenthesisOrOp(char c)
        {
            if (c.Equals('(') || c.Equals(')') || this.factory.IsOperator(c))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Check if x precedance higher than y.
        /// </summary>
        /// <param name="cur"> char cur. </param>
        /// <param name="topOp"> char topOp. </param>
        /// <returns> True or False. </returns>
        private bool IsHigherPrecedence(char cur, char topOp)
        {
            if (this.factory.GetPrecedance(cur) < this.factory.GetPrecedance(topOp))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Check if x precedance same as y.
        /// </summary>
        /// <param name="cur"> char cur. </param>
        /// <param name="topOp"> char topOp. </param>
        /// <returns> True or False. </returns>
        private bool IsSamePrecedence(char cur, char topOp)
        {
            if (this.factory.GetPrecedance(cur) == this.factory.GetPrecedance(topOp))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Check if x precedance lower than y.
        /// </summary>
        /// <param name="cur"> char cur. </param>
        /// <param name="topOp"> char topOp. </param>
        /// <returns> True or False. </returns>
        private bool IsLowerPrecedence(char cur, char topOp)
        {
            if (this.factory.GetPrecedance(cur) > this.factory.GetPrecedance(topOp))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Check if x is associtive left.
        /// </summary>
        /// <param name="cur"> char cur. </param>
        /// <returns>True or False.  </returns>
        private bool IsLeftAssociative(char cur)
        {
            if (this.factory.GetAssociativity(cur) == OpNode.Associative.Left)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Check if x is associtive left.
        /// </summary>
        /// <param name="cur"> char cur. </param>
        /// <returns>True or False.  </returns>
        private bool IsRightAssociative(char cur)
        {
            if (this.factory.GetAssociativity(cur) == OpNode.Associative.Right)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}

// <copyright file="TestExpressionTree.cs" company="Boxiang Lin - WSU 011601661">
// Copyright (c) Boxiang Lin - WSU 011601661. All rights reserved.
// </copyright>
using CptS321;
using NUnit.Framework;

namespace CptS321.Tests
{
    /// <summary>
    /// Class to test the Expression Tree.
    /// </summary>
    [TestFixture]
    public class TestExpressionTree
    {
        /// <summary>
        /// Test expression by add operation.
        /// </summary>
        /// <param name="expression"> expression to be evaluate. </param>
        /// <returns> result. </returns>
        [Test]
        [TestCase("3+5", ExpectedResult = 8.0)]
        [TestCase("3+5+10", ExpectedResult = 18.0)]
        [TestCase("0+0", ExpectedResult = 0.0)]
        public double TestEvaluateAdd(string expression)
        {
            ExpressionTree exp = new ExpressionTree(expression);
            return exp.Evaluate();
        }

        /// <summary>
        /// Test expression by subtract operation.
        /// </summary>
        /// <param name="expression"> expression to be evaluate. </param>
        /// <returns> result. </returns>
        [Test]
        [TestCase("50-5", ExpectedResult = 45.0)]
        [TestCase("50-5-10", ExpectedResult = 35.0)]
        [TestCase("0-0", ExpectedResult = 0.0)]
        public double TestEvaluateSub(string expression)
        {
            ExpressionTree exp = new ExpressionTree(expression);
            return exp.Evaluate();
        }

        /// <summary>
        /// Test expression by multiply operation.
        /// </summary>
        /// <param name="expression"> expression to be evaluate. </param>
        /// <returns> result. </returns>
        [Test]
        [TestCase("20*5", ExpectedResult = 100.0)]
        [TestCase("20*5*2", ExpectedResult = 200.0)]
        [TestCase("0*0", ExpectedResult = 0.0)]
        public double TestEvaluateMul(string expression)
        {
            ExpressionTree exp = new ExpressionTree(expression);
            return exp.Evaluate();
        }

        /// <summary>
        /// Test expression by divide operation.
        /// </summary>
        /// <param name="expression"> expression to be evaluate. </param>
        /// <returns> result. </returns>
        [Test]
        [TestCase("20/5", ExpectedResult = 4.0)]
        [TestCase("20/5/2", ExpectedResult = 2.0)]
        [TestCase("5/0", ExpectedResult = double.PositiveInfinity)]
        public double TestEvaluateDiv(string expression)
        {
            ExpressionTree exp = new ExpressionTree(expression);
            return exp.Evaluate();
        }

        /// <summary>
        /// Test the Set Variable with a constant.
        /// </summary>
        [Test]
        public void SetVariableTest()
        {
            string variable = "A5";
            double constant = 99.5;
            ExpressionTree exp = new ExpressionTree(variable);
            exp.SetVariable(variable, constant);
            Assert.AreEqual(exp.Evaluate(), constant);
        }

        /// <summary>
        /// Test the Set Variable default value that assign to a variable.
        /// </summary>
        [Test]
        public void SetVariableDefaultTest()
        {
            string variable = "B9";
            ExpressionTree exp = new ExpressionTree(variable);
            Assert.AreEqual(exp.Evaluate(), 0.0);
        }

        /// <summary>
        /// Test to set multiple variables.
        /// </summary>
        /// <param name="expression"> string expression. </param>
        [TestCase("A5+C9+D5")]
        public void SetVariableMultiple(string expression)
        {
            ExpressionTree exp = new ExpressionTree(expression);
            exp.SetVariable("A5", 5);
            exp.SetVariable("C9", 2);
            exp.SetVariable("D5", 3);
            Assert.AreEqual(exp.Evaluate(), 10);
        }

        /// <summary>
        /// Test the precedance between operators.
        /// </summary>
        /// <param name="expression"> expression. </param>
        /// <returns> evaluated result. </returns>
        [Test]
        [TestCase("5+20*5", ExpectedResult = 105)]
        [TestCase("5-20/10", ExpectedResult = 3)]
        [TestCase("10*5+2*3", ExpectedResult = 56)]
        [TestCase("1+2+3+4*2+5+6/2-3+2+9*1*2", ExpectedResult = 39)]
        public double TestPrecedanceOperation(string expression)
        {
            ExpressionTree exp = new ExpressionTree(expression);
            return exp.Evaluate();
        }

        /// <summary>
        /// Test the precedance for parenthesis.
        /// </summary>
        /// <param name="expression"> expression. </param>
        /// <returns> evaluated result. </returns>
        [Test]
        [TestCase("5*(2+3)+2", ExpectedResult = 27)]
        [TestCase("((((3))))", ExpectedResult = 3)]
        [TestCase("(7+2-1+1)*2", ExpectedResult = 18)]
        [TestCase("(7+2-1+1*5+1)*(2+3)*2", ExpectedResult = 140)]
        [TestCase("(7+2-1+1*5+1)*(2+3)*(9-2+2/2-3*1)", ExpectedResult = 350)]
        public double TestParenthesisOperation(string expression)
        {
            ExpressionTree exp = new ExpressionTree(expression);
            return exp.Evaluate();
        }

        /// <summary>
        /// Test the precedance operation with variables involved.
        /// </summary>
        /// <param name="expression"> expression. </param>
        /// <returns> evaluated result. </returns>
        [Test]
        [TestCase("A1+B2+C3+D4*2+E5+A2/2-A3+2+A4*1*2", ExpectedResult = 39)]
        public double TestPrecedanceOperationWithVariables(string expression)
        {
            ExpressionTree exp = new ExpressionTree(expression);
            exp.SetVariable("A1", 1);
            exp.SetVariable("B2", 2);
            exp.SetVariable("C3", 3);
            exp.SetVariable("D4", 4);
            exp.SetVariable("E5", 5);
            exp.SetVariable("A2", 6);
            exp.SetVariable("A3", 3);
            exp.SetVariable("A4", 9);
            return exp.Evaluate();
        }

        /// <summary>
        /// Test the parenthesis and precedance operation with variables involved.
        /// </summary>
        /// <param name="expression"> expression. </param>
        /// <returns> evaluated result. </returns>
        [Test]
        [TestCase("(7+2-1+1*A1+1)*(B2+C3)*(9-2+E5/2-D4*1)", ExpectedResult = 350)]
        [TestCase("A1*(B2+C3)+(E5/B2)+D4", ExpectedResult = 29)]
        public double TestParenthesisOperationWithVarriables(string expression)
        {
            ExpressionTree exp = new ExpressionTree(expression);
            exp.SetVariable("A1", 5);
            exp.SetVariable("B2", 2);
            exp.SetVariable("C3", 3);
            exp.SetVariable("D4", 3);
            exp.SetVariable("E5", 2);
            return exp.Evaluate();
        }
    }
}

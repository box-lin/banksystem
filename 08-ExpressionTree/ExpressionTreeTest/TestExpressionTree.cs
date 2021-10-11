// NUnit 3 tests
// See documentation : https://github.com/nunit/docs/wiki/NUnit-Documentation
using NUnit.Framework;
using ExpressionTreeCodeDemo;
using System.Collections;
using System.Collections.Generic;

namespace ExpressionTreeTest
{
    [TestFixture]
    public class TestExpressionTree
    {
        Expression exp;

        [Test]
        public void TestAdd()
        {
            exp = new Expression("5+3");
            Assert.AreEqual("8", exp.Evaluate().ToString());

            exp = new Expression("(-3)+(-5)");
            Assert.AreEqual("-8", exp.Evaluate().ToString());

        }

        [Test]
        public void TestSubtract()
        {
            exp = new Expression("5-3");
            Assert.AreEqual("2", exp.Evaluate().ToString());

            exp = new Expression("(-3)-(-5)");
            Assert.AreEqual("2", exp.Evaluate().ToString());

        }

        [Test]
        public void TestMulitply()
        {
            exp = new Expression("5*3");
            Assert.AreEqual("15", exp.Evaluate().ToString());

            exp = new Expression("(-3)*(-5)");
            Assert.AreEqual("15", exp.Evaluate().ToString());

        }

        [Test]
        public void TestDivide()
        {
            exp = new Expression("10/2");
            Assert.AreEqual("5", exp.Evaluate().ToString());

            exp = new Expression("5/2");
            Assert.AreEqual("2.5", exp.Evaluate().ToString());

            exp = new Expression("(-5)/2");
            Assert.AreEqual("-2.5", exp.Evaluate().ToString());

        }

        [Test]
        public void TestExponent()
        {
            exp = new Expression("10^2");
            Assert.AreEqual("100", exp.Evaluate().ToString());

            exp = new Expression("(-5)^2");
            Assert.AreEqual("25", exp.Evaluate().ToString());

        }


        [Test]
        public void TestNestedParenthesis()
        {
            exp = new Expression("(((5)))+2");
            Assert.AreEqual("7", exp.Evaluate().ToString());

            exp = new Expression("(10)-((((2))))");
            Assert.AreEqual("8", exp.Evaluate().ToString());

        }





    }
}

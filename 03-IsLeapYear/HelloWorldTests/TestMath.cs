// NUnit 3 tests
// See documentation : https://github.com/nunit/docs/wiki/NUnit-Documentation
using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;


namespace HelloWorld.Math.Tests
{
    [TestFixture]
    public class TestMath
    {

        private Math math;

        [SetUp]
        public void SetUp()
        {
            math = new Math();
        }

        [Test]
        public void TestAdd()
        {

            //Test for Postive number 
            Assert.AreEqual(5, math.Add(2, 3));

            //Test for negative number
            Assert.AreEqual(-5, math.Add(-3, -2));

            //Test for postive and negative addition
            Assert.AreEqual(0, math.Add(-5, 5));

        }
    }
}

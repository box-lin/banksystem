// NUnit 3 tests
// See documentation : https://github.com/nunit/docs/wiki/NUnit-Documentation
using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using HelloWorld;

namespace HelloWorldTests
{
    [TestFixture]
    public class TestMath
    {   
        [Test]
        public void TestAdd()
        {

            // TODO: Add your test code here
            Assert.AreEqual(5, Math.Add(2, 3));
            Assert.AreEqual(5, Math.Add(1, 4));
            Assert.AreEqual(-5, Math.Add(0, -5));
            Assert.AreEqual(10, Math.Add(-10, 20));

        }
    }
}

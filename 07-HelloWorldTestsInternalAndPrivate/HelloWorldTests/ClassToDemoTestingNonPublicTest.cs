using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using HelloWorld;
using NUnit.Framework;
namespace HelloWorldTests
{
    class ClassToDemoTestingNonPublicTest
    {
        private ClassToDemoTestingNonPublic objectUnderTest = new ClassToDemoTestingNonPublic();

        private MethodInfo GetMethod(string methodName)
        {
            if (string.IsNullOrWhiteSpace(methodName))
            {
                Assert.Fail("methodNamecannot be null or whitespace");
            }

            var method = this.objectUnderTest.GetType().GetMethod(methodName, BindingFlags.NonPublic | BindingFlags.Static | BindingFlags.Instance);

            if (method == null) Assert.Fail(string.Format("{0} method not found", methodName));

            return method;
        }

        [Test]
        public void TestMyPrivateInstanceMethod()
        {
            MethodInfo methodInfo = this.GetMethod("privateInstanceMethod");

            Assert.AreEqual(5, methodInfo.Invoke(objectUnderTest, new object[] { 5 }));
            Assert.AreEqual(-5, methodInfo.Invoke(objectUnderTest, new object[] { -5 }));
        }
    }
}

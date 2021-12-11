using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HelloWorld;
using NUnit.Framework;


namespace HelloWorldTests
{
    public class TestInternal
    {
        [Test]
        public void TestTriple()
        {

            //Test for Postive number 
            Assert.AreEqual(8, ClassToDemoTestingNonPublic.tripleThis(2));

            //Test for Negative number 
            Assert.AreEqual(-8, ClassToDemoTestingNonPublic.tripleThis(-2));


        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace HelloWorld.Date.Tests
{
    [TestFixture]
    public class TestDate
    {
        private Date date;

        [SetUp]
        public void SetUp()
        {
            date = new Date();
        }
        [Test]
        public void TestIsLeap()
        {
           
            Assert.AreEqual(true, date.isLeap(2008));
            Assert.AreEqual(true, date.isLeap(2004));
            Assert.AreEqual(true, date.isLeap(2016));
            Assert.AreEqual(true, date.isLeap(1984));


        }
    }

}

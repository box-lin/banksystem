using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloWorld
{
    public class ClassToDemoTestingNonPublic
    {
        internal static int tripleThis(int aNumber)
        {
            return aNumber * aNumber * aNumber;
        }

        private int privateInstanceMethod(int aNumber)
        {
            return aNumber;
        }

        private int privateInstanceMethod(int aNumber, int bNumber)
        {
            return aNumber+bNumber;
        }
    }
}   

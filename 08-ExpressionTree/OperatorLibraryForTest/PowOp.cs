using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CptS321;

namespace OperatorLibrary_ForTests
{
    /// <summary>
    /// This class just served for test purpose.
    /// </summary>
    public class PowOp : OpNode
    {
        /// <summary>
        /// Operator symbol.
        /// </summary>
        public static char Operator => '^';
        //public static Associative Associativity => Associative.Right;
        //public static int Precedence => 2;

        /// <summary>
        /// Evaluate by Math.Pow for left and right substree.
        /// </summary>
        /// <returns></returns>
        public override double Evaluate()
        {
            return Math.Pow(Left.Evaluate(),Right.Evaluate());
        }
    }
}

// <copyright file="PlusOp.cs" company="Boxiang Lin - WSU 011601661">
// Copyright (c) Boxiang Lin - WSU 011601661. All rights reserved.
// </copyright>

namespace CptS321
{
    /// <summary>
    /// Plus operator class.
    /// </summary>
    public class PlusOp : OpNode
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PlusOp"/> class.
        /// </summary>
        public PlusOp()
        {
        }

        /// <summary>
        /// Gets the operator symbol.
        /// </summary>
        public static char Operator => '+';

        /// <summary>
        /// Gets the precedance level.
        /// </summary>
        public static int Precedence => 7;

        /// <summary>
        /// Gets the associativity.
        /// </summary>
        public static Associative Associativity => Associative.Left;

        /// <summary>
        /// Evaluate the plus operation from left and right substrees.
        /// </summary>
        /// <returns> Evaluated value. </returns>
        public override double Evaluate()
        {
            return this.Left.Evaluate() + this.Right.Evaluate();
        }
    }
}

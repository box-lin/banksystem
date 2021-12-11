// <copyright file="MulOp.cs" company="Boxiang Lin - WSU 011601661">
// Copyright (c) Boxiang Lin - WSU 011601661. All rights reserved.
// </copyright>

namespace CptS321
{
    /// <summary>
    /// Multiply operator class.
    /// </summary>
    public class MulOp : OpNode
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MulOp"/> class.
        /// </summary>
        public MulOp()
        {
        }

        /// <summary>
        /// Gets the operator symbol.
        /// </summary>
        public static char Operator => '*';

        /// <summary>
        /// Gets the precedance level.
        /// </summary>
        public static int Precedence => 6;

        /// <summary>
        /// Gets the associativity.
        /// </summary>
        public static Associative Associativity => Associative.Left;

        /// <summary>
        /// Evaluate the multiply operation from left and right substrees.
        /// </summary>
        /// <returns> Evaluated value. </returns>
        public override double Evaluate()
        {
            return this.Left.Evaluate() * this.Right.Evaluate();
        }
    }
}

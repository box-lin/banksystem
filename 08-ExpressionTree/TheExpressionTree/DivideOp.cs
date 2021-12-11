// <copyright file="DivideOp.cs" company="Boxiang Lin - WSU 011601661">
// Copyright (c) Boxiang Lin - WSU 011601661. All rights reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CptS321
{
    /// <summary>
    /// Divide operator class.
    /// </summary>
    public class DivideOp : OpNode
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DivideOp"/> class.
        /// </summary>
        public DivideOp()
        {
        }

        /// <summary>
        /// Gets operator symbol.
        /// </summary>
        public static char Operator => '/';

        /// <summary>
        /// Gets the precedance level.
        /// </summary>
        public static int Precedence => 6;

        /// <summary>
        /// Gets the Associtivity.
        /// </summary>
        public static Associative Associativity => Associative.Left;

        /// <summary>
        /// Evaluate the divide operation from left and right substrees.
        /// </summary>
        /// <returns> Evaluated value. </returns>
        public override double Evaluate()
        {
            return this.Left.Evaluate() / this.Right.Evaluate();
        }
    }
}

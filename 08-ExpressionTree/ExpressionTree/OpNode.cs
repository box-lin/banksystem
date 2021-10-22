// <copyright file="OpNode.cs" company="Boxiang Lin - WSU 011601661">
// Copyright (c) Boxiang Lin - WSU 011601661. All rights reserved.
// </copyright>

namespace CptS321
{
    /// <summary>
    /// Operator class.
    /// </summary>
    public abstract class OpNode : Node
    {
        /// <summary>
        /// Associativity of the operators.
        /// </summary>
        public enum Associative
        {
            /// <summary>
            /// Right associativity.
            /// </summary>
            Right,

            /// <summary>
            /// Left associativity.
            /// </summary>
            Left,
        }

        /// <summary>
        /// Gets or sets the left node.
        /// </summary>
        public Node Left { get; set; }

        /// <summary>
        /// Gets or sets the right node.
        /// </summary>
        public Node Right { get; set; }
    }
}

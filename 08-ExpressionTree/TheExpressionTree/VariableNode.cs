// <copyright file="VariableNode.cs" company="Boxiang Lin - WSU 011601661">
// Copyright (c) Boxiang Lin - WSU 011601661. All rights reserved.
// </copyright>

using System.Collections.Generic;

namespace CptS321
{
    /// <summary>
    /// VariableNode.
    /// </summary>
    public class VariableNode : Node
    {
        private readonly string name;

        private Dictionary<string, double> variables;

        /// <summary>
        /// Initializes a new instance of the <see cref="VariableNode"/> class.
        /// </summary>
        /// <param name="name"> name. </param>
        /// <param name="variables"> variable. </param>
        public VariableNode(string name, ref Dictionary<string, double> variables)
        {
            this.name = name;
            this.variables = variables;
        }

        /// <summary>
        /// Return the value from dictionary, if not found, return 0.0.
        /// </summary>
        /// <returns> 0.0 or the corresponding value from dictionary. </returns>
        public override double Evaluate()
        {
            double value = 0.0;
            if (this.variables.ContainsKey(this.name))
            {
                value = this.variables[this.name];
            }

            return value;
        }
    }
}

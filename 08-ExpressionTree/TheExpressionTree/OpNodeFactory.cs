// <copyright file="OpNodeFactory.cs" company="Boxiang Lin - WSU 011601661">
// Copyright (c) Boxiang Lin - WSU 011601661. All rights reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace CptS321
{
    /// <summary>
    /// OpNodeFactory class to dynamically instantiate operation classes.
    /// </summary>
    public class OpNodeFactory
    {
        /// <summary>
        /// Holds valid operators char and type.
        /// </summary>
        private Dictionary<char, Type> operators;

        /// <summary>
        /// Initializes a new instance of the <see cref="OpNodeFactory"/> class.
        /// </summary>
        public OpNodeFactory()
        {
            this.operators = new Dictionary<char, Type>();
            this.TraverseAvailableOperators((op, type) => this.operators.Add(op, type));
        }

        /// <summary>
        /// Delegate for operator char and type.
        /// </summary>
        /// <param name="op">Operater character.</param>
        /// <param name="type">Operator type.</param>
        private delegate void OnOperator(char op, Type type);

        /// <summary>
        /// Takes an operator char and returns coresponding operator node.
        /// Accepts all operators that are defined which inherit the OperatorNode class.
        /// </summary>
        /// <param name="op">Operator.</param>
        /// <returns>Operator node.</returns>
        public OpNode CreateOperatorNode(char op)
        {
            if (this.operators.ContainsKey(op))
            {
                object operatorNodeObject = System.Activator.CreateInstance(this.operators[op]);
                if (operatorNodeObject is OpNode)
                {
                    return (OpNode)operatorNodeObject;
                }
            }

            throw new NotSupportedException("Not Supported Operator");
        }

        /// <summary>
        /// Get the operators symbol.
        /// </summary>
        /// <returns> A list of operator symbol. </returns>
        public List<char> GetOperators()
        {
            return this.operators.Keys.ToList();
        }

        /// <summary>
        /// Get the precedance level for particular operator symbol.
        /// </summary>
        /// <param name="symbol"> char symbol. </param>
        /// <returns> return the Precedance level. </returns>
        public int GetPrecedance(char symbol)
        {
            if (!this.operators.ContainsKey(symbol))
            {
                throw new NotSupportedException("Not Supported Operator");
            }

            var type = this.operators[symbol];
            PropertyInfo operatorField = type.GetProperty("Precedence");
            if (operatorField != null)
            {
                object value = operatorField.GetValue(type);
                if (value is int)
                {
                    return (int)value;
                }
            }

            throw new Exception("No precedence property exist in this operator");
        }

        /// <summary>
        /// Get Associativity for the operator symbol.
        /// </summary>
        /// <param name="symbol"> operator symbol. </param>
        /// <returns> The associativity. </returns>
        public OpNode.Associative GetAssociativity(char symbol)
        {
            if (!this.operators.ContainsKey(symbol))
            {
                throw new NotSupportedException("Not Supported Operator");
            }

            var type = this.operators[symbol];
            PropertyInfo operatorField = type.GetProperty("Associativity");
            if (operatorField != null)
            {
                object value = operatorField.GetValue(type);
                if (value is OpNode.Associative)
                {
                    return (OpNode.Associative)value;
                }
            }

            throw new Exception("No Associativity property exist in this operator");
        }

        /// <summary>
        /// Returns if the operator is supported.
        /// </summary>
        /// <param name="op">Operator char.</param>
        /// <returns>Boolean.</returns>
        internal bool IsOperator(char op)
        {
            return this.operators.ContainsKey(op);
        }

        /// <summary>
        /// Traverses all assemblies for subclasses of OperatorNode
        /// and adds their Operator property and type to operators dictionary.
        /// </summary>
        /// <param name="onOperator">Delegate.</param>
        private void TraverseAvailableOperators(OnOperator onOperator)
        {
            Type operatorNodeType = typeof(OpNode);

            // Load outside assembly purpose.
            foreach (var assembly in AppDomain.CurrentDomain.GetAssemblies())
            {
                IEnumerable<Type> operatorTypes = assembly.GetTypes().Where(type => type.IsSubclassOf(operatorNodeType));

                foreach (var type in operatorTypes)
                {
                    PropertyInfo operatorField = type.GetProperty("Operator");

                    if (operatorField != null)
                    {
                        object value = operatorField.GetValue(type);

                        if (value is char)
                        {
                            char operatorSymbol = (char)value;
                            onOperator(operatorSymbol, type);
                        }
                    }
                }
            }
        }
    }
}

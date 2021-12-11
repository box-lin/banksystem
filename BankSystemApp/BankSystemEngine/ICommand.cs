// <copyright file="ICommand.cs" company="Boxiang Lin - WSU 011601661">
// Copyright (c) Boxiang Lin - WSU 011601661. All rights reserved.
// </copyright>

namespace BankSystemEngine
{
    /// <summary>
    /// Interface for the Undo/Redo generatic command.
    /// </summary>
    public interface ICommand
    {
        /// <summary>
        /// Execute the command.
        /// </summary>
        /// <returns> can execute or cannot. </returns>
        bool Execute();

        /// <summary>
        /// Unexecute the command.
        /// </summary>
        void Unexecute();
    }
}

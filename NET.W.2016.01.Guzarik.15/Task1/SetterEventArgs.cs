using System;

namespace Task1
{
    /// <summary>
    /// Class keeps iformation that transmits to subscribers
    /// </summary>
    public sealed class SetterEventArgs : EventArgs
    {
        /// <summary>
        /// Transmitted information
        /// </summary>
        public string Message { get; private set; }

        /// <summary>
        /// Receives the transmitted iformation
        /// </summary>
        public SetterEventArgs(string message)
        {
            Message = message;
        }
    }
}

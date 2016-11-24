using System;

namespace Task1
{
    /// <summary>
    /// Class generates event on changing index
    /// </summary>
    public class SetterSender
    {
        /// <summary>
        /// The member-event
        /// </summary>
        public event EventHandler<SetterEventArgs> IndexSetted = delegate { };
        
        /// <summary>
        /// Notifies subscribers of the event
        /// </summary>
        protected virtual void OnIndexSetted(object sender, SetterEventArgs e)
        {
            IndexSetted?.Invoke(sender, e);
        }

        /// <summary>
        /// Broadcasts input ifromation in the event
        /// </summary>
        public void Notify(string message)
        {
            OnIndexSetted(this, new SetterEventArgs(message));
        }
    }
}

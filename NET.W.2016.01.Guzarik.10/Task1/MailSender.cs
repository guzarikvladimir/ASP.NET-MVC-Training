using System;

namespace Task1
{
    /// <summary>
    /// Class generates event
    /// </summary>
    public class MailSender
    {
        /// <summary>
        /// The member-event
        /// </summary>
        public event EventHandler<MessageEventArgs> TimerRing = delegate { };

        /// <summary>
        /// Notifies subscribers of the event
        /// </summary>
        protected virtual void OnTimerTick(object sender, MessageEventArgs e)
        {
            TimerRing?.Invoke(sender, e);
        }

        /// <summary>
        /// Broadcasts input ifromation in the event
        /// </summary>
        public void Notify(string message)
        {
            OnTimerTick(this, new MessageEventArgs(message));
        }
    }
}

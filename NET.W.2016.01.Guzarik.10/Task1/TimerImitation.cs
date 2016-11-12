using System;
using System.Threading;

namespace Task1
{
    /// <summary>
    /// Class for setting delay on sending message
    /// </summary>
    public class TimerImitation
    {
        private int _delay;
        private readonly MailSender _mailSender;

        /// <summary>
        /// Constructor for setting class object generating event 
        /// </summary>
        public TimerImitation(MailSender sender)
        {
            _mailSender = sender;
        }

        /// <summary>
        /// Run timer
        /// </summary>
        public void Run(Action<int> action)
        {
            _mailSender.Notify($"Message was sended at {DateTime.Now.ToLongTimeString()}\n");
            for (var i = _delay; i > 0; i--)
            {
                action(i);
                Thread.Sleep(1000);
            }
            _mailSender.Notify($"Message was received at {DateTime.Now.ToLongTimeString()}\n");
        }

        /// <summary>
        /// Set delay after which the message will spread
        /// </summary>
        /// <param name="time">Timer delay in seconds</param>
        public void SetDelay(int time)
        {
            _delay = time;
        }
    }
}

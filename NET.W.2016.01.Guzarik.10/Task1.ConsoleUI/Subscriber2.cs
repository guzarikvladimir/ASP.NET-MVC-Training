namespace Task1.ConsoleUI
{
    internal class Subscriber2
    {
        public string PrivateMail { get; private set; }

        public void Register(MailSender mailSender) => mailSender.TimerRing += ActWhenTimerRings;
        public void Unregister(MailSender mailSender) => mailSender.TimerRing -= ActWhenTimerRings;

        private void ActWhenTimerRings(object sender, MessageEventArgs eventArgs)
        {
            PrivateMail += $"FOR {nameof(Subscriber2)}: {eventArgs.Message}";
        }
    }
}

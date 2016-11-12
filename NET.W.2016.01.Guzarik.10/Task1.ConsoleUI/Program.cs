using System;

namespace Task1.ConsoleUI
{
    internal class Program
    {
        private static void Main()
        {
            var mailSender = new MailSender();
            var timer = new TimerImitation(mailSender);
            var subscriber1 = new Subscriber1();
            var subscriber2 = new Subscriber2();

            subscriber1.Register(mailSender);
            subscriber2.Register(mailSender);

            timer.SetDelay(2);
            timer.Run(Console.WriteLine);

            mailSender.Notify("Message for everyone");
            Console.WriteLine(subscriber1.PrivateMail);
            Console.WriteLine(subscriber2.PrivateMail);
        }
    }
}

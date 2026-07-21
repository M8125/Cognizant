using System;

namespace CustomerCommLib
{
    public class MailSender : IMailSender
    {
        public bool SendMail(string toAddress, string subject, string body)
        {
            // Real implementation would use SmtpClient to actually send an email.
            // That's exactly the kind of external dependency we DON'T want to
            // call from a unit test, so CustomerComm depends on IMailSender
            // instead of this concrete class.
            Console.WriteLine($"Sending mail to {toAddress} | Subject: {subject}");
            return true;
        }
    }
}

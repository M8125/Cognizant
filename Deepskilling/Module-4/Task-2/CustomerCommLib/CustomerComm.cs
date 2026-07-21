using System;

namespace CustomerCommLib
{
    public class CustomerComm
    {
        private readonly IMailSender mailSender;

        public CustomerComm(IMailSender mailSender)
        {
            this.mailSender = mailSender;
        }

        public bool SendWelcomeMail(string customerEmail, string customerName)
        {
            if (string.IsNullOrWhiteSpace(customerEmail))
                throw new ArgumentException("Customer email is required");

            string subject = "Welcome!";
            string body = $"Hi {customerName}, welcome to our service!";

            return mailSender.SendMail(customerEmail, subject, body);
        }
    }
}

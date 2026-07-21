using System;
using CustomerCommLib;
using Moq;
using NUnit.Framework;

namespace CustomerCommLib.Tests
{
    [TestFixture]
    public class CustomerCommTests
    {
        private Mock<IMailSender> mockMailSender;
        private CustomerComm customerComm;

        [SetUp]
        public void Setup()
        {
            mockMailSender = new Mock<IMailSender>();
            customerComm = new CustomerComm(mockMailSender.Object);
        }

        [Test]
        public void SendWelcomeMail_ValidEmail_CallsMailSenderOnce()
        {
            mockMailSender
                .Setup(m => m.SendMail(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>()))
                .Returns(true);

            bool result = customerComm.SendWelcomeMail("john@example.com", "John");

            Assert.That(result, Is.True);
            mockMailSender.Verify(
                m => m.SendMail("john@example.com", "Welcome!", It.IsAny<string>()),
                Times.Once);
        }

        [Test]
        public void SendWelcomeMail_MailSenderReturnsFalse_PropagatesFalse()
        {
            mockMailSender
                .Setup(m => m.SendMail(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>()))
                .Returns(false);

            bool result = customerComm.SendWelcomeMail("jane@example.com", "Jane");

            Assert.That(result, Is.False);
        }

        [Test]
        public void SendWelcomeMail_EmptyEmail_ThrowsArgumentExceptionAndNeverCallsMailSender()
        {
            Assert.That(
                () => customerComm.SendWelcomeMail("", "Jane"),
                Throws.ArgumentException);

            mockMailSender.Verify(
                m => m.SendMail(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>()),
                Times.Never);
        }

        [Test]
        public void SendWelcomeMail_BodyContainsCustomerName()
        {
            string capturedBody = string.Empty;
            mockMailSender
                .Setup(m => m.SendMail(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>()))
                .Callback<string, string, string>((to, subject, body) => capturedBody = body)
                .Returns(true);

            customerComm.SendWelcomeMail("john@example.com", "John");

            Assert.That(capturedBody, Does.Contain("John"));
        }
    }
}

using Azure;
using Azure.Communication.Email;
using FilmRental.Services.IServices;

namespace FilmRental.Services
{
    public class EmailService : IEmailService
    {
        private readonly EmailClient _emailClient;

        public EmailService(EmailClient emailClient)
        {
            _emailClient = emailClient;
        }

        public async Task<bool> SendEmailAsync(string toEmail, string subject, string htmlContent)
        {
            try
            {
                var emailMessage = new EmailMessage(
                    senderAddress: "DoNotReply@2470a123-c404-4e95-8de7-78796b33fc70.azurecomm.net",
                    content: new EmailContent(subject)
                    {
                        Html = htmlContent
                    },
                    recipients: new EmailRecipients(new List<EmailAddress> { new EmailAddress(toEmail) })
                );

                var response = await _emailClient.SendAsync(WaitUntil.Completed, emailMessage);

                return response.HasCompleted;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}

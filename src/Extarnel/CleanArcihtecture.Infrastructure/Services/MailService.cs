using CleanArchitecture.Application.Services;
using GenericEmailService;
using System.Net.Mail;

namespace CleanArcihtecture.Infrastructure.Services
{
    public sealed class MailService : IMailService
    {
        public async Task SendMailAsync(List<string> eMails
            ,string subject
            ,string body
            ,List<Attachment>? attachments)
        {
            SendEmailModel sendEmailModel = new()
            {
                Body = body,
                Attachments = attachments,
                Emails = eMails,
                Email = "",
                Html = true,
                Port = 587,
                Password = "",
                Smtp = "",
                SSL = true,
                Subject = subject
            };

            await EmailService.SendEmailAsync(sendEmailModel);
        }
    }
}

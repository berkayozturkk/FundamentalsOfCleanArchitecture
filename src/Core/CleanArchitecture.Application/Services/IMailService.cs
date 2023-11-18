using System.Net.Mail;

namespace CleanArchitecture.Application.Services;

public interface IMailService
{
    Task SendMailAsync(List<string> eMails
            , string subject
            , string body
            , List<Attachment>? attachments);
}

using DevHobby.CourseFlow.Application.Contracts.Infrastructure;
using DevHobby.CourseFlow.Application.Models;
using Microsoft.Extensions.Options;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace DevHobby.CourseFlow.Infrastructure.Mail;

public class EmailService : IEmailService
{
    public EmailSettings _mailSettings { get; }

    public EmailService(IOptions<EmailSettings> mailSettings)
    {
        _mailSettings = mailSettings.Value;
    }

    public async Task<bool> SendEmailAsync(Email email)
    {
        var client = new SendGridClient(_mailSettings.ApiKey);
        var from = new EmailAddress
        {
            Email = _mailSettings.FromAddress,
            Name = _mailSettings.FromName
        };

        var subject = email.Subject;
        var to = new EmailAddress(email.To);
        var emailBody = email.Body;

        var sendGridMessage = MailHelper.CreateSingleEmail(from, to, subject, emailBody, emailBody);
        var response = await client.SendEmailAsync(sendGridMessage);

        if(response.StatusCode == System.Net.HttpStatusCode.Accepted || 
            response.StatusCode == System.Net.HttpStatusCode.OK)
            return true;
        return false;
    }
}

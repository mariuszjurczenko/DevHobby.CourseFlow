using DevHobby.CourseFlow.Application.Models;

namespace DevHobby.CourseFlow.Application.Contracts.Infrastructure;

public interface IEmailService
{
    Task<bool> SendEmailAsync(Email email);
}

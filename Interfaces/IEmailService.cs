using MbnakomAPIS.Common.Enums;

namespace MbnakomAPIS.Interfaces
{
    public interface IEmailService
    {
        Task<EmailResponseStatus> SendEmailToUserAsync(string toEmail, string subject, string body);
    }
}

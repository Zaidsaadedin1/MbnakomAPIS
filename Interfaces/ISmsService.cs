using MbnakomAPIS.Common.Enums;

namespace MbnakomAPIS.Interfaces
{
    public interface ISmsService
    {
        Task<SmsResponseStatus> SendSmsToUserAsync(string phoneNumber, string message, string otp);
    }
}

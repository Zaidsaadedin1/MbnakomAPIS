using MbnakomAPIS.Common.Dtos.Shared;
using MbnakomAPIS.Common.Dtos.VerificationsDtos;
using MbnakomAPIS.Common.Enums;

namespace MbnakomAPIS.Interfaces
{
    public interface IOtpService
    {
        Task<GenericResponse<bool>> SendOtpAsync(string emailOrPhone);
        Task<VerificationResult> VerifyUserOtpAsync(VerifyOtpDto verifyOtpDto);
    }
}

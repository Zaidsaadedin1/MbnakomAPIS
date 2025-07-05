using MbnakomAPIS.Common.Dtos.AuthDtos;
using MbnakomAPIS.Common.Dtos;
using MbnakomAPIS.Common.Dtos.Shared;

namespace MbnakomAPIS.Interfaces
{
    public interface IAuthService
    {
        Task<GenericResponse<RegisterUserDto>> RegisterUserAsync(RegisterUserDto registerUserDto);
        Task<GenericResponse<string>> LoginUserAsync(LoginUserDto loginUserDto);
        Task<bool> IsUsersPhoneOrEmailTakenAsync(string identifier);
        Task<GenericResponse<bool>> UserPasswordResetAsync(ResetPasswordDto resetPasswordDto);
    }
}

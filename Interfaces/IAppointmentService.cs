using MbnakomAPIS.Common.Dtos.AppointmentDtos;
using MbnakomAPIS.Common.Dtos.OrderDtos;
using MbnakomAPIS.Common.Dtos.Shared;

namespace MbnakomAPIS.Interfaces
{
    public interface IAppointmentService
    {
        Task<GenericResponse<IEnumerable<GetAppointmentForAdminDto>>> GetAllAppointmentsAsync();
        Task<GenericResponse<IEnumerable<GetAppointmentDto>>> GetAllUserAppointmentsAsync(string userId);
        Task<GenericResponse<GetAppointmentDto>> GetAppointmentByIdAsync(int id);
        Task<GenericResponse<int>> CreateAppointmentAsync(CreateAppointmentDto createOrderDto);
        Task<GenericResponse<bool>> UpdateAppointmentAsync(int id, UpdateAppointmentDto updateOrderDto);
        Task<GenericResponse<bool>> DeleteAppointmentAsync(int id);
}
    }

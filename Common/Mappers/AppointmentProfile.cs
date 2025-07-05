using AutoMapper;
using MbnakomAPIS.Common.Dtos.AppointmentDtos;
using MbnakomAPIS.Common.Dtos.OrderDtos;
using MbnakomAPIS.Common.Entities;
using MbnakomAPIS.Controllers;

public class AppointmentMappingProfile : Profile
{
    public AppointmentMappingProfile()
    {
        // Mapping from Order entity to GetOrderDto
        CreateMap<Appointment, GetAppointmentDto>();

        // Mapping from CreateOrderDto to Order
        CreateMap<CreateAppointmentDto, Appointment>();

        // Mapping from UpdateOrderDto to Order
        CreateMap<UpdateAppointmentDto, Appointment>();

        CreateMap<Appointment, GetAppointmentForAdminDto>()
    .ForMember(dest => dest.UserFirstName, opt => opt.MapFrom(src => src.User != null ? src.User.FirstName : null))
    .ForMember(dest => dest.UserLastName, opt => opt.MapFrom(src => src.User != null ? src.User.LastName : null))
    .ForMember(dest => dest.UserEmail, opt => opt.MapFrom(src => src.User != null ? src.User.Email : null))
    .ForMember(dest => dest.UserPhone, opt => opt.MapFrom(src => src.User != null ? src.User.PhoneNumber : null));

    }
}

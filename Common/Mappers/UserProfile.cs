using AutoMapper;
using MbnakomAPIS.Common.Dtos.UserDto;
using MbnakomAPIS.Common.Entities;

namespace MbnakomAPIS.Common.Mapping
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<UpdateUserDto, User>();
            CreateMap<User, GetUserDto>();
              
        }
    }
}

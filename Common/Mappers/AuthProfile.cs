using AutoMapper;
using MbnakomAPIS.Common.Dtos.AuthDtos;
using MbnakomAPIS.Common.Entities;

namespace MbnakomAPIS.Common.Mappers
{
    public class AuthProfile : Profile
    {

        public AuthProfile()
        {
            CreateMap<LoginUserDto, User>();

            CreateMap<RegisterUserDto, User>();

        }
    }

}


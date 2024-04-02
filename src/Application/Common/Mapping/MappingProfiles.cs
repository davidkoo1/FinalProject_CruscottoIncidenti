using Application.DTO.User;
using AutoMapper;
using Domain.Entities;

namespace Application.Common.Mapping
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {

            CreateMap<User, UserDto>();
            CreateMap<UserDto, User>();


        }
    }
}

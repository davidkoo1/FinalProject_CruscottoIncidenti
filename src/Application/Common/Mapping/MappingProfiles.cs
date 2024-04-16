using Application.DTO;
using AutoMapper;
using Domain.Entities;
using Domain.Entities.HelpDesk;

namespace Application.Common.Mapping
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            //MappGetAllUsers
            CreateMap<User, UserDto>()
                .ForMember(dest => dest.UserRoles, opt => opt.MapFrom(src => src.UserRoles.Select(ur => ur.Role.Name)));

            // CreateMap<UserDto, User>();            

            CreateMap<UpsertUserDto, User>();
            CreateMap<User, UpsertUserDto>().ForMember(dest => dest.RolesId, opt => opt.MapFrom(src => src.UserRoles.Select(ur => ur.Role.Id)));


            //CreateMap<User, UpdateUserDto>().ForMember(dest => dest.RolesId, opt => opt.MapFrom(src => src.UserRoles.Select(ur => ur.Role.Id)));
            //CreateMap<UpdateUserDto, User>(); //Here also map

            CreateMap<Incident, IncidentDto>();
        }
    }
}

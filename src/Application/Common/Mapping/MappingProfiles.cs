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
            
            //This forUpsert
            CreateMap<UpsertIncidentDto, Incident>();

            CreateMap<Incident, IncidentDto>();

            CreateMap<IncidentOrigin, SimpleDto>();
            CreateMap<IncidentAmbit, SimpleDto>();
            CreateMap<IncidentType, SimpleDto>();
            CreateMap<Scenary, SimpleDto>();
            CreateMap<Threat, SimpleDto>();

            CreateMap<Incident, IncidentDetailDto>()
            .ForMember(dto => dto.IncidentType, conf => conf.MapFrom(inc => inc.IncidentType.Name))
            .ForMember(dto => dto.Ambit, conf => conf.MapFrom(inc => inc.Ambit.Name))
            .ForMember(dto => dto.Origin, conf => conf.MapFrom(inc => inc.Origin.Name))
            .ForMember(dto => dto.Scenary, conf => conf.MapFrom(inc => inc.Scenary.Name))
            .ForMember(dto => dto.Threat, conf => conf.MapFrom(inc => inc.Threat.Name));
        }
    }
}

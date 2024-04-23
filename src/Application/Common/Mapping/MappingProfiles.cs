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
            CreateMap<Incident, UpsertIncidentDto>()
            .ForMember(dto => dto.IncidentTypeId, conf => conf.MapFrom(inc => inc.IncidentType.Id))
            .ForMember(dto => dto.AmbitId, conf => conf.MapFrom(inc => inc.Ambit.Id))
            .ForMember(dto => dto.OriginId, conf => conf.MapFrom(inc => inc.Origin.Id))
            .ForMember(dto => dto.ScenaryId, conf => conf.MapFrom(inc => inc.Scenary.Id))
            .ForMember(dto => dto.ThreatId, conf => conf.MapFrom(inc => inc.Threat.Id));


            //CreateMap<User, UpdateUserDto>().ForMember(dest => dest.RolesId, opt => opt.MapFrom(src => src.UserRoles.Select(ur => ur.Role.Id)));
            //CreateMap<UpdateUserDto, User>(); //Here also map

            //This forUpsert
            CreateMap<UpsertIncidentDto, Incident>();

            CreateMap<Incident, IncidentDto>()
            .ForMember(dto => dto.OpenDate, opt => opt.MapFrom(src => src.OpenDate.ToString("yyyy-MM-dd")))
            .ForMember(dto => dto.CloseDate, opt => opt.MapFrom(src => src.CloseDate.HasValue ? src.CloseDate.Value.ToString("yyyy-MM-dd") : null));


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

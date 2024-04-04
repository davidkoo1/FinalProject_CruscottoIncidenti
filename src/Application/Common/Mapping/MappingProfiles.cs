using Application.DTO.User;
using AutoMapper;
using Domain.Entities;

namespace Application.Common.Mapping
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<User, UserDto>()
                .ForMember(dest => dest.UserRoles, opt => opt.MapFrom(src => src.UserRoles.Select(ur => ur.Role.Name)));

            CreateMap<UserDto, User>();

            //TODO Mapping with roles and delete oneOfThisMap
            //dontDeleteCurrentUser
            //Validation(UserRoleSet), Resources
            //UserController add method for getRolesViewBag
            //Clear code Repos&Controllers

            CreateMap<CreateUserDto, User>();


            CreateMap<User, UpdateUserDto>().ForMember(dest => dest.RolesId, opt => opt.MapFrom(src => src.UserRoles.Select(ur => ur.Role.Id)));
            CreateMap<UpdateUserDto, User>(); //Here also map
        }
    }
}

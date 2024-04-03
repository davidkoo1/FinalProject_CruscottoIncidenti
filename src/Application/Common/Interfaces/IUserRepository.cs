using Application.DTO.User;
using Domain.Entities;
using System.Web.Mvc;

namespace Application.Common.Interfaces
{
    public interface IUserRepository
    {
        Task<UserDto> GetUserByUserNameAsync(LoginDto loginVM);
        Task<UserDto> GetUserByIdAsync(int id);
        Task<IEnumerable<UserDto>> GetUsersAsync();
        Task<IEnumerable<RoleDto>> GetRolesAsync();
        Task<bool> UserExists(int userId);
        Task<bool> Add(CreateUserDto createUserDto);
        bool Update(User user);
        Task<bool> Delete(int id);
    }
}

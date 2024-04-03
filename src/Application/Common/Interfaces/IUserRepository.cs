using Application.DTO.User;
using Domain.Entities;

namespace Application.Common.Interfaces
{
    public interface IUserRepository
    {
        Task<UserDto> GetUserByUserNameAsync(LoginDto loginVM);
        Task<UserDto> GetUserByIdAsync(int id);
        Task<IEnumerable<UserDto>> GetUsersAsync();
        Task<bool> Add(UserDto userDto);
        bool Update(User user);
        bool Delete(UserDto user);
    }
}

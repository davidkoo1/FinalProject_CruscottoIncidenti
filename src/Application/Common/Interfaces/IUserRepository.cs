using Application.DTO.User;

namespace Application.Common.Interfaces
{
    public interface IUserRepository
    {
        Task<UserDto> GetUserByUserNameAsync(LoginDto loginVM);
    }
}

using Application.DTO;
using Application.TableParameters;
using Domain.Entities;

namespace Application.Common.Interfaces
{
    public interface IUserRepository
    {
        Task<IEnumerable<UserDto>> GetAll(DataTablesParameters parameters);

        Task<UserDto> GetUserById(int userId);
        Task<UpsertUserDto> GetUserForUpsertById(int userId);
        Task<bool> UpsertUser(UpsertUserDto upsertUserDto);
        //Task<bool> AddUser(CreateUser toCreateUser);

        //Task<bool> UpdateUser(UpdateUser toUpdateUser);

        Task<bool> DeleteUser(int userId);
        Task<bool> Save();
        Task<User> GetUserForLogin(LoginDto UserToLogin);
        Task<IEnumerable<Role>> GetRolesAsync();
    }
}
using Application.Common.Interfaces;
using Application.DTO.User;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using System.Text;

namespace Application.Common.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly IApplicationDbContext _dbContext;

        public UserRepository(IApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<User> GetUserByIdAsync(int id) => await _dbContext.Users.FirstOrDefaultAsync(x => x.Id == id);

        public async Task<UserDto> GetUserByUserNameAsync(LoginDto loginVM)
        {

            var user = await _dbContext.Users.FirstOrDefaultAsync(u => u.UserName == loginVM.Username);
            string encrypted = "";
            using (SHA256 hash = SHA256.Create())
            {
                encrypted = string.Concat(hash
                    .ComputeHash(Encoding.UTF8.GetBytes(loginVM.Password))
                    .Select(item => item.ToString("x2")));
            }
            if (user != null && user.Password == encrypted)
            {
                var userVM = new UserDto
                {
                    Id = user.Id,
                    UserName = user.UserName,
                    FullName = user.FullName,
                    Email = user.Email,
                    IsEnabled = user.IsEnabled,
                    UserRoles = user.UserRoles.Where(u => u.UserId == user.Id).Select(ur => ur.Role.Name).ToList()
                };

                return userVM;
            }

            return null;
        }

        public async Task<IEnumerable<User>> GetUsersAsync() => await _dbContext.Users.ToListAsync();
    }
}

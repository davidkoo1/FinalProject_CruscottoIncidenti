using Application.Common.Interfaces;
using Application.DTO;
using Application.Extensions;
using Application.TableParameters;
using AutoMapper;
using Domain.Entities;
using Infrastructure.Persistance;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using System.Text;

namespace Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public UserRepository(ApplicationDbContext dbContext, IMapper mapper, IHttpContextAccessor httpContextAccessor)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<bool> DeleteUser(int userId)
        {
            var user = _dbContext.Users
            .FirstOrDefault(p => p.Id == userId);

            if (user is null) return false;

            _dbContext.Users.Remove(user);

            return await Save();
        }

        public async Task<IEnumerable<UserDto>> GetAll(DataTablesParameters parameters) => _mapper.Map<IEnumerable<UserDto>>(await _dbContext.Users
            .Search(parameters)
            .OrderBy(parameters)
            .Page(parameters)
            .ToListAsync());

        public async Task<IEnumerable<Role>> GetRolesAsync() => await _dbContext.Roles.ToListAsync();

        public async Task<UserDto> GetUserById(int userId) => _mapper.Map<UserDto>(await _dbContext.Users
            .Include(x => x.UserRoles).ThenInclude(x => x.Role)
            .FirstOrDefaultAsync(x => x.Id == userId));

        public async Task<User> GetUserForLogin(LoginDto UserToLogin)
        {
            var user = await _dbContext.Users.Include(x => x.UserRoles).ThenInclude(x => x.Role).FirstOrDefaultAsync(u => u.UserName == UserToLogin.Username);

            var encrypted = HashPW(UserToLogin.Password);
            if (user != null && user.Password == encrypted)
            {
                return user;
            }
            return null;
        }
        private bool UserExists(int userId) => _dbContext.Users.Any(x => x.Id == userId);
        public async Task<UpsertUserDto> GetUserForUpsertById(int userId)
        {
            if (UserExists(userId))
            {
                return _mapper.Map<UpsertUserDto>(await _dbContext.Users
                            .Include(x => x.UserRoles).ThenInclude(x => x.Role)
                            .FirstOrDefaultAsync(x => x.Id == userId));
            }
            return new UpsertUserDto();
        }

        public async Task<bool> Save() => await _dbContext.SaveChangesAsync() > 0 ? true : false;

        public async Task<bool> UpsertUser(UpsertUserDto upsertUserDto)
        {

            var existing = await _dbContext.Users.AnyAsync(x => x.Id != upsertUserDto.Id &&
            (x.UserName == upsertUserDto.UserName || x.Email == upsertUserDto.Email));

            if (upsertUserDto == null || existing == true)
            {
                return false;
            }
            var currentUser = _httpContextAccessor.HttpContext?.User.GetUserId();
            var userToUpsert = _mapper.Map<User>(upsertUserDto);
            //NewUser
            if (upsertUserDto.Id == 0)
            {

                string defaultPW = "Cedacri1234567!";

                userToUpsert.Created = DateTime.UtcNow;
                userToUpsert.CreatedBy = currentUser;
                userToUpsert.Password = HashPW(defaultPW);
                userToUpsert.UserRoles = upsertUserDto.RolesId.Select(id => new UserRole { RoleId = id }).ToList();

                _dbContext.Add(userToUpsert);

                return await Save();

            }
            else
            {
                //Update User
                var userForOldPw = await _dbContext.Users.AsNoTracking().FirstOrDefaultAsync(x => x.Id == userToUpsert.Id);
                userToUpsert.LastModified = DateTime.UtcNow;
                userToUpsert.LastModifiedBy = currentUser;
                userToUpsert.Password = userForOldPw.Password;

                // Удаляем старые роли пользователя
                var userRolesToRemove = _dbContext.UserRoles.Where(ur => ur.UserId == userToUpsert.Id);
                _dbContext.UserRoles.RemoveRange(userRolesToRemove);

                userToUpsert.UserRoles = new List<UserRole>();
                userToUpsert.UserRoles.AddRange(upsertUserDto.RolesId.Select(id => new UserRole { RoleId = id }));
                _dbContext.Update(userToUpsert);
                return await Save();

            }
        }

        private string HashPW(string password)
        {

            using (SHA256 hash = SHA256.Create())
            {
                return string.Concat(hash
                    .ComputeHash(Encoding.UTF8.GetBytes(password))
                    .Select(item => item.ToString("x2")));
            }
        }
    }
}

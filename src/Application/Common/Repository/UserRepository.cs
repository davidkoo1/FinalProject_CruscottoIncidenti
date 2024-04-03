﻿using Application.Common.Interfaces;
using Application.DTO.User;
using AutoMapper;
using Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using System.Text;

namespace Application.Common.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly IApplicationDbContext _dbContext;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public UserRepository(IApplicationDbContext dbContext, IMapper mapper, IHttpContextAccessor httpContextAccessor)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<bool> Add(UserDto userDto)
        {
            var existing = await _dbContext.Users.AnyAsync(x => x.UserName == userDto.UserName || x.Email == userDto.Email);

            if (userDto == null || existing == true)
            {
                return false;
            }
            else
            {
                string defaultPW = "Cedacri1234567!";
                var currentUser = _httpContextAccessor.HttpContext?.User.GetUserId();

                var user = _mapper.Map<User>(userDto);

                user.CreatedBy = currentUser;
                user.Created = DateTime.UtcNow;
                user.Password = HashPW(defaultPW);

                _dbContext.Users.Add(user);

                return await _dbContext.SaveAsync();
            }
        }

        public async Task<bool> Delete(int id)
        {
            var user = await _dbContext.Users.FirstOrDefaultAsync(x => x.Id == id);
            _dbContext.Users.Remove(user);
            return await _dbContext.SaveAsync();
        }

        public async Task<UserDto> GetUserByIdAsync(int id) => _mapper.Map<UserDto>(await _dbContext.Users.Include(x => x.UserRoles).ThenInclude(x => x.Role).FirstOrDefaultAsync(x => x.Id == id));

        private string HashPW(string password)
        {

            using (SHA256 hash = SHA256.Create())
            {
                return string.Concat(hash
                    .ComputeHash(Encoding.UTF8.GetBytes(password))
                    .Select(item => item.ToString("x2")));
            }
        }
        public async Task<UserDto> GetUserByUserNameAsync(LoginDto loginVM)
        {

            var user = await _dbContext.Users.Include(x => x.UserRoles).ThenInclude(x => x.Role).FirstOrDefaultAsync(u => u.UserName == loginVM.Username);
            //var UserRoles = await _dbContext.UserRoles.Where(x => x.UserId == user.Id).Select(ur => ur.Role.Name).ToListAsync();
            var encrypted = HashPW(loginVM.Password);
            if (user != null && user.Password == encrypted)
            {

                var userVM = _mapper.Map<UserDto>(user);

                //    new UserDto
                //{
                //    Id = user.Id,
                //    UserName = user.UserName,
                //    FullName = user.FullName,
                //    Email = user.Email,
                //    IsEnabled = user.IsEnabled,
                //    UserRoles = user.UserRoles.Where(u => u.UserId == user.Id).Select(ur => ur.Role.Name).ToList()
                //};

                return userVM;
            }

            return null;
        }

        public async Task<IEnumerable<UserDto>> GetUsersAsync() => _mapper.Map<List<UserDto>>(await _dbContext.Users.ToListAsync());


        public bool Update(User user)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> UserExists(int userId) => await _dbContext.Users.AnyAsync(x => x.Id == userId);
    }
}

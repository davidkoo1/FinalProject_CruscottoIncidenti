using Application.Common.Extensions;
using Application.Common.Interfaces;
using Application.DTO;
using Application.UserCQRS.Commands;
using AutoMapper;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace Application.UserCQRS.CommandHandlers
{
    public class UpsertUserHandler : IRequestHandler<UpsertUser, bool>
    {
        private readonly IApplicationDbContext _dbContext;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public UpsertUserHandler(IApplicationDbContext dbContext, IMapper mapper, IHttpContextAccessor httpContextAccessor)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<bool> Handle(UpsertUser request, CancellationToken cancellationToken)
        {
            var existing = await _dbContext.Users.AnyAsync(x => x.Id != request.UpsertUserDto.Id &&
            (x.UserName == request.UpsertUserDto.UserName || x.Email == request.UpsertUserDto.Email));

            if (request.UpsertUserDto == null || existing == true)
            {
                return false;
            }
            var currentUser = _httpContextAccessor.HttpContext?.User.GetUserId();
            var userToUpsert = _mapper.Map<User>(request.UpsertUserDto);
            //NewUser
            if (request.UpsertUserDto.Id == 0)
            {

                //string defaultPW = "Cedacri1234567!";

                userToUpsert.Created = DateTime.UtcNow;
                userToUpsert.CreatedBy = currentUser;
                userToUpsert.Password = "e17c8fa0a351caf1138741f0862208a250ecfa122ce3f4cbba637a2e510e2920";
                userToUpsert.UserRoles = request.UpsertUserDto.RolesId.Select(id => new UserRole { RoleId = id }).ToList();

                _dbContext.Users.Add(userToUpsert);

                return await _dbContext.SaveChangesAsync(cancellationToken) > 0 ? true : false;

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
                userToUpsert.UserRoles.AddRange(request.UpsertUserDto.RolesId.Select(id => new UserRole { RoleId = id }));
                _dbContext.Users.Update(userToUpsert);
                return await _dbContext.SaveChangesAsync(cancellationToken) > 0 ? true : false;

            }
        }
    }
}

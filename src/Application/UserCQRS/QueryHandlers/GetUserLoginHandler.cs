using Application.Common.Interfaces;
using Application.DTO;
using Application.UserCQRS.Queries;
using AutoMapper;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Text;
using System.Security.Cryptography;

namespace Application.UserCQRS.QueryHandlers
{
    public class GetUserLoginHandler : IRequestHandler<GetUserForLogin, User>
    {
        private readonly IApplicationDbContext _dbContext;
        private readonly IMapper _mapper;
        public GetUserLoginHandler(IApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<User> Handle(GetUserForLogin request, CancellationToken cancellationToken)
        {
            var user = await _dbContext.Users.Include(x => x.UserRoles).ThenInclude(x => x.Role)
                .FirstOrDefaultAsync(u => u.UserName == request.Username, cancellationToken);

            var encrypted = HashPW(request.Password);
            if (user != null && user.Password == encrypted)
            {
                return user;
            }
            return null;
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

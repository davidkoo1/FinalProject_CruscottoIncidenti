
using Application.DTO;
using Application.TableParameters;
using MediatR;

namespace Application.UserCQRS.Queries
{
    public class GetAllUsers : IRequest<IEnumerable<UserDto>>
    {
        public DataTablesParameters Parameters { get; set; }
        public GetAllUsers(DataTablesParameters parameters)
        {
            Parameters = parameters;
        }
    }
}

using Domain.Entities;
using MediatR;

namespace Application.Entities.Users.Queries.GetUser
{
    public record GetUserQuery : IRequest<User> 
    {
        public Guid UserId { get; set; }
    }    
}

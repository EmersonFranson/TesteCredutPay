using Domain.Entities;
using Domain.Interfaces;
using MediatR;

namespace Application.Entities.Users.Queries.GetUser
{
    public class GetUsersListHandler : IRequestHandler<GetUsersListQuery, IEnumerable<User>>
    {
        private readonly IUserRepository _userRepository;

        public GetUsersListHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<IEnumerable<User>> Handle(GetUsersListQuery request, CancellationToken cancellationToken)
        {
            return await _userRepository.GetAllAsync();
        }
    }
    public record GetUsersListQuery : IRequest<IEnumerable<User>>;
}

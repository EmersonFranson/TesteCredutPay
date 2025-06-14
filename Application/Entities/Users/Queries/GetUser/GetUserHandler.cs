using Domain.Entities;
using Domain.Interfaces;
using MediatR;

namespace Application.Entities.Users.Queries.GetUser
{
    public class GetUserHandler : IRequestHandler<GetUserQuery, User>
    {
        private readonly IUserRepository _userRepository;

        public GetUserHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<User> Handle(GetUserQuery request, CancellationToken cancellationToken)
        {
            return await _userRepository.GetByIdAsync(request.UserId);
        }       
    }
}

using Domain.Entities;
using Domain.Interfaces;
using MediatR;

namespace Application.Entities.Users.Commands
{
    public class CreateUserHandler : IRequestHandler<CreateUserCommand, Guid>
    {
        private readonly IUserRepository _userRepository;
        public CreateUserHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<Guid> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var user = new User
            {
                id = Guid.NewGuid(),
                Name = request.Name,
                Phone = request.Phone,
                Login = request.Login,
                Password = request.Password,
                DtBirth = request.DtBirth
            };
            await _userRepository.AddAsync(user);
            return user.id;
        }
    }
}

using MediatR;

namespace Application.Entities.Users.Commands
{
    public record CreateUserCommand : IRequest<Guid>
    {
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public DateTime DtBirth { get; set; }
    }
}

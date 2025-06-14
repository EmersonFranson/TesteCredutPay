using Application.Entities.Users.Commands;
using Application.Entities.Users.Queries.GetUser;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UserController(IMediator mediator)
        {
            _mediator  = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser([FromBody] CreateUserCommand command)
        {
            if (command == null)
            {
                return BadRequest("Invalid user data.");
            }
            var userId = await _mediator.Send(command);
            return Ok(userId);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserById(Guid id)
        {
            var query = new GetUserQuery { UserId = id };
            var user = await _mediator.Send(query);

            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }

        [HttpGet]
        public async Task<IActionResult> GetUsersList()
        {
            var query = new GetUsersListQuery();
            var users = await _mediator.Send(query);
            return Ok(users);
        }
    }
}

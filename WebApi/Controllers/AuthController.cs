using Infrastructure.Identity;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly JwtTokenGenerator _tokenGenerator;

        public AuthController(JwtTokenGenerator tokenGenerator)
        {
            _tokenGenerator = tokenGenerator;
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginRequest request)
        {
            // Validar usuário (aqui você faria o check no banco)
            if (request.Email == "admin@teste.com" && request.Password == "123456")
            {
                var token = _tokenGenerator.GenerateToken(Guid.NewGuid(), request.Email, "Admin");
                return Ok(new { Token = token });
            }

            return Unauthorized("Usuário ou senha inválido");
        }
    }

    public class LoginRequest
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }

}

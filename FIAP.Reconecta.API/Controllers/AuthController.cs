using FIAP.Reconecta.Domain.Services;
using FIAP.Reconecta.Models.DTO.User;
using FIAP.Reconecta.Models.Entities.User;
using FIAP.Reconecta.Services.Services;
using Microsoft.AspNetCore.Mvc;

namespace FIAP.Reconecta.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUserService _userService;

        public AuthController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("token")]
        public ActionResult<User> Post([FromBody] PostUser dto)
        {
            var user = _userService.GetByLogin(dto.Email, dto.Password);

            if (user is null)
                return Unauthorized(new { Message = "Usuário ou senha inválidos" });

            var token = TokenService.GenerateToken(user);

            return Ok(new { token, user });
        }

    }
}

using FIAP.Reconecta.Application.Services;
using FIAP.Reconecta.Contracts.DTO.User;
using FIAP.Reconecta.Contracts.Models.User;
using FIAP.Reconecta.Domain.Services;
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

        #region Base

        [HttpPost("token")]
        public ActionResult<User> Post([FromBody] PostUser dto)
        {
            var user = _userService.GetByLogin(dto.Email, dto.Password);

            if (user is null)
                return Unauthorized(new { Message = "Usuário ou senha inválidos" });

            var token = TokenService.GenerateToken(user);

            //Hide password
            user.Password = string.Empty;

            return Ok(new { token, user });
        }

        #endregion
    }
}

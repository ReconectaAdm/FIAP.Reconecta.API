using FIAP.Reconecta.Domain.Services;
using FIAP.Reconecta.Models.DTO.User;
using FIAP.Reconecta.Models.Entities.User;
using FIAP.Reconecta.Services.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FIAP.Reconecta.API.Controllers
{
    [Authorize]
    public class UserController : BaseController
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("auth")]
        [AllowAnonymous]
        public ActionResult Auth([FromBody] PostUser dto)
        {
            var user = _userService.GetByLogin(dto.Email, dto.Password);

            if (user is null)
                return Unauthorized(new { Message = "Usuário ou senha inválidos" });

            var token = TokenService.GenerateToken(user);

            return Ok(new { token, user });
        }

        [HttpPatch("password")]
        [AllowAnonymous]
        public ActionResult UpdatePassword([FromBody] PatchUser dto)
        {
            _userService.UpdatePassword(dto.Email, dto.Password);
            return NoContent();
        }

        [HttpDelete]
        public ActionResult Delete()
        {
            var user = _userService.GetById(UserId);

            if (user != null)
            {
                _userService.Delete(UserId, CompanyId);
                return NoContent();
            }
            else
                return NotFound();
        }

    }
}

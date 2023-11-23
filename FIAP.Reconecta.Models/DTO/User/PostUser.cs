using System.ComponentModel.DataAnnotations;

namespace FIAP.Reconecta.Models.DTO.User
{
    public class PostUser
    {
        [Required]
        public string Email { get; set; } = string.Empty;
        [Required]
        public string Password { get; set; } = string.Empty;

        public static explicit operator Entities.User.User(PostUser dto) => new() { Email = dto.Email, Password = dto.Password };
    }
}

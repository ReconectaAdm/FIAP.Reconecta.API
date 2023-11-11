using FIAP.Reconecta.Models.Entities.User;

namespace FIAP.Reconecta.Domain.Services
{
    public interface IUserService : IBaseService<User>
    {
        public User? GetByLogin(string email, string password);
    }
}

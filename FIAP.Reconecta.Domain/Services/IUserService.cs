using FIAP.Reconecta.Contracts.Models.User;

namespace FIAP.Reconecta.Domain.Services
{
    public interface IUserService : IBaseService<User>
    {
        public User? GetByLogin(string email, string password);
    }
}

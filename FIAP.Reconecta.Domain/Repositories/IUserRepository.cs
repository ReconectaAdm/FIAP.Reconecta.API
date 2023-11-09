using FIAP.Reconecta.Contracts.Models.User;

namespace FIAP.Reconecta.Domain.Repositories
{
    public interface IUserRepository : IBaseRepository<User>
    {
        public User? GetByLogin(string email, string password);
    }
}

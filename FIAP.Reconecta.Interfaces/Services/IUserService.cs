using FIAP.Reconecta.Models.Entities.User;

namespace FIAP.Reconecta.Domain.Services
{
    public interface IUserService : IBaseService<User>
    {
        void Delete(int id, int companyId);
        public User? GetByLogin(string email, string password);
        void UpdatePassword(string email, string password);
    }
}

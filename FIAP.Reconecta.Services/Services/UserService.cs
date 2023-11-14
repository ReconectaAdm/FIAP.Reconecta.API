using FIAP.Reconecta.Domain.Repositories;
using FIAP.Reconecta.Domain.Services;
using FIAP.Reconecta.Models.Entities.User;

namespace FIAP.Reconecta.Services.Services
{
    public class UserService : BaseService<User>, IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly ICompanyRepository _companyRepository;
        public UserService(IUserRepository userRepository, ICompanyRepository companyRepository) : base(userRepository)
        {
            _userRepository = userRepository;
            _companyRepository = companyRepository;
        }

        public User? GetByLogin(string email, string password)
        {
            return _userRepository.GetByLogin(email, password);
        }

        public void Delete(int id, int companyId)
        {
            base.Delete(id);

            _companyRepository.Delete(companyId);
        }

    }
}

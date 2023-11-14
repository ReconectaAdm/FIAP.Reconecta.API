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

        public void UpdatePassword(string email, string password)
        {
            var user = _userRepository.GetByEmail(email) 
                ?? throw new Exception("Não foi possível alterar a senha: email não localizado na base de dados.");
            
            user.Password = password;
            _userRepository.UpdatePassword(user);
        }

        public void Delete(int id, int companyId)
        {
            base.Delete(id);

            _companyRepository.Delete(companyId);
        }

    }
}

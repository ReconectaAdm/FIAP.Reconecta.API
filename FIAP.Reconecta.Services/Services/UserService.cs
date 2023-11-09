using FIAP.Reconecta.Contracts.Models.User;
using FIAP.Reconecta.Domain.Repositories;
using FIAP.Reconecta.Domain.Services;

namespace FIAP.Reconecta.Application.Services
{
    public class UserService : BaseService<User>, IUserService
    {
        private readonly IUserRepository _userRepository;
        public UserService(IUserRepository userRepository) : base(userRepository) 
        {
            _userRepository = userRepository;
        }

        public User? GetByLogin(string email, string password)
        {
            return _userRepository.GetByLogin(email, password);    
        }

    }
}

﻿using FIAP.Reconecta.Models.Entities.User;

namespace FIAP.Reconecta.Domain.Repositories
{
    public interface IUserRepository : IBaseRepository<User>
    {
        User? GetByEmail(string email);
        public User? GetByLogin(string email, string password);
        void UpdatePassword(User user);
    }
}

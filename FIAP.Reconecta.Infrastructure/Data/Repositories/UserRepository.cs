using FIAP.Reconecta.Contracts.Models.User;
using FIAP.Reconecta.Domain.Repositories;
using FIAP.Reconecta.Infrastructure.Data.Repositories.Context;
using Microsoft.EntityFrameworkCore;

namespace FIAP.Reconecta.Infrastructure.Data.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly DataBaseContext dataBaseContext;

        public UserRepository(DataBaseContext ctx)
        {
            dataBaseContext = ctx;
        }

        public IEnumerable<User> Get()
        {
            return dataBaseContext.User;
        }

        public User? GetByLogin(string email, string password)
        {
            var user = dataBaseContext.User.AsNoTracking()
                .Include(u => u.Company)
                .FirstOrDefault(u => u.Email == email && u.Password == password);
            return user;
        }

        public User? GetById(int id)
        {
            var user = dataBaseContext.User.AsNoTracking()
                .FirstOrDefault(u => u.Id == id);
            return user;
        }

        public void Add(User user)
        {
            dataBaseContext.User.Add(user);
            dataBaseContext.SaveChanges();
        }

        public void Update(User user)
        {
            dataBaseContext.User.Update(user);
            dataBaseContext.SaveChanges();
        }

        public void Delete(int id)
        {
            var user = new User { Id = id };
            dataBaseContext.User.Remove(user);
            dataBaseContext.SaveChanges();
        }
    }
}
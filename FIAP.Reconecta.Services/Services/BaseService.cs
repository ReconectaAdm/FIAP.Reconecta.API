using FIAP.Reconecta.Domain.Repositories;
using FIAP.Reconecta.Domain.Services;

namespace FIAP.Reconecta.Application.Services
{
    public class BaseService<T> : IBaseService<T>
    {
        private readonly IBaseRepository<T> _baseRepository;
        public BaseService(IBaseRepository<T> baseRepository)
        {
            _baseRepository = baseRepository;
        }

        public virtual IEnumerable<T> Get()
        {
            return _baseRepository.Get();
        }

        public virtual T? GetById(int id)
        {
            return _baseRepository.GetById(id);
        }

        public virtual void Add(T entity)
        {
            _baseRepository.Add(entity);
        }

        public virtual void Update(T entity)
        {
            _baseRepository.Update(entity);
        }

        public virtual void Delete(int id)
        {
            _baseRepository.Delete(id);
        }

    }
}

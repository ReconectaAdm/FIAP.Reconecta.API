namespace FIAP.Reconecta.Domain.Repositories
{
    public interface IBaseRepository<T>
    {
        IEnumerable<T> Get();
        T? GetById(int id);
        void Add(T entity);
        void AddRange(IEnumerable<T> entities);
        void Update(T entity);
        void Delete(int id);
    }
}

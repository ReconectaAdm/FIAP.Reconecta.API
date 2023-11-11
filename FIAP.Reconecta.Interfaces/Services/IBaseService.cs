namespace FIAP.Reconecta.Domain.Services
{
    public interface IBaseService<T>
    {
        IEnumerable<T> Get();
        T? GetById(int id);
        void Add(T entity);
        void AddRange(IEnumerable<T> entity);
        void Update(T entity);
        void Delete(int id);
    }
}

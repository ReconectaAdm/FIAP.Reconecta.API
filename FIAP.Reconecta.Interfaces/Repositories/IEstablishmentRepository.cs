using FIAP.Reconecta.Domain.Repositories;
using FIAP.Reconecta.Models.Entities.Company;

namespace FIAP.Reconecta.Interfaces.Repositories
{
    public interface IEstablishmentRepository : ICompanyRepository
    {
        new IEnumerable<Establishment> Get();
        new Establishment? GetById(int id);
    }
}

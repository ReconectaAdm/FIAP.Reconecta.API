using FIAP.Reconecta.Domain.Services;
using FIAP.Reconecta.Interfaces.Repositories;
using FIAP.Reconecta.Models.Entities.Company;

namespace FIAP.Reconecta.Services.Services
{
    public class EstablishmentService : CompanyService, IEstablishmentService
    {
        private readonly IEstablishmentRepository _establishmentRepository;
        public EstablishmentService(IEstablishmentRepository establishmentRepository)
            : base(establishmentRepository)
        {
            _establishmentRepository = establishmentRepository;
        }

        public override IEnumerable<Establishment> Get()
        {
            return _establishmentRepository.Get();
        }

        public override Establishment? GetById(int id)
        {
            return _establishmentRepository.GetById(id);
        }
    }
}

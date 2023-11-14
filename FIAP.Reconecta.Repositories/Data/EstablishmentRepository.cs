using FIAP.Reconecta.Interfaces.Repositories;
using FIAP.Reconecta.Models.Entities.Company;
using FIAP.Reconecta.Models.Enums;
using FIAP.Reconecta.Repositories.Context;
using Microsoft.EntityFrameworkCore;

namespace FIAP.Reconecta.Repositories.Data
{
    public class EstablishmentRepository : CompanyRepository, IEstablishmentRepository
    {
        private readonly DataBaseContext dataBaseContext;

        public EstablishmentRepository(DataBaseContext ctx) : base(ctx)
        {
            dataBaseContext = ctx;
        }

        public override IEnumerable<Establishment> Get()
        {
            return dataBaseContext.Establishment
                .Include(c => c.Addresses)
                .Where(c => c.Type == CompanyType.ESTABLISHMENT);
        }

        public override Establishment? GetById(int id)
        {
            return dataBaseContext.Establishment.AsNoTracking()
                .Include(c => c.Addresses)
                .Include(c => c.Collects)
                    .ThenInclude(cl => cl.Residues)
                .FirstOrDefault(e => e.Id == id && e.Type == CompanyType.ESTABLISHMENT);
        }

    }
}

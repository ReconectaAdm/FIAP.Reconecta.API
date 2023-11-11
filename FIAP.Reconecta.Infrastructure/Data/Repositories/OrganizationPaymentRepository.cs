using FIAP.Reconecta.Contracts.Models.Payment;
using FIAP.Reconecta.Contracts.Models.Residue;
using FIAP.Reconecta.Domain.Repositories;
using FIAP.Reconecta.Infrastructure.Data.Repositories.Context;
using Microsoft.EntityFrameworkCore;

namespace FIAP.Reconecta.Infrastructure.Data.Repositories
{
    public class OrganizationPaymentRepository : IOrganizationPaymentRepository
    {
        private readonly DataBaseContext dataBaseContext;

        public OrganizationPaymentRepository(DataBaseContext ctx)
        {
            dataBaseContext = ctx;
        }

        public IEnumerable<OrganizationPayment> Get()
        {
            return dataBaseContext.OrganizationPayment;
        }

        public OrganizationPayment? GetById(int id)
        {
            return dataBaseContext.OrganizationPayment.AsNoTracking().FirstOrDefault(rt => rt.Id == id);
        }

        public void Add(OrganizationPayment residue)
        {
            dataBaseContext.OrganizationPayment.Add(residue);
            dataBaseContext.SaveChanges();
        }

        public void AddRange(IEnumerable<OrganizationPayment> residue)
        {
            dataBaseContext.OrganizationPayment.AddRange(residue);
            dataBaseContext.SaveChanges();
        }

        public void Update(OrganizationPayment residue)
        {
            dataBaseContext.OrganizationPayment.Update(residue);
            dataBaseContext.SaveChanges();
        }

        public void Delete(int id)
        {
            var residue = new OrganizationPayment { Id = id };
            dataBaseContext.OrganizationPayment.Remove(residue);
            dataBaseContext.SaveChanges();
        }
    }
}

using FIAP.Reconecta.Domain.Repositories;
using FIAP.Reconecta.Models.Entities.Payment;
using FIAP.Reconecta.Repositories.Context;
using Microsoft.EntityFrameworkCore;

namespace FIAP.Reconecta.Repositories.Data
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

        public void Add(OrganizationPayment organizationPayment)
        {
            dataBaseContext.OrganizationPayment.Add(organizationPayment);
            dataBaseContext.SaveChanges();
        }

        public void AddRange(IEnumerable<OrganizationPayment> organizationPayments)
        {
            dataBaseContext.OrganizationPayment.AddRange(organizationPayments);
            dataBaseContext.SaveChanges();
        }

        public void Update(OrganizationPayment organizationPayment)
        {
            dataBaseContext.OrganizationPayment.Update(organizationPayment);
            dataBaseContext.SaveChanges();
        }

        public void Delete(int id)
        {
            var organizationPayment = new OrganizationPayment { Id = id };
            dataBaseContext.OrganizationPayment.Remove(organizationPayment);
            dataBaseContext.SaveChanges();
        }
    }
}

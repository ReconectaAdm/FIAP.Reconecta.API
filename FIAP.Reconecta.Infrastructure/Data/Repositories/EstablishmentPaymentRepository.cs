using FIAP.Reconecta.Contracts.Models.Payment;
using FIAP.Reconecta.Domain.Repositories;
using FIAP.Reconecta.Infrastructure.Data.Repositories.Context;
using Microsoft.EntityFrameworkCore;

namespace FIAP.Reconecta.Infrastructure.Data.Repositories
{
    public class EstablishmentPaymentRepository : IEstablishmentPaymentRepository
    {
        private readonly DataBaseContext dataBaseContext;

        public EstablishmentPaymentRepository(DataBaseContext ctx)
        {
            dataBaseContext = ctx;
        }

        public IEnumerable<EstablishmentPayment> Get()
        {
            return dataBaseContext.EstablishmentPayment;
        }

        public EstablishmentPayment? GetById(int id)
        {
            return dataBaseContext.EstablishmentPayment.AsNoTracking().FirstOrDefault(rt => rt.Id == id);
        }

        public void Add(EstablishmentPayment residue)
        {
            dataBaseContext.EstablishmentPayment.Add(residue);
            dataBaseContext.SaveChanges();
        }

        public void AddRange(IEnumerable<EstablishmentPayment> residue)
        {
            dataBaseContext.EstablishmentPayment.AddRange(residue);
            dataBaseContext.SaveChanges();
        }

        public void Update(EstablishmentPayment residue)
        {
            dataBaseContext.EstablishmentPayment.Update(residue);
            dataBaseContext.SaveChanges();
        }

        public void Delete(int id)
        {
            var residue = new EstablishmentPayment { Id = id };
            dataBaseContext.EstablishmentPayment.Remove(residue);
            dataBaseContext.SaveChanges();
        }
    }
}

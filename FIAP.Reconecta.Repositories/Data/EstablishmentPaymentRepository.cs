using FIAP.Reconecta.Domain.Repositories;
using FIAP.Reconecta.Models.Entities.Payment;
using FIAP.Reconecta.Repositories.Context;
using Microsoft.EntityFrameworkCore;

namespace FIAP.Reconecta.Repositories.Data
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

        public void Add(EstablishmentPayment establishmentPayment)
        {
            dataBaseContext.EstablishmentPayment.Add(establishmentPayment);
            dataBaseContext.SaveChanges();
        }

        public void AddRange(IEnumerable<EstablishmentPayment> establishmentPayments)
        {
            dataBaseContext.EstablishmentPayment.AddRange(establishmentPayments);
            dataBaseContext.SaveChanges();
        }

        public void Update(EstablishmentPayment establishmentPayment)
        {
            dataBaseContext.EstablishmentPayment.Update(establishmentPayment);
            dataBaseContext.SaveChanges();
        }

        public void Delete(int id)
        {
            var establishmentPayment = new EstablishmentPayment { Id = id };
            dataBaseContext.EstablishmentPayment.Remove(establishmentPayment);
            dataBaseContext.SaveChanges();
        }
    }
}

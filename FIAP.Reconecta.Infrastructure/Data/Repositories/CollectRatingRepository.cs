﻿using FIAP.Reconecta.Contracts.Models.Collect;
using FIAP.Reconecta.Domain.Repositories;
using FIAP.Reconecta.Infrastructure.Data.Repositories.Context;
using Microsoft.EntityFrameworkCore;

namespace FIAP.Reconecta.Infrastructure.Data.Repositories
{
    public class CollectRatingRepository : ICollectRatingRepository
    {
        private readonly DataBaseContext dataBaseContext;

        public CollectRatingRepository(DataBaseContext ctx)
        {
            dataBaseContext = ctx;
        }

        public IEnumerable<CollectRating> Get()
        {
            return dataBaseContext.CollectRating
                .Include(cr => cr.Collect)
                    .ThenInclude(c => c!.Establishment);
        }

        public CollectRating? GetById(int id)
        {
            return dataBaseContext.CollectRating.AsNoTracking().FirstOrDefault(t => t.CollectId == id);
        }

        public CollectRating? GetSummary(int organizationId)
        {
            var summary = dataBaseContext.CollectRating
                .Include(cr => cr.Collect)
                .Where(cr => cr.Collect!.OrganizationId == organizationId)
                .GroupBy(c => new { c.Collect!.OrganizationId })
                .Select(gcr => new CollectRating { 
                    Punctuality = Math.Round(gcr.Sum(cr => cr.Punctuality) / gcr.Count(), 2), 
                    Satisfaction = Math.Round(gcr.Sum(cr => cr.Satisfaction) / gcr.Count(), 2)
                });

            return summary.FirstOrDefault();
        }

        public void Add(CollectRating residue)
        {
            dataBaseContext.CollectRating.Add(residue);
            dataBaseContext.SaveChanges();
        }

        public void AddRange(IEnumerable<CollectRating> residue)
        {
            dataBaseContext.CollectRating.AddRange(residue);
            dataBaseContext.SaveChanges();
        }

        public void Update(CollectRating residue)
        {
            dataBaseContext.CollectRating.Update(residue);
            dataBaseContext.SaveChanges();
        }

        public void Delete(int id)
        {
            var residue = new CollectRating { CollectId = id };
            dataBaseContext.CollectRating.Remove(residue);
            dataBaseContext.SaveChanges();
        }
    }
}

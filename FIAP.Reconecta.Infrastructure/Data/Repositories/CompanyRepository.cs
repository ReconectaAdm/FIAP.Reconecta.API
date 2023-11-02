﻿using FIAP.Reconecta.Contracts.Models;
using FIAP.Reconecta.Domain.Repositories;
using FIAP.Reconecta.Infrastructure.Data.Repositories.Context;
using Microsoft.EntityFrameworkCore;

namespace FIAP.Reconecta.Infrastructure.Data.Repositories
{
    public class CompanyRepository : ICompanyRepository
    {
        private readonly DataBaseContext dataBaseContext;

        public CompanyRepository(DataBaseContext ctx)
        {
            dataBaseContext = ctx;
        }

        public IEnumerable<Company> Get()
        {
            return dataBaseContext.Company.Include(company => company.Enderecos);
        }

        public Company? GetById(int id)
        {
            return dataBaseContext.Company.AsNoTracking()
                .FirstOrDefault(e => e.Id == id);
        }

        public void Add(Company company)
        {
            dataBaseContext.Company.Add(company);
            dataBaseContext.SaveChanges();
        }
        public void AddRange(IEnumerable<Company> entities)
        {
            throw new NotImplementedException();
        }

        public void Update(Company company)
        {
            dataBaseContext.Company.Update(company);
            dataBaseContext.SaveChanges();
        }

        public void Delete(int id)
        {
            var company = new Company { Id = id };
            dataBaseContext.Company.Remove(company);
            dataBaseContext.SaveChanges();
        }

    }
}
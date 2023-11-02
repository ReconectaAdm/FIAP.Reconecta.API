﻿using FIAP.Reconecta.Application.Services;
using FIAP.Reconecta.Domain.Repositories;
using FIAP.Reconecta.Domain.Services;
using FIAP.Reconecta.Infrastructure.Data.Repositories;
using FIAP.Reconecta.Infrastructure.Data.Repositories.Context;
using Microsoft.Extensions.DependencyInjection;

namespace FIAP.Reconecta.Infrastructure.IoC
{
    public static class ConfigurationIoC
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddTransient<IEstablishmentService, EstablishmentService>();
            services.AddTransient<IOrganizationService, OrganizationService>();
            services.AddTransient<ICollectService, CollectService>();
            services.AddTransient<IResidueService, ResidueService>();

            return services;
        }

        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {

            services.AddTransient<ICompanyRepository>((ctx) => new CompanyRepository(ctx.GetRequiredService<DataBaseContext>()));
            services.AddTransient<ICompanyAddressRepository>((ctx) => new CompanyAddressRepository(ctx.GetRequiredService<DataBaseContext>()));
            services.AddTransient<ICollectRepository>((ctx) => new CollectRepository(ctx.GetRequiredService<DataBaseContext>()));
            services.AddTransient<IResidueRepository>((ctx) => new ResidueRepository(ctx.GetRequiredService<DataBaseContext>()));

            return services;
        }
    }
}

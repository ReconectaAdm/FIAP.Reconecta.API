﻿using FIAP.Reconecta.Application.Services;
using FIAP.Reconecta.Domain.Repositories;
using FIAP.Reconecta.Domain.Services;
using FIAP.Reconecta.Infrastructure.Data.Repositories;
using FIAP.Reconecta.Infrastructure.Data.Repositories.Context;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace FIAP.Reconecta.Infrastructure.IoC
{
    public static class ConfigurationIoC
    {
        public static IServiceCollection AddJWTAuthentication(this IServiceCollection services)
        {

            var key = Encoding.ASCII.GetBytes(Environment.GetEnvironmentVariable("JWT_SECRET")!);

            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });

            return services;
        }

        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddTransient<IEstablishmentService, EstablishmentService>();
            services.AddTransient<IOrganizationService, OrganizationService>();
            services.AddTransient<ICollectService, CollectService>();
            services.AddTransient<ICollectRatingService, CollectRatingService>();
            services.AddTransient<IResidueService, ResidueService>();
            services.AddTransient<IResidueTypeService, ResidueTypeService>();
            services.AddTransient<IUserService, UserService>();

            return services;
        }

        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddTransient<ICompanyRepository>((ctx) => new CompanyRepository(ctx.GetRequiredService<DataBaseContext>()));
            services.AddTransient<ICollectRepository>((ctx) => new CollectRepository(ctx.GetRequiredService<DataBaseContext>()));
            services.AddTransient<ICollectRatingRepository>((ctx) => new CollectRatingRepository(ctx.GetRequiredService<DataBaseContext>()));
            services.AddTransient<IResidueRepository>((ctx) => new ResidueRepository(ctx.GetRequiredService<DataBaseContext>()));
            services.AddTransient<IResidueTypeRepository>((ctx) => new ResidueTypeRepository(ctx.GetRequiredService<DataBaseContext>()));
            services.AddTransient<IUserRepository>((ctx) => new UserRepository(ctx.GetRequiredService<DataBaseContext>()));

            return services;
        }
    }
}

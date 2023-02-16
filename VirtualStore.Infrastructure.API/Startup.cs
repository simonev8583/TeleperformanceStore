using VirtualStore.Infrastructure.Providers.Encrypt.Config;
using VirtualStore.Infrastructure.Providers.Jwt.Config;
using VirtualStore.Infrastructure.Providers.Encrypt;
using VirtualStore.Infrastructure.Data.Repositories;
using VirtualStore.Infrastructure.Providers.Jwt;
using VirtualStore.Infrastructure.Data.Context;
using VirtualStore.Application.Interfaces;
using VirtualStore.Application.Services;
using VirtualStore.Domain.Interfaces;
using VirtualStore.Application.Dtos;
using VirtualStore.Domain.Models;
using System;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace VirtualStore.Infrastructure.API
{
    public class Startup
    {

        public void ConfigureContainer(IServiceCollection services, ConfigurationManager configuration)
        {

            ConfigureSettings(services, configuration);
            ConfigureDbContext(services);
            ConfigureRepositories(services);
            ConfigureServices(services);
            ConfigureProviders(services);
        }

        protected void ConfigureProviders(IServiceCollection services)
        {
            services.AddSingleton<IPasswordEncryption, EncryptService>();
            services.AddSingleton<IAuthenticateService, JwtService>();
        }

        protected void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<IPersonService<PersonDto>, PersonService>();
            services.AddSingleton<ISecurityService, SecurityService>();
        }

        protected void ConfigureRepositories(IServiceCollection services)
        {
            services.AddSingleton<IPersonRepository<Person>, PersonRepository>(x =>
            {
                var db = x.GetRequiredService<DbContext>();
                return new PersonRepository(db);
            });
        }

        protected void ConfigureDbContext(IServiceCollection services)
        {
            services.AddTransient<DbContext>();
        }

        protected void ConfigureSettings(IServiceCollection services, ConfigurationManager configuration)
        {
            services.Configure<GeneralSettings>(configuration.GetSection("SettingsMongoDatabase"));
            services.Configure<EncryptSettings>(configuration.GetSection("EncryptionSettings"));
            services.Configure<JwtSettings>(configuration.GetSection("JwtSettings"));

        }
    }
}


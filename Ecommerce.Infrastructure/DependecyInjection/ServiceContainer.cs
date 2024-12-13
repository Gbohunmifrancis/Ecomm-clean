using Ecommerce.Domain.Entities;
using Ecommerce.Domain.Interfaces;
using Ecommerce.Infrastructure.Data;
using Ecommerce.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Ecommerce.Infrastructure.DependencyInjection
{
    public static class ServiceContainer
    {
        public static IServiceCollection AddInfrastructureService(
            this IServiceCollection services, IConfiguration config)
        {
            string connectionString = "Default";

            services.AddDbContext<AppDbContext>(options =>
                    options.UseSqlServer(
                        config.GetConnectionString(connectionString),
                        sqlOptions =>
                        {
                            sqlOptions.MigrationsAssembly(typeof(AppDbContext).Assembly.FullName);
                            sqlOptions.EnableRetryOnFailure(); // Enable automatic retries for transient failures
                        }),
                ServiceLifetime.Scoped);
            
            
            services.AddScoped<IGeneric<Product>, GenericRepository<Product>>();
            
            services.AddScoped<IGeneric<Category>, GenericRepository<Category>>();
            return services;
        }
    }
}
using BindyStreet.Application.Repositories;
using BindyStreet.Persistence.Context;
using BindyStreet.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BindyStreet.Persistence.Extensions
{
    public static class IServiceCollectionExtensions
    {
        public static IServiceCollection AddPersistenceLayer(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext(configuration);
            services.AddRepositories();

            return services;
        }
        public static void AddDbContext(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<BindyStreetContext>(options =>
               options.UseSqlServer(
                   configuration.GetConnectionString("BindyStreetContext"),
                   b => b.MigrationsAssembly(typeof(BindyStreetContext).Assembly.FullName)), ServiceLifetime.Scoped);

        }

        private static void AddRepositories(this IServiceCollection services)
        {
            services
                .AddScoped(typeof(IUnitOfWork), typeof(UnitOfWork))
                .AddScoped(typeof(IRepository<>), typeof(Repository<>))
                .AddScoped<IUserRepository, UserRepository>();
        }
    }
}

using BindyStreet.Application.Repositories;
using BindyStreet.Persistence.Context;
using BindyStreet.Persistence.Repositories;
using BindyStreet.Persistence.Settings;
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
            services.AddMongo(configuration);
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

        public static void AddMongo(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<Mongosettings>(options =>
            {
                options.Connection = configuration.GetSection("MongoSettings:Connection").Value;
                options.DatabaseName = configuration.GetSection("MongoSettings:DatabaseName").Value;

            });
            services.AddTransient<IMongoBookDBContext, MongoBookDBContext>();
        }

        private static void AddRepositories(this IServiceCollection services)
        {
            services
                .AddScoped(typeof(IUnitOfWork), typeof(UnitOfWork))
                .AddScoped(typeof(IRepository<>), typeof(Repository<>))
                .AddScoped(typeof(IRepository<>), typeof(MongoRepository<>))
                .AddScoped<IUserRepository, UserRepository>()
                .AddScoped<IPostRepository, PostRepository>()
                .AddScoped<IPostCommentRepository, PostCommentRepository>();
        }
    }
}

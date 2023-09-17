using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using BindyStreet.Persistence.Context;
using BindyStreet.Persistence.Extensions;

namespace BindyStreet.Persistence.Factory
{
    public class BindyStreetContextFactory : IDesignTimeDbContextFactory<BindyStreetContext>
    {
        public BindyStreetContext CreateDbContext(string[] args)
        {
            // Build config
            IConfiguration config = new ConfigurationBuilder()
                .AddBasePath()
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .Build();

            var optionsBuilder = new DbContextOptionsBuilder<BindyStreetContext>();
            var connectionString = config.GetConnectionString(nameof(BindyStreetContext));
            optionsBuilder.UseSqlServer(connectionString, b => b.MigrationsAssembly("BindyStreet.Persistence"));
            return new BindyStreetContext(optionsBuilder.Options);
        }
    }
}

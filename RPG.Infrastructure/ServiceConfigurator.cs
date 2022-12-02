using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RPG.Application.Services;
using RPG.Domain.Model.General;
using RPG.Infrastructure.DataAccess;
using RPG.Infrastructure.DataAccess.Repository;
using RPG.Infrastructure.Services;

namespace RPG.Infrastructure
{
    public static class ServiceConfigurator
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            // AddEntity Database
            string? databaseConnectionString = configuration.GetConnectionString("DatabaseConnection");
            if (databaseConnectionString == null) throw new Exception("Database connection string not found!");
            services.AddDbContext<DataContext>(options => options.UseSqlServer(databaseConnectionString));

            // AddEntity Services
            services.AddScoped<IWeaponService, WeaponService>();

            services.AddScoped<IRepository<StaffMember>, Repository<StaffMember>>();

            services.AddScoped<IUnitOfWork, UnitOfWork>();

            return services;
        }
    }
}

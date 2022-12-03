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
            services.AddAutoMapper(typeof(ServiceConfigurator).Assembly);

            // Add Database
            string? databaseConnectionString = configuration.GetConnectionString("DatabaseConnection");
            if (databaseConnectionString == null) throw new NullReferenceException(nameof(databaseConnectionString));
            services.AddDbContext<DataContext>(options => options.UseSqlServer(databaseConnectionString));

            // Add Repositories
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            // Add Services
            services.AddScoped<IStaffMemberService, StaffMemberService>();
            services.AddScoped<IWeaponService, WeaponService>();

            return services;
        }
    }
}

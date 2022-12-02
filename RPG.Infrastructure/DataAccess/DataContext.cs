using Microsoft.EntityFrameworkCore;
using RPG.Domain.Model;

namespace RPG.Infrastructure.DataAccess
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Weapon> Weapons { get; set; }

    }
}
// dotnet ef migrations add MigrationName --project .\RPG.Infrastructure\ -s .\RPG.API.User\
// dotnet ef database update --project .\RPG.Infrastructure\ -s .\RPG.API.User\
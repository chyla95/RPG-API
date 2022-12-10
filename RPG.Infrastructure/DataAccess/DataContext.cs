using Microsoft.EntityFrameworkCore;
using RPG.Domain.Model.Game;
using RPG.Domain.Model.General;

namespace RPG.Infrastructure.DataAccess
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<Player> Players { get; set; }
        public DbSet<PlayerCharacter> PlayerCharacters { get; set; }
        public DbSet<Class> Classes { get; set; }
        public DbSet<NonPlayerCharacter> NonPlayerCharacters { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<Weapon> Weapons { get; set; }
        public DbSet<DailyQuest> DailyQuests { get; set; }


        public DbSet<Staff> Staff { get; set; }
        public DbSet<Role> Roles { get; set; }


    }
}
// dotnet ef migrations add MigrationName --project .\RPG.Infrastructure\ -s .\RPG.API.Public\
// dotnet ef database update --project .\RPG.Infrastructure\ -s .\RPG.API.Public\
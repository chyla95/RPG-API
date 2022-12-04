using RPG.Application.Repository;

namespace RPG.Infrastructure.DataAccess.Repository
{
    internal class UnitOfWork : IUnitOfWork
    {
        private readonly DataContext _dataContext;

        public IStaffRepository StaffRepository { get; private set; }
        public IRoleRepository RoleRepository { get; private set; }

        public UnitOfWork(DataContext dataContext)
        {
            _dataContext = dataContext;

            StaffRepository = new StaffRepository(_dataContext);
            RoleRepository = new RoleRepository(_dataContext);
        }

        public async Task SaveChanges()
        {
            await _dataContext.SaveChangesAsync();
        }
    }
}

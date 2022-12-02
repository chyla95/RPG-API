using RPG.Domain.Model.General;

namespace RPG.Infrastructure.DataAccess.Repository
{
    internal class UnitOfWork : IUnitOfWork
    {
        private readonly DataContext _dataContext;

        public IRepository<StaffMember> Staff { get; private set; }

        public UnitOfWork(DataContext dataContext)
        {
            _dataContext = dataContext;
            Staff = new Repository<StaffMember>(_dataContext);
        }

        public async Task SaveChanges()
        {
            await _dataContext.SaveChangesAsync();
        }
    }
}

using RPG.Application.Repository;

namespace RPG.Infrastructure.DataAccess.Repository
{
    public interface IUnitOfWork
    {
        IStaffRepository StaffRepository { get; }
        IRoleRepository RoleRepository { get; }

        Task SaveChanges();
    }
}

using RPG.Application.Repository;

namespace RPG.Infrastructure.DataAccess.Repository
{
    public interface IUnitOfWork
    {
        IStaffRepository StaffRepository { get; }
        IRoleRepository RoleRepository { get; }
        IWeaponRepository WeaponRepository { get; }
        IClassRepository ClassRepository { get; }

        Task SaveChanges();
    }
}

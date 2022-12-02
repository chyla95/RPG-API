using RPG.Domain.Model.General;

namespace RPG.Infrastructure.DataAccess.Repository
{
    public interface IUnitOfWork
    {
        IRepository<StaffMember> Staff { get; }

        Task SaveChanges();
    }
}

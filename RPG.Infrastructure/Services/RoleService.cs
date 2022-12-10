using RPG.Application.Services;
using RPG.Domain.Model.Game;
using RPG.Domain.Model.General;
using RPG.Infrastructure.DataAccess.Repository;

namespace RPG.Infrastructure.Services
{
    internal class RoleService : IRoleService
    {
        private readonly IUnitOfWork _unitOfWork;

        public RoleService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Role>> GetMany()
        {
            IEnumerable<Role> roles = await _unitOfWork.RoleRepository.GetMany();
            return roles;
        }

        public async Task<Role?> GetOne(int id)
        {
            Role? role = await _unitOfWork.RoleRepository.GetOne(r => r.Id == id);
            return role;
        }

        public async Task<Role?> GetOne(string name)
        {
            Role? role = await _unitOfWork.RoleRepository.GetOne(r => r.Name == name);
            return role;
        }

        public async Task AddOne(Role role)
        {
            _unitOfWork.RoleRepository.AddOne(role);
            await _unitOfWork.SaveChanges();
        }

        public async Task UpdateOne(Role role)
        {
            _unitOfWork.RoleRepository.UpdateOne(role);
            await _unitOfWork.SaveChanges();
        }

        public async Task RemoveOne(Role role)
        {
            _unitOfWork.RoleRepository.RemoveOne(role);
            await _unitOfWork.SaveChanges();
        }

        public async Task<bool> IsNameTaken(string name, int? entityId = null)
        {
            Role? role;
            if (entityId != null) role = await _unitOfWork.RoleRepository.GetOne(r => (r.Name == name) && (r.Id != entityId));
            else role = await _unitOfWork.RoleRepository.GetOne(u => u.Name == name);

            if (role != null) return true;
            return false;
        }
    }
}

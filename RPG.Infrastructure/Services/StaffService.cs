using RPG.Application.Services;
using RPG.Domain.Model.General;
using RPG.Infrastructure.DataAccess.Repository;

namespace RPG.Infrastructure.Services
{
    internal class StaffService : IStaffService
    {
        private readonly IUnitOfWork _unitOfWork;

        public StaffService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Staff>> GetMany()
        {
            IEnumerable<Staff> staff = await _unitOfWork.StaffRepository.GetMany();
            return staff;
        }

        public async Task<Staff?> GetOne(int id)
        {
            Staff? staffMember = await _unitOfWork.StaffRepository.GetOne(u => u.Id == id, "Roles");
            return staffMember;
        }
        public async Task<Staff?> GetOne(string email)
        {
            Staff? staffMember = await _unitOfWork.StaffRepository.GetOne(u => u.Email == email, "Roles");
            return staffMember;
        }

        public async Task AddOne(Staff user)
        {
            _unitOfWork.StaffRepository.AddOne(user);
            await _unitOfWork.SaveChanges();
        }

        public async Task UpdateOne(Staff user)
        {
            _unitOfWork.StaffRepository.UpdateOne(user);
            await _unitOfWork.SaveChanges();
        }

        public async Task RemoveOne(Staff user)
        {
            _unitOfWork.StaffRepository.RemoveOne(user);
            await _unitOfWork.SaveChanges();
        }

        public async Task<bool> IsEmailTaken(string email, int? entityId = null)
        {
            Staff? staffMember;
            if(entityId != null) staffMember = await _unitOfWork.StaffRepository.GetOne(u => (u.Email == email) && (u.Id != entityId));
            else staffMember = await _unitOfWork.StaffRepository.GetOne(u => u.Email == email);

            if (staffMember != null) return true;
            return false;
        }
    }
}

using RPG.Application.Services;
using RPG.Domain.Model.Game;
using RPG.Infrastructure.DataAccess.Repository;

namespace RPG.Infrastructure.Services
{
    public class WeaponService : IWeaponService
    {
        private readonly IUnitOfWork _unitOfWork;

        public WeaponService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Weapon>> GetMany()
        {
            IEnumerable<Weapon> weapon = await _unitOfWork.WeaponRepository.GetMany("Class");
            return weapon;
        }

        public async Task<Weapon?> GetOne(int id)
        {
            Weapon? weapon = await _unitOfWork.WeaponRepository.GetOne(u => u.Id == id, "Class");
            return weapon;
        }
        public async Task<Weapon?> GetOne(string name)
        {
            Weapon? weapon = await _unitOfWork.WeaponRepository.GetOne(u => u.Name == name);
            return weapon;
        }

        public async Task AddOne(Weapon weapon)
        {
            _unitOfWork.WeaponRepository.AddOne(weapon);
            await _unitOfWork.SaveChanges();
        }

        public async Task UpdateOne(Weapon weapon)
        {
            _unitOfWork.WeaponRepository.UpdateOne(weapon);
            await _unitOfWork.SaveChanges();
        }

        public async Task RemoveOne(Weapon weapon)
        {
            _unitOfWork.WeaponRepository.RemoveOne(weapon);
            await _unitOfWork.SaveChanges();
        }

        public async Task<bool> IsNameTaken(string name, int? entityId = null)
        {
            Weapon? weapon;
            if (entityId != null) weapon = await _unitOfWork.WeaponRepository.GetOne(c => (c.Name == name) && (c.Id != entityId));
            else weapon = await _unitOfWork.WeaponRepository.GetOne(u => u.Name == name);

            if (weapon != null) return true;
            return false;
        }
    }
}

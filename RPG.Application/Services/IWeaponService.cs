using RPG.Domain.Model;

namespace RPG.Application.Services
{
    public interface IWeaponService
    {
        Task<Weapon> GetWeapon(int id);
    }
}

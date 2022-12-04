using RPG.Domain.Model.Game;

namespace RPG.Application.Services
{
    public interface IWeaponService
    {
        Task<Weapon?> GetWeapon(int id);
    }
}

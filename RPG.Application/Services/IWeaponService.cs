using RPG.Domain.Model.Game;

namespace RPG.Application.Services
{
    public interface IWeaponService: IService<Weapon>
    {
        Task<Weapon?> GetOne(string name);

        Task<bool> IsNameTaken(string name, int? entityId = null);
    }
}

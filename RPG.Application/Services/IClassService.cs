using RPG.Domain.Model.Game;
using RPG.Domain.Model.General;

namespace RPG.Application.Services
{
    public interface IClassService : IService<Class>
    {
        Task<Class?> GetOne(string name);
    }
}

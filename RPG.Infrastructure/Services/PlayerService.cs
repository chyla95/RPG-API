using RPG.Application.Services;
using RPG.Domain.Model.Game;
using RPG.Infrastructure.DataAccess.Repository;

namespace RPG.Infrastructure.Services
{
    internal class PlayerService : IPlayerService
    {
        private readonly IUnitOfWork _unitOfWork;

        public PlayerService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Player>> GetMany()
        {
            IEnumerable<Player> player = await _unitOfWork.PlayerRepository.GetMany("Characters, Characters.Class, Characters.Weapon");
            return player;
        }

        public async Task<Player?> GetOne(int id)
        {
            Player? player = await _unitOfWork.PlayerRepository.GetOne(u => u.Id == id, "Characters, Characters.Class, Characters.Weapon");
            return player;
        }

        public async Task<Player?> GetOne(string email)
        {
            Player? player = await _unitOfWork.PlayerRepository.GetOne(u => u.Email == email, "Characters, Characters.Class, Characters.Weapon");
            return player;
        }

        public async Task AddOne(Player player)
        {
            _unitOfWork.PlayerRepository.AddOne(player);
            await _unitOfWork.SaveChanges();
        }

        public async Task UpdateOne(Player player)
        {
            _unitOfWork.PlayerRepository.UpdateOne(player);
            await _unitOfWork.SaveChanges();
        }

        public async Task RemoveOne(Player player)
        {
            _unitOfWork.PlayerRepository.RemoveOne(player);
            await _unitOfWork.SaveChanges();
        }

        public async Task<bool> IsEmailTaken(string email, int? entityId = null)
        {
            Player? player;
            if (entityId != null) player = await _unitOfWork.PlayerRepository.GetOne(u => (u.Email == email) && (u.Id != entityId));
            else player = await _unitOfWork.PlayerRepository.GetOne(u => u.Email == email);

            if (player != null) return true;
            return false;
        }
    }
}

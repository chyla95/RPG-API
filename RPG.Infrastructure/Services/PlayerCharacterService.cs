using RPG.Application.Services;
using RPG.Domain.Model.Game;
using RPG.Domain.Model.General;
using RPG.Infrastructure.DataAccess.Repository;

namespace RPG.Infrastructure.Services
{
    internal class PlayerCharacterService : IPlayerCharacterService
    {
        private readonly IUnitOfWork _unitOfWork;

        public PlayerCharacterService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<PlayerCharacter>> GetMany()
        {
            IEnumerable<PlayerCharacter> PlayerCharacter = await _unitOfWork.PlayerCharacterRepository.GetMany("Class, Weapon");
            return PlayerCharacter;
        }

        public async Task<PlayerCharacter?> GetOne(int id)
        {
            PlayerCharacter? PlayerCharacter = await _unitOfWork.PlayerCharacterRepository.GetOne(r => r.Id == id, "Class, Weapon");
            return PlayerCharacter;
        }

        public async Task<PlayerCharacter?> GetOne(string name)
        {
            PlayerCharacter? playerCharacter = await _unitOfWork.PlayerCharacterRepository.GetOne(r => r.Name == name, "Class, Weapon");
            return playerCharacter;
        }

        public async Task AddOne(PlayerCharacter playerCharacter)
        {
            _unitOfWork.PlayerCharacterRepository.AddOne(playerCharacter);
            await _unitOfWork.SaveChanges();
        }

        public async Task UpdateOne(PlayerCharacter playerCharacter)
        {
            _unitOfWork.PlayerCharacterRepository.UpdateOne(playerCharacter);
            await _unitOfWork.SaveChanges();
        }

        public async Task RemoveOne(PlayerCharacter playerCharacter)
        {
            _unitOfWork.PlayerCharacterRepository.RemoveOne(playerCharacter);
            await _unitOfWork.SaveChanges();
        }

        public async Task<bool> IsNameTaken(string name, int? entityId = null)
        {
            PlayerCharacter? playerCharacter;
            if (entityId != null) playerCharacter = await _unitOfWork.PlayerCharacterRepository.GetOne(c => (c.Name == name) && (c.Id != entityId));
            else playerCharacter = await _unitOfWork.PlayerCharacterRepository.GetOne(u => u.Name == name);

            if (playerCharacter != null) return true;
            return false;
        }
    }
}

using RPG.Application.Services;
using RPG.Domain.Model.Game;
using RPG.Domain.Model.General;
using RPG.Infrastructure.DataAccess.Repository;

namespace RPG.Infrastructure.Services
{
    internal class NonPlayerCharacterService : INonPlayerCharacterService
    {
        private readonly IUnitOfWork _unitOfWork;

        public NonPlayerCharacterService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<NonPlayerCharacter>> GetMany()
        {
            IEnumerable<NonPlayerCharacter> nonPlayerCharacter = await _unitOfWork.NonPlayerCharacterRepository.GetMany("Weapon");
            return nonPlayerCharacter;
        }

        public async Task<NonPlayerCharacter?> GetOne(int id)
        {
            NonPlayerCharacter? nonPlayerCharacter = await _unitOfWork.NonPlayerCharacterRepository.GetOne(r => r.Id == id, "Weapon");
            return nonPlayerCharacter;
        }

        public async Task<NonPlayerCharacter?> GetOne(string name)
        {
            NonPlayerCharacter? nonPlayerCharacter = await _unitOfWork.NonPlayerCharacterRepository.GetOne(r => r.Name == name);
            return nonPlayerCharacter;
        }

        public async Task AddOne(NonPlayerCharacter nonPlayerCharacter)
        {
            _unitOfWork.NonPlayerCharacterRepository.AddOne(nonPlayerCharacter);
            await _unitOfWork.SaveChanges();
        }

        public async Task UpdateOne(NonPlayerCharacter nonPlayerCharacter)
        {
            _unitOfWork.NonPlayerCharacterRepository.UpdateOne(nonPlayerCharacter);
            await _unitOfWork.SaveChanges();
        }

        public async Task RemoveOne(NonPlayerCharacter nonPlayerCharacter)
        {
            _unitOfWork.NonPlayerCharacterRepository.RemoveOne(nonPlayerCharacter);
            await _unitOfWork.SaveChanges();
        }
    }
}

using RPG.Application.Services;
using RPG.Domain.Model.Game;
using RPG.Infrastructure.DataAccess.Repository;

namespace RPG.Infrastructure.Services
{
    public class ClassService : IClassService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ClassService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Class>> GetMany()
        {
            IEnumerable<Class> classes = await _unitOfWork.ClassRepository.GetMany();
            return classes;
        }

        public async Task<Class?> GetOne(int id)
        {
            Class? @class = await _unitOfWork.ClassRepository.GetOne(u => u.Id == id);
            return @class;
        }

        public async Task<Class?> GetOne(string name)
        {
            Class? @class = await _unitOfWork.ClassRepository.GetOne(u => u.Name == name);
            return @class;
        }

        public async Task AddOne(Class @class)
        {
            _unitOfWork.ClassRepository.AddOne(@class);
            await _unitOfWork.SaveChanges();
        }

        public async Task UpdateOne(Class @class)
        {
            _unitOfWork.ClassRepository.UpdateOne(@class);
            await _unitOfWork.SaveChanges();
        }

        public async Task RemoveOne(Class @class)
        {
            _unitOfWork.ClassRepository.RemoveOne(@class);
            await _unitOfWork.SaveChanges();
        }


    }
}

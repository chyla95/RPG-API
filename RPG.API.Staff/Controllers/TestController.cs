using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RPG.Application.Services;
using RPG.Domain.Model.Game;
using RPG.Domain.Model.General;
using RPG.Infrastructure.DataAccess;
using RPG.Infrastructure.DataAccess.Repository;

namespace RPG.API.Staff.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        private readonly IWeaponService _weaponService;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<Domain.Model.General.StaffMember> _repository;
        private readonly DataContext _dataContext;

        public TestController(IWeaponService weaponService, IUnitOfWork unitOfWork, IRepository<Domain.Model.General.StaffMember> repository, DataContext dataContext)
        {
            _weaponService = weaponService;
            _unitOfWork = unitOfWork;
            _repository = repository;
            _dataContext = dataContext;
        }

        [HttpGet("Test")]
        public async Task<IActionResult> Test()
        {
            Weapon weapon = await _weaponService.GetWeapon(1);
            return Ok(weapon);
        }

        [HttpGet("Staff")]
        public async Task<IActionResult> Test2()
        {
            //ICollection<Domain.Model.General.Staff> res = await _unitOfWork.Staff.GetEntities("Role");


            StaffMember res = await _repository.GetEntity(u => u.Id == 1, "Roles");
            //var res = await _dataContext.Staff.Include("Role").ToListAsync();
            return Ok(res);
        }
    }
}

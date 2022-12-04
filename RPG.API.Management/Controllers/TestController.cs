using System.Diagnostics;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RPG.API.Management.Utilities;
using RPG.Application.Services;
using RPG.Domain.Exceptions;
using RPG.Domain.Model.Game;
using RPG.Domain.Model.General;
using RPG.Infrastructure.DataAccess.Repository;

namespace RPG.API.Management.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        private readonly IWeaponService _weaponService;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICurrentUser _currentUser;

        public TestController(IWeaponService weaponService, IUnitOfWork unitOfWork, ICurrentUser currentUser)
        {
            _weaponService = weaponService;
            _unitOfWork = unitOfWork;
            _currentUser = currentUser;
        }

        [Authorize]
        [HttpGet("Test")]
        public async Task<IActionResult> Test()
        {
            Debug.WriteLine(_currentUser.GetCurrentUser().Id + " / " + _currentUser.GetCurrentUser().Roles.ToList().Count);
            Weapon? weapon = await _weaponService.GetWeapon(1);
            if (weapon == null) throw new HttpNotFoundException("Weapon not found!");
            return Ok(weapon);
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using RPG.Application.Services;
using RPG.Domain.Exceptions;
using RPG.Domain.Model.Game;

namespace RPG.API.User.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TestController : ControllerBase
    {
        private readonly IWeaponService _weaponService;

        public TestController(IWeaponService weaponService)
        {
            _weaponService = weaponService;
        }

        [HttpGet("Test")]
        public async Task<IActionResult> Test()
        {
            Weapon? weapon = await _weaponService.GetWeapon(1);
            if (weapon == null) throw new HttpNotFoundException("Weapon not found!");
            return Ok(weapon);
        }
    }

}
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RPG.Application.Services;
using RPG.Domain.Dtos.Weapon;
using RPG.Domain.Exceptions;
using RPG.Domain.Model.Game;

namespace RPG.API.Management.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class WeaponController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IWeaponService _weaponService;
        private readonly IClassService _classService;

        public WeaponController(IMapper mapper, IWeaponService weaponService, IClassService classService)
        {
            _mapper = mapper;
            _weaponService = weaponService;
            _classService = classService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<WeaponResponseDto>>> GetMany()
        {
            IEnumerable<Weapon> weapons = await _weaponService.GetMany();

            IEnumerable<WeaponResponseDto> response = _mapper.Map<IEnumerable<WeaponResponseDto>>(weapons);
            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<WeaponResponseDto>> GetOne(int id)
        {
            Weapon? weapon = await _weaponService.GetOne(id);
            if (weapon == null) throw new HttpNotFoundException("Weapon not found!");

            WeaponResponseDto response = _mapper.Map<WeaponResponseDto>(weapon);
            return Ok(response);
        }

        [HttpPost]
        public async Task<ActionResult<WeaponResponseDto>> AddOne(WeaponRequestDto weaponRequestDto)
        {
            Weapon weapon = _mapper.Map<Weapon>(weaponRequestDto);
            Class? @class = await _classService.GetOne(weaponRequestDto.ClassId);
            if (@class == null) throw new HttpNotFoundException("Class not found!");

            weapon.Class = @class;
            await _weaponService.AddOne(weapon);

            WeaponResponseDto response = _mapper.Map<WeaponResponseDto>(weapon);
            return Ok(response);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<WeaponResponseDto>> UpdateOne(int id, WeaponRequestDto weaponRequestDto)
        {
            Weapon? weapon = await _weaponService.GetOne(id);
            if (weapon == null) throw new HttpNotFoundException("Weapon not found!");
            Class? @class = await _classService.GetOne(weaponRequestDto.ClassId);
            if (@class == null) throw new HttpNotFoundException("Class not found!");

            Weapon updatedWeapon = _mapper.Map(_mapper.Map<Weapon>(weaponRequestDto), weapon);
            updatedWeapon.Class = @class;
            await _weaponService.UpdateOne(updatedWeapon);

            WeaponResponseDto response = _mapper.Map<WeaponResponseDto>(weapon);
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> RemoveOne(int id)
        {
            Weapon? weapon = await _weaponService.GetOne(id);
            if (weapon == null) throw new HttpNotFoundException("Weapon not found!");

            await _weaponService.RemoveOne(weapon);

            return NoContent();
        }
    }
}

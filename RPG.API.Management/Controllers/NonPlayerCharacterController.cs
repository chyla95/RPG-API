using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RPG.Application.Services;
using RPG.Domain.Dtos.NonPlayerCharacter;
using RPG.Domain.Dtos.Staff;
using RPG.Domain.Dtos.Weapon;
using RPG.Domain.Exceptions;
using RPG.Domain.Model.Game;
using RPG.Domain.Model.General;

namespace RPG.API.Management.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class NonPlayerCharacterController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly INonPlayerCharacterService _nonPlayerCharacterService;
        private readonly IWeaponService _weaponService;

        public NonPlayerCharacterController(IMapper mapper, INonPlayerCharacterService nonPlayerCharacterService, IWeaponService weaponService)
        {
            _mapper = mapper;
            _nonPlayerCharacterService = nonPlayerCharacterService;
            _weaponService = weaponService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<NonPlayerCharacterResponseDto>>> GetMany()
        {
            IEnumerable<NonPlayerCharacter> nonPlayerCharacter = await _nonPlayerCharacterService.GetMany();

            IEnumerable<NonPlayerCharacterResponseDto> response = _mapper.Map<IEnumerable<NonPlayerCharacterResponseDto>>(nonPlayerCharacter);
            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<NonPlayerCharacterResponseDto>> GetOne(int id)
        {
            NonPlayerCharacter? nonPlayerCharacter = await _nonPlayerCharacterService.GetOne(id);
            if (nonPlayerCharacter == null) throw new HttpNotFoundException("NPC not found!");

            NonPlayerCharacterResponseDto response = _mapper.Map<NonPlayerCharacterResponseDto>(nonPlayerCharacter);
            return Ok(response);
        }

        [HttpPost]
        public async Task<ActionResult<NonPlayerCharacterResponseDto>> AddOne(NonPlayerCharacterRequestDto nonPlayerCharacterRequestDto)
        {
            NonPlayerCharacter? isNameTaken = await _nonPlayerCharacterService.GetOne(nonPlayerCharacterRequestDto.Name);
            if (isNameTaken != null) throw new HttpBadRequestException("NPC with this name already exists!");

            NonPlayerCharacter nonPlayerCharacter = _mapper.Map<NonPlayerCharacter>(nonPlayerCharacterRequestDto);
            if (nonPlayerCharacterRequestDto.WeaponId != null)
            {
                Weapon? weapon = await _weaponService.GetOne((int)nonPlayerCharacterRequestDto.WeaponId);
                if (weapon == null) throw new HttpNotFoundException("Weapon not found!");

                nonPlayerCharacter.Weapon = weapon;
            }
            await _nonPlayerCharacterService.AddOne(nonPlayerCharacter);

            NonPlayerCharacterResponseDto response = _mapper.Map<NonPlayerCharacterResponseDto>(nonPlayerCharacter);
            return Ok(response);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<NonPlayerCharacterResponseDto>> UpdateOne(int id, NonPlayerCharacterRequestDto nonPlayerCharacterRequestDto)
        {
            NonPlayerCharacter? nonPlayerCharacter = await _nonPlayerCharacterService.GetOne(id);
            if (nonPlayerCharacter == null) throw new HttpNotFoundException("NPC not found!");

            NonPlayerCharacter? isNameTaken = await _nonPlayerCharacterService.GetOne(nonPlayerCharacterRequestDto.Name);
            if (isNameTaken != null) throw new HttpBadRequestException("NPC with this name already exists!");

            NonPlayerCharacter updatedNonPlayerCharacter = _mapper.Map(_mapper.Map<NonPlayerCharacter>(nonPlayerCharacterRequestDto), nonPlayerCharacter);
            if (nonPlayerCharacterRequestDto.WeaponId != null)
            {
                Weapon? weapon = await _weaponService.GetOne((int)nonPlayerCharacterRequestDto.WeaponId);
                if (weapon == null) throw new HttpNotFoundException("Weapon not found!");

                updatedNonPlayerCharacter.Weapon = weapon;
            }
            await _nonPlayerCharacterService.UpdateOne(_mapper.Map(updatedNonPlayerCharacter, nonPlayerCharacter));

            NonPlayerCharacterResponseDto response = _mapper.Map<NonPlayerCharacterResponseDto>(nonPlayerCharacter);
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> RemoveOne(int id)
        {
            NonPlayerCharacter? nonPlayerCharacter = await _nonPlayerCharacterService.GetOne(id);
            if (nonPlayerCharacter == null) throw new HttpNotFoundException("NPC not found!");

            await _nonPlayerCharacterService.RemoveOne(nonPlayerCharacter);

            return NoContent();
        }
    }
}

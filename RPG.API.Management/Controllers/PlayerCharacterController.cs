using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RPG.Application.Services;
using RPG.Domain.Dtos.Class;
using RPG.Domain.Dtos.PlayerCharacter;
using RPG.Domain.Exceptions;
using RPG.Domain.Model.Game;

namespace RPG.API.Management.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlayerCharacterController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IPlayerCharacterService _playerCharacterService;

        public PlayerCharacterController(IMapper mapper, IPlayerCharacterService playerCharacterService)
        {
            _mapper = mapper;
            _playerCharacterService = playerCharacterService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<PlayerCharacterResponseDto>>> GetMany()
        {
            IEnumerable<PlayerCharacter> playerCharacters = await _playerCharacterService.GetMany();

            IEnumerable<PlayerCharacterResponseDto> response = _mapper.Map<IEnumerable<PlayerCharacterResponseDto>>(playerCharacters);
            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PlayerCharacterResponseDto>> GetOne(int id)
        {
            PlayerCharacter? playerCharacter = await _playerCharacterService.GetOne(id);
            if (playerCharacter == null) throw new HttpNotFoundException("Character not found!");

            PlayerCharacterResponseDto response = _mapper.Map<PlayerCharacterResponseDto>(playerCharacter);
            return Ok(response);
        }


        [HttpPut("{id}")]
        public async Task<ActionResult<PlayerCharacterResponseDto>> UpdateOne(int id, PlayerCharacterRequestDto playerCharacterRequestDto)
        {
            bool isNameTaken = await _playerCharacterService.IsNameTaken(playerCharacterRequestDto.Name, id);
            if (isNameTaken) throw new HttpBadRequestException("Character with this name already exists!");

            PlayerCharacter? playerCharacter = await _playerCharacterService.GetOne(id);
            if (playerCharacter == null) throw new HttpNotFoundException("Character not found!");

            _mapper.Map(playerCharacterRequestDto, playerCharacter);
            await _playerCharacterService.UpdateOne(playerCharacter);

            PlayerCharacterResponseDto response = _mapper.Map<PlayerCharacterResponseDto>(playerCharacter);
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> RemoveOne(int id)
        {
            PlayerCharacter? playerCharacter = await _playerCharacterService.GetOne(id);
            if (playerCharacter == null) throw new HttpNotFoundException("Character not found!");

            await _playerCharacterService.RemoveOne(playerCharacter);

            return NoContent();
        }
    }
}

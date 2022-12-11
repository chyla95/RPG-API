using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RPG.API.Public.Utilities;
using RPG.Application.Services;
using RPG.Domain.Dtos.PlayerCharacter;
using RPG.Domain.Exceptions;
using RPG.Domain.Model.Game;
using RPG.Infrastructure.Services;

namespace RPG.API.Public.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class PlayerCharacterController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IPlayerCharacterService _playerCharacterService;
        private readonly IClassService _classService;
        private readonly ICurrentUser _currentUser;

        public PlayerCharacterController(IMapper mapper,IPlayerCharacterService playerCharacterService, IClassService classService, ICurrentUser currentUser)
        {
            _mapper = mapper;
            _playerCharacterService = playerCharacterService;
            _classService = classService;
            _currentUser = currentUser;
        }

        [HttpGet]
        public ActionResult<IEnumerable<PlayerCharacterResponseDto>> GetManyFromCurrentUser()
        {
            Player player = _currentUser.GetCurrentUser();
            IEnumerable<PlayerCharacter> playerCharacter = player.Characters;

            IEnumerable<PlayerCharacterResponseDto> response = _mapper.Map<IEnumerable<PlayerCharacterResponseDto>>(playerCharacter);
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

        [HttpPost]
        public async Task<ActionResult<PlayerCharacterResponseDto>> AddOne(PlayerCharacterRequestDto playerCharacterRequestDto)
        {
            bool isNameTaken = await _playerCharacterService.IsNameTaken(playerCharacterRequestDto.Name);
            if (isNameTaken) throw new HttpBadRequestException("Character with this name already exists!");

            Class? @class = await _classService.GetOne(playerCharacterRequestDto.ClassId);
            if (@class == null) throw new HttpNotFoundException("Class not found!");

            Player player = _currentUser.GetCurrentUser();
            PlayerCharacter playerCharacter = _mapper.Map<PlayerCharacter>(playerCharacterRequestDto);
            playerCharacter.Player = player;
            playerCharacter.Class = @class;
            await _playerCharacterService.AddOne(playerCharacter);

            PlayerCharacterResponseDto response = _mapper.Map<PlayerCharacterResponseDto>(playerCharacter);
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> RemoveOne(int id)
        {
            PlayerCharacter? playerCharacter = await _playerCharacterService.GetOne(id);
            if (playerCharacter == null) throw new HttpNotFoundException("Character not found!");
            Player player = _currentUser.GetCurrentUser();
            if (playerCharacter.Player.Id != player.Id) throw new HttpBadRequestException("This character does not belong to you!");

            await _playerCharacterService.RemoveOne(playerCharacter);

            return NoContent();
        }
    }
}

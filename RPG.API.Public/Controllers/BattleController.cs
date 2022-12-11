using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RPG.API.Public.Utilities;
using RPG.Application.Services;
using RPG.Domain.Dtos.Battle;
using RPG.Domain.Dtos.PlayerCharacter;
using RPG.Domain.Exceptions;
using RPG.Domain.Model.Game;

namespace RPG.API.Public.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class BattleController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IBattleService _battleService;
        private readonly IPlayerCharacterService _characterService;
        private readonly ICurrentUser _currentUser;

        public BattleController(IMapper mapper, IBattleService battleService, IPlayerCharacterService characterService, ICurrentUser currentUser)
        {
            _mapper = mapper;
            _battleService = battleService;
            _characterService = characterService;
            _currentUser = currentUser;
        }


        [HttpPost("1vs1")]
        public async Task<ActionResult<BattleResponseDto>> Pvp1v1(BattleRequestDto battleRequestDto)
        {
            Player currentUser = _currentUser.GetCurrentUser();

            PlayerCharacter? attackerCharacter = await _characterService.GetOne(battleRequestDto.AttackerId);
            if (attackerCharacter == null) throw new HttpNotFoundException("PlayerCharacter not found!");
            if (attackerCharacter.Player.Id != currentUser.Id) throw new HttpBadRequestException("This character does not belong to you!");

            PlayerCharacter? defenderCharacter = await _characterService.GetOne(battleRequestDto.OpponentId);
            if (defenderCharacter == null) throw new HttpNotFoundException("Target character not found!");

            Battle battle = await _battleService.Start1vs1BattleAsync(attackerCharacter, defenderCharacter);

            BattleResponseDto battleResponseDto = _mapper.Map<BattleResponseDto>(battle);
            return Ok(battleResponseDto);
        }

        [HttpPost("Ranking")]
        public async Task<ActionResult<IEnumerable<PlayerCharacterResponseDto>>> Ranking()
        {
            IEnumerable<PlayerCharacter> characters = await _battleService.GetRankingAsync();

            IEnumerable<PlayerCharacterResponseDto> characterResponseDto = _mapper.Map<IEnumerable<PlayerCharacterResponseDto>>(characters);
            return Ok(characterResponseDto);
        }
    }
}

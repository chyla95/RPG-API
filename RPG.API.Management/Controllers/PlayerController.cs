using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RPG.Application.Services;
using RPG.Domain.Dtos.Staff;
using RPG.Domain.Exceptions;
using RPG.Domain.Model.Game;

namespace RPG.API.Management.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlayerController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IPlayerService _playerService;

        public PlayerController(IMapper mapper, IPlayerService playerService)
        {
            _mapper = mapper;
            _playerService = playerService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<PlayerResponseDto>>> GetMany()
        {
            IEnumerable<Player> players = await _playerService.GetMany();

            IEnumerable<PlayerResponseDto> response = _mapper.Map<IEnumerable<PlayerResponseDto>>(players);
            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PlayerResponseDto>> GetOne(int id)
        {
            Player? player = await _playerService.GetOne(id);
            if (player == null) throw new HttpNotFoundException("Player not found!");

            PlayerResponseDto response = _mapper.Map<PlayerResponseDto>(player);
            return Ok(response);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<PlayerResponseDto>> UpdateOne(int id, PlayerRequestDto playerRequestDto)
        {
            bool isEmailTaken = await _playerService.IsEmailTaken(playerRequestDto.Email, id);
            if (isEmailTaken) throw new HttpBadRequestException("Player with this name already exists!");

            Player? player = await _playerService.GetOne(id);
            if (player == null) throw new HttpNotFoundException("Player not found!");

            _mapper.Map(_mapper.Map<Player>(playerRequestDto), player);
            await _playerService.UpdateOne(player);

            PlayerResponseDto response = _mapper.Map<PlayerResponseDto>(player);
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> RemoveOne(int id)
        {
            Player? player = await _playerService.GetOne(id);
            if (player == null) throw new HttpNotFoundException("Player not found!");

            await _playerService.RemoveOne(player);

            return NoContent();
        }
    }
}

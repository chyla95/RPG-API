using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RPG.API.Public.Utilities;
using RPG.Application.Services;
using RPG.Domain.Dtos.Staff;
using RPG.Domain.Exceptions;
using RPG.Domain.Model.Game;
using RPG.Domain.Model.General;

namespace RPG.API.Public.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorizationController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IPlayerService _playerService;
        private readonly IAppSettings _appSettings;

        public AuthorizationController(IMapper mapper, IPlayerService playerService, IAppSettings appSettings)
        {
            _mapper = mapper;
            _playerService = playerService;
            _appSettings = appSettings;
        }

        [HttpPost("SignUp")]
        public async Task<ActionResult<PlayerResponseDto>> SignUp(PlayerRequestDto userRequestDto)
        {
            bool isEmailTaken = await _playerService.IsEmailTaken(userRequestDto.Email);
            if (isEmailTaken) throw new HttpBadRequestException("Email adress already in use!");

            Player player = _mapper.Map<Player>(userRequestDto);
            await _playerService.AddOne(player);

            PlayerResponseDto response = _mapper.Map<PlayerResponseDto>(player);
            string JwtTokenSecret = _appSettings.GetValue(Constants.JWT_SECRET_KEY);
            response.JwtToken = player.CreateJwtToken(JwtTokenSecret);

            return Ok(response);
        }


        [HttpPost("SignIn")]
        public async Task<ActionResult<PlayerResponseDto>> SignIn(PlayerRequestDto userRequestDto)
        {
            Player? player = await _playerService.GetOne(userRequestDto.Email);
            if (player == null) throw new HttpBadRequestException("User not found!");
            if (!player.ComparePassword(userRequestDto.Password)) throw new HttpBadRequestException("Invalid Password!");

            PlayerResponseDto response = _mapper.Map<PlayerResponseDto>(player);
            string JwtTokenSecret = _appSettings.GetValue(Constants.JWT_SECRET_KEY);
            response.JwtToken = player.CreateJwtToken(JwtTokenSecret);

            return Ok(response);
        }
    }
}

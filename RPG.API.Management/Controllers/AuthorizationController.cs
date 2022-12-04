using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RPG.API.Management.Utilities;
using RPG.Application.Services;
using RPG.Domain.Dtos.Staff;
using RPG.Domain.Exceptions;
using RPG.Domain.Model.General;

namespace RPG.API.Management.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorizationController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IStaffService _staffService;
        private readonly IAppSettings _appSettings;

        public AuthorizationController(IMapper mapper, IStaffService staffService, IAppSettings appSettings)
        {
            _mapper = mapper;
            _staffService = staffService;
            _appSettings = appSettings;
        }

        [HttpPost("SignUp")]
        public async Task<ActionResult<StaffResponseDto>> SignUp(StaffRequestDto staffRequestDto)
        {
            Staff? isEmailTaken = await _staffService.GetOne(staffRequestDto.Email);
            if (isEmailTaken != null) throw new HttpBadRequestException("Email adress already in use!");

            Staff staff = _mapper.Map<Staff>(staffRequestDto);
            await _staffService.AddOne(staff);

            StaffResponseDto response = _mapper.Map<StaffResponseDto>(staff);
            string JwtTokenSecret = _appSettings.GetValue(Constants.JWT_SECRET_KEY);
            response.JwtToken = staff.CreateJwtToken(JwtTokenSecret);

            return Ok(response);
        }


        [HttpPost("SignIn")]
        public async Task<ActionResult<StaffResponseDto>> SignIn(StaffRequestDto staffRequestDto)
        {
            Staff? staff = await _staffService.GetOne(staffRequestDto.Email);
            if (staff == null) throw new HttpBadRequestException("User not found!");
            if (!staff.ComparePassword(staffRequestDto.Password)) throw new HttpBadRequestException("Invalid Password!");

            StaffResponseDto response = _mapper.Map<StaffResponseDto>(staff);
            string JwtTokenSecret = _appSettings.GetValue(Constants.JWT_SECRET_KEY);
            response.JwtToken = staff.CreateJwtToken(JwtTokenSecret);

            return Ok(response);
        }
    }
}

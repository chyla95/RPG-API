using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RPG.Application.Services;
using RPG.Domain.Dtos.Staff;
using RPG.Domain.Exceptions;
using RPG.Domain.Model.General;

namespace RPG.API.Management.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class RoleController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IRoleService _roleService;

        public RoleController(IMapper mapper,IRoleService roleService)
        {
            _mapper = mapper;
            _roleService = roleService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<RoleResponseDto>>> GetMany()
        {
            IEnumerable<Role> roles = await _roleService.GetMany();

            IEnumerable<RoleResponseDto> response = _mapper.Map<IEnumerable<RoleResponseDto>>(roles);
            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<RoleResponseDto>> GetOne(int id)
        {
            Role? role = await _roleService.GetOne(id);
            if (role == null) throw new HttpNotFoundException("Role not found!");

            RoleResponseDto response = _mapper.Map<RoleResponseDto>(role);
            return Ok(response);
        }

        [HttpPost]
        public async Task<ActionResult<RoleResponseDto>> AddOne(RoleRequestDto roleRequestDto)
        {
            Role? isNameTaken = await _roleService.GetOne(roleRequestDto.Name);
            if (isNameTaken != null) throw new HttpBadRequestException("Role with this name already exists!");

            Role role = _mapper.Map<Role>(roleRequestDto);
            await _roleService.AddOne(role);

            RoleResponseDto response = _mapper.Map<RoleResponseDto>(role);
            return Ok(response);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<RoleResponseDto>> UpdateOne(int id, RoleRequestDto roleRequestDto)
        {
            Role? role = await _roleService.GetOne(id);
            if (role == null) throw new HttpNotFoundException("Role not found!");

            Role? isNameTaken = await _roleService.GetOne(roleRequestDto.Name);
            if (isNameTaken != null) throw new HttpBadRequestException("Role with this name already exists!");

            Role updatedRole = _mapper.Map<Role>(roleRequestDto);           
            await _roleService.UpdateOne(_mapper.Map(updatedRole, role));

            RoleResponseDto response = _mapper.Map<RoleResponseDto>(role);
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> RemoveOne(int id)
        {
            Role? role = await _roleService.GetOne(id);
            if (role == null) throw new HttpNotFoundException("Role not found!");

            await _roleService.RemoveOne( role);

            return NoContent();
        }
    }
}

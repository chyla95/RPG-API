using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RPG.Application.Services;
using RPG.Domain.Dtos.Class;
using RPG.Domain.Exceptions;
using RPG.Domain.Model.Game;

namespace RPG.API.Management.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ClassController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IClassService _classService;

        public ClassController(IMapper mapper, IClassService classService)
        {
            _mapper = mapper;
            _classService = classService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ClassResponseDto>>> GetMany()
        {
            IEnumerable<Class> classes = await _classService.GetMany();

            IEnumerable<ClassResponseDto> response = _mapper.Map<IEnumerable<ClassResponseDto>>(classes);
            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ClassResponseDto>> GetOne(int id)
        {
            Class? @class = await _classService.GetOne(id);
            if (@class == null) throw new HttpNotFoundException("Class not found!");

            ClassResponseDto response = _mapper.Map<ClassResponseDto>(@class);
            return Ok(response);
        }

        [HttpPost]
        public async Task<ActionResult<ClassResponseDto>> AddOne(ClassRequestDto classRequestDto)
        {
            bool isNameTaken = await _classService.IsNameTaken(classRequestDto.Name);
            if (isNameTaken) throw new HttpBadRequestException("Class with this name already exists!");

            Class @class = _mapper.Map<Class>(classRequestDto);
            await _classService.AddOne(@class);

            ClassResponseDto response = _mapper.Map<ClassResponseDto>(@class);
            return Ok(response);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ClassResponseDto>> UpdateOne(int id, ClassRequestDto classRequestDto)
        {
            bool isNameTaken = await _classService.IsNameTaken(classRequestDto.Name, id);
            if (isNameTaken) throw new HttpBadRequestException("Class with this name already exists!");

            Class? @class = await _classService.GetOne(id);
            if (@class == null) throw new HttpNotFoundException("Class not found!");

            Class updatedClass = _mapper.Map<Class>(classRequestDto);
            await _classService.UpdateOne(_mapper.Map(updatedClass, @class));

            ClassResponseDto response = _mapper.Map<ClassResponseDto>(@class);
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> RemoveOne(int id)
        {
            Class? @class = await _classService.GetOne(id);
            if (@class == null) throw new HttpNotFoundException("Class not found!");

            await _classService.RemoveOne(@class);

            return NoContent();
        }
    }
}

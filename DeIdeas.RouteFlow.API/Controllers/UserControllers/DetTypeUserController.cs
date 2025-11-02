using AutoMapper;
using DeIdeas.RouteFlow.API.DAL.Interfaces;
using DeIdeas.RouteFlow.API.DAL.Models.ModuleUser;
using DeIdeas.RouteFlow.API.DTOs;
using DeIdeas.RouteFlow.API.DTOs.UsrDTOs;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace DeIdeas.RouteFlow.API.Controllers.UserControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DetTypeUserController : ControllerBase
    {
        private readonly IUnitOfWork _unit;
        private readonly IMapper _mapper;

        public DetTypeUserController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unit = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet(nameof(GetAll))]
        public async Task<IActionResult> GetAll()
        {
            var entities = await _unit.DetTypeUser.GetAllAsync();
            var dtos = _mapper.Map<List<ReadDetTypeUserDto>>(entities);

            return Ok(new ApiRequestResultDto<List<ReadDetTypeUserDto>>
            {
                HttpCode = (int)HttpStatusCode.OK,
                Success = true,
                Message = "Consulta exitosa",
                Result = dtos
            });
        }

        [HttpGet("{id}", Name = nameof(GetDetTypeUserById))]
        public async Task<IActionResult> GetDetTypeUserById(int id)
        {
            var entity = await _unit.DetTypeUser.FindByIdAsync(id);
            if (entity == null) return NotFound();

            var dto = _mapper.Map<ReadDetTypeUserDto>(entity);
            return Ok(new ApiRequestResultDto<ReadDetTypeUserDto>
            {
                HttpCode = (int)HttpStatusCode.OK,
                Success = true,
                Message = "Consulta exitosa",
                Result = dto
            });
        }

        [HttpPost(nameof(CreateDetTypeUser))]
        public async Task<IActionResult> CreateDetTypeUser([FromBody] CreateDetTypeUserDto resource)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var entity = _mapper.Map<USR_DetTypeUser>(resource);
            _unit.DetTypeUser.Create(entity);
            await _unit.SaveChangesAsync();

            var dto = _mapper.Map<ReadDetTypeUserDto>(entity);
            return CreatedAtAction(nameof(GetDetTypeUserById), new { id = entity.IdTypeUser }, new ApiRequestResultDto<ReadDetTypeUserDto>
            {
                HttpCode = (int)HttpStatusCode.Created,
                Success = true,
                Message = "Creación exitosa",
                Result = dto
            });
        }

        [HttpPut(nameof(UpdateDetTypeUser))]
        public async Task<IActionResult> UpdateDetTypeUser([FromBody] ModifyDetTypeUserDto resource)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var entity = await _unit.DetTypeUser.FindByIdAsync(resource.IdTypeUser);
            if (entity == null) return NotFound();

            _mapper.Map(resource, entity);
            _unit.DetTypeUser.Update(entity);
            await _unit.SaveChangesAsync();

            var dto = _mapper.Map<ReadDetTypeUserDto>(entity);
            return Ok(new ApiRequestResultDto<ReadDetTypeUserDto>
            {
                HttpCode = (int)HttpStatusCode.OK,
                Success = true,
                Message = "Actualización exitosa",
                Result = dto
            });
        }

        [HttpDelete("{id}", Name = nameof(DeleteDetTypeUser))]
        public async Task<IActionResult> DeleteDetTypeUser(int id)
        {
            var entity = await _unit.DetTypeUser.FindByIdAsync(id);
            if (entity == null) return NotFound();

            _unit.DetTypeUser.Delete(entity);
            await _unit.SaveChangesAsync();

            return Ok(new ApiRequestResultDto<object>
            {
                HttpCode = (int)HttpStatusCode.OK,
                Success = true,
                Message = "Eliminación exitosa",
                Result = null
            });
        }
    }
}

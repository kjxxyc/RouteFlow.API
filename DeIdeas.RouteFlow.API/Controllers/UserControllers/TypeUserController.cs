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
    public class TypeUserController : ControllerBase
    {
        private readonly IUnitOfWork _unit;
        private readonly IMapper _mapper;

        public TypeUserController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unit = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet(nameof(GetAll))]
        public async Task<IActionResult> GetAll()
        {
            var entities = await _unit.TypeUser.GetAllAsync();
            var dtos = _mapper.Map<List<ReadTypeUserDto>>(entities);

            return Ok(new ApiRequestResultDto<List<ReadTypeUserDto>>
            {
                HttpCode = (int)HttpStatusCode.OK,
                Success = true,
                Message = "Consulta exitosa",
                Result = dtos
            });
        }

        [HttpGet("{id}", Name = nameof(GetTypeUserById))]
        public async Task<IActionResult> GetTypeUserById(int id)
        {
            var entity = await _unit.TypeUser.FindByIdAsync(id);
            if (entity == null)
                return NotFound();

            var dto = _mapper.Map<ReadTypeUserDto>(entity);
            return Ok(new ApiRequestResultDto<ReadTypeUserDto>
            {
                HttpCode = (int)HttpStatusCode.OK,
                Success = true,
                Message = "Consulta exitosa",
                Result = dto
            });
        }

        [HttpPost(nameof(CreateTypeUser))]
        public async Task<IActionResult> CreateTypeUser([FromBody] CreateTypeUserDto resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var entity = _mapper.Map<USR_TypeUser>(resource);
            _unit.TypeUser.Create(entity);
            await _unit.SaveChangesAsync();

            var dto = _mapper.Map<ReadTypeUserDto>(entity);
            return CreatedAtAction(nameof(GetTypeUserById), new { id = entity.IdTypeUser }, new ApiRequestResultDto<ReadTypeUserDto>
            {
                HttpCode = (int)HttpStatusCode.Created,
                Success = true,
                Message = "Creación exitosa",
                Result = dto
            });
        }

        [HttpPut(nameof(UpdateTypeUser))]
        public async Task<IActionResult> UpdateTypeUser([FromBody] ModifyTypeUserDto resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var entity = await _unit.TypeUser.FindByIdAsync(resource.IdTypeUser);
            if (entity == null)
                return NotFound();

            _mapper.Map(resource, entity);
            _unit.TypeUser.Update(entity);
            await _unit.SaveChangesAsync();

            var dto = _mapper.Map<ReadTypeUserDto>(entity);
            return Ok(new ApiRequestResultDto<ReadTypeUserDto>
            {
                HttpCode = (int)HttpStatusCode.OK,
                Success = true,
                Message = "Actualización exitosa",
                Result = dto
            });
        }

        [HttpPatch(nameof(ChangeStatusTypeUser))]
        public async Task<IActionResult> ChangeStatusTypeUser([FromBody] ChangeStatusTypeUserDto resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var entity = await _unit.TypeUser.FindByIdAsync(resource.IdTypeUser);
            if (entity == null)
                return NotFound();

            entity.Status = resource.Status;
            _unit.TypeUser.Update(entity);
            await _unit.SaveChangesAsync();

            var dto = _mapper.Map<ReadTypeUserDto>(entity);
            return Ok(new ApiRequestResultDto<ReadTypeUserDto>
            {
                HttpCode = (int)HttpStatusCode.OK,
                Success = true,
                Message = "Cambio de estado exitoso",
                Result = dto
            });
        }

        [HttpDelete("{id}", Name = nameof(DeleteTypeUser))]
        public async Task<IActionResult> DeleteTypeUser(int id)
        {
            var entity = await _unit.TypeUser.FindByIdAsync(id);
            if (entity == null)
                return NotFound();

            _unit.TypeUser.Delete(entity);
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

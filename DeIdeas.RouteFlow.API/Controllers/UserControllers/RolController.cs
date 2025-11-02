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
    public class RolController : ControllerBase
    {
        private readonly IUnitOfWork _unit;
        private readonly IMapper _mapper;

        public RolController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unit = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet(nameof(GetAll))]
        public async Task<IActionResult> GetAll()
        {
            var entities = await _unit.USR_Rol.GetAllAsync();
            var dtos = _mapper.Map<List<ReadRolDto>>(entities);

            return Ok(new ApiRequestResultDto<List<ReadRolDto>>
            {
                HttpCode = (int)HttpStatusCode.OK,
                Success = true,
                Message = "Consulta exitosa",
                Result = dtos
            });
        }

        [HttpGet("{rol}", Name = nameof(GetRolById))]
        public async Task<IActionResult> GetRolById(string rol)
        {
            var entity = await _unit.USR_Rol.FindById(rol);
            if (entity == null)
                return NotFound();

            var dto = _mapper.Map<ReadRolDto>(entity);
            return Ok(new ApiRequestResultDto<ReadRolDto>
            {
                HttpCode = (int)HttpStatusCode.OK,
                Success = true,
                Message = "Consulta exitosa",
                Result = dto
            });
        }

        [HttpPost(nameof(CreateRol))]
        public async Task<IActionResult> CreateRol([FromBody] CreateRolDto resource)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var entity = _mapper.Map<USR_Rol>(resource);
            _unit.USR_Rol.Create(entity);
            await _unit.SaveChangesAsync();

            var dto = _mapper.Map<ReadRolDto>(entity);
            return CreatedAtAction(nameof(GetRolById), new { rol = entity.Rol }, new ApiRequestResultDto<ReadRolDto>
            {
                HttpCode = (int)HttpStatusCode.Created,
                Success = true,
                Message = "Creación exitosa",
                Result = dto
            });
        }

        [HttpPut(nameof(UpdateRol))]
        public async Task<IActionResult> UpdateRol([FromBody] ModifyRolDto resource)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var entity = await _unit.USR_Rol.FindById(resource.Rol);
            if (entity == null) return NotFound();

            _mapper.Map(resource, entity);
            _unit.USR_Rol.Update(entity);
            await _unit.SaveChangesAsync();

            var dto = _mapper.Map<ReadRolDto>(entity);
            return Ok(new ApiRequestResultDto<ReadRolDto>
            {
                HttpCode = (int)HttpStatusCode.OK,
                Success = true,
                Message = "Actualización exitosa",
                Result = dto
            });
        }

        [HttpPatch(nameof(ChangeStatusRol))]
        public async Task<IActionResult> ChangeStatusRol([FromBody] ChangeStatusRolDto resource)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var entity = await _unit.USR_Rol.FindById(resource.Rol);
            if (entity == null) return NotFound();

            entity.Status = resource.Status;
            _unit.USR_Rol.Update(entity);
            await _unit.SaveChangesAsync();

            var dto = _mapper.Map<ReadRolDto>(entity);
            return Ok(new ApiRequestResultDto<ReadRolDto>
            {
                HttpCode = (int)HttpStatusCode.OK,
                Success = true,
                Message = "Cambio de estado exitoso",
                Result = dto
            });
        }

        [HttpDelete("{rol}", Name = nameof(DeleteRol))]
        public async Task<IActionResult> DeleteRol(string rol)
        {
            var entity = await _unit.USR_Rol.FindById(rol);
            if (entity == null) return NotFound();

            _unit.USR_Rol.Delete(entity);
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

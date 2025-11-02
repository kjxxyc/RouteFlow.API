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
    public class UserRolController : ControllerBase
    {
        private readonly IUnitOfWork _unit;
        private readonly IMapper _mapper;

        public UserRolController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unit = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet(nameof(GetAll))]
        public async Task<IActionResult> GetAll()
        {
            var entities = await _unit.USR_UserRol.GetAllAsync();
            var dtos = _mapper.Map<List<ReadUserRolDto>>(entities);

            return Ok(new ApiRequestResultDto<List<ReadUserRolDto>>
            {
                HttpCode = (int)HttpStatusCode.OK,
                Success = true,
                Message = "Consulta exitosa",
                Result = dtos
            });
        }

        [HttpGet("{user}/{rol}", Name = nameof(GetUserRolById))]
        public async Task<IActionResult> GetUserRolById(string user, string rol)
        {
            var entity = await _unit.USR_UserRol.GetSingleWithFilterAsync(x => x.User == user && x.Rol == rol);
            if (entity == null)
                return NotFound();

            var dto = _mapper.Map<ReadUserRolDto>(entity);
            return Ok(new ApiRequestResultDto<ReadUserRolDto>
            {
                HttpCode = (int)HttpStatusCode.OK,
                Success = true,
                Message = "Consulta exitosa",
                Result = dto
            });
        }

        [HttpPost(nameof(CreateUserRol))]
        public async Task<IActionResult> CreateUserRol([FromBody] CreateUserRolDto resource)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var entity = _mapper.Map<USR_UserRol>(resource);
            _unit.USR_UserRol.Create(entity);
            await _unit.SaveChangesAsync();

            var dto = _mapper.Map<ReadUserRolDto>(entity);
            return CreatedAtAction(nameof(GetUserRolById), new { user = entity.User, rol = entity.Rol }, new ApiRequestResultDto<ReadUserRolDto>
            {
                HttpCode = (int)HttpStatusCode.Created,
                Success = true,
                Message = "Creación exitosa",
                Result = dto
            });
        }

        [HttpPut(nameof(UpdateUserRol))]
        public async Task<IActionResult> UpdateUserRol([FromBody] ModifyUserRolDto resource)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var entity = await _unit.USR_UserRol.GetSingleWithFilterAsync(x => x.User == resource.User && x.Rol == resource.Rol);
            if (entity == null) return NotFound();

            _mapper.Map(resource, entity);
            _unit.USR_UserRol.Update(entity);
            await _unit.SaveChangesAsync();

            var dto = _mapper.Map<ReadUserRolDto>(entity);
            return Ok(new ApiRequestResultDto<ReadUserRolDto>
            {
                HttpCode = (int)HttpStatusCode.OK,
                Success = true,
                Message = "Actualización exitosa",
                Result = dto
            });
        }

        [HttpPatch(nameof(ChangeStatusUserRol))]
        public async Task<IActionResult> ChangeStatusUserRol([FromBody] ChangeStatusUserRolDto resource)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var entity = await _unit.USR_UserRol.GetSingleWithFilterAsync(x => x.User == resource.User && x.Rol == resource.Rol);
            if (entity == null) return NotFound();

            entity.Status = resource.Status;
            _unit.USR_UserRol.Update(entity);
            await _unit.SaveChangesAsync();

            var dto = _mapper.Map<ReadUserRolDto>(entity);
            return Ok(new ApiRequestResultDto<ReadUserRolDto>
            {
                HttpCode = (int)HttpStatusCode.OK,
                Success = true,
                Message = "Cambio de estado exitoso",
                Result = dto
            });
        }

        [HttpDelete("{user}/{rol}", Name = nameof(DeleteUserRol))]
        public async Task<IActionResult> DeleteUserRol(string user, string rol)
        {
            var entity = await _unit.USR_UserRol.GetSingleWithFilterAsync(x => x.User == user && x.Rol == rol);
            if (entity == null) return NotFound();

            _unit.USR_UserRol.Delete(entity);
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

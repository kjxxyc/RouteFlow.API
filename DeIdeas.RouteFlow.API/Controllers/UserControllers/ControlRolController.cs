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
    public class ControlRolController : ControllerBase
    {
        private readonly IUnitOfWork _unit;
        private readonly IMapper _mapper;

        public ControlRolController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unit = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet(nameof(GetAll))]
        public async Task<IActionResult> GetAll()
        {
            var entities = await _unit.USR_ControlRol.GetAllAsync();
            var dtos = _mapper.Map<List<ReadControlRolDto>>(entities);

            return Ok(new ApiRequestResultDto<List<ReadControlRolDto>>
            {
                HttpCode = (int)HttpStatusCode.OK,
                Success = true,
                Message = "Consulta exitosa",
                Result = dtos
            });
        }

        // Nuevo endpoint con clave compuesta
        [HttpGet("{idControl:int}/{rol}", Name = nameof(GetControlRolById))]
        public async Task<IActionResult> GetControlRolById(int idControl, string rol)
        {
            var entity = await _unit.USR_ControlRol.GetSingleWithFilterAsync(x => x.IdControl == idControl && x.Rol == rol);
            if (entity == null) return NotFound();

            var dto = _mapper.Map<ReadControlRolDto>(entity);
            return Ok(new ApiRequestResultDto<ReadControlRolDto>
            {
                HttpCode = (int)HttpStatusCode.OK,
                Success = true,
                Message = "Consulta exitosa",
                Result = dto
            });
        }

        [HttpPost(nameof(CreateControlRol))]
        public async Task<IActionResult> CreateControlRol([FromBody] CreateControlRolDto resource)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            // Validaciones FK explícitas para evitar errores 547
            var control = await _unit.USR_Control.FindByIdAsync(resource.IdControl);
            if (control == null) return NotFound(new { Message = "Control no existe" });

            var rolEntity = await _unit.USR_Rol.FindById(resource.Rol);
            if (rolEntity == null) return NotFound(new { Message = "Rol no existe" });

            // Evitar duplicados
            var exists = await _unit.USR_ControlRol.CheckWithConditionAsync(x => x.IdControl == resource.IdControl && x.Rol == resource.Rol);
            if (exists) return Conflict(new { Message = "Ya existe la relación Control-Rol" });

            var entity = _mapper.Map<USR_ControlRol>(resource);
            entity.Date = DateTime.UtcNow;
            entity.Status = 1;
            _unit.USR_ControlRol.Create(entity);
            await _unit.SaveChangesAsync();

            var dto = _mapper.Map<ReadControlRolDto>(entity);
            return CreatedAtAction(nameof(GetControlRolById), new { idControl = entity.IdControl, rol = entity.Rol }, new ApiRequestResultDto<ReadControlRolDto>
            {
                HttpCode = (int)HttpStatusCode.Created,
                Success = true,
                Message = "Creación exitosa",
                Result = dto
            });
        }

        [HttpPut(nameof(UpdateControlRol))]
        public async Task<IActionResult> UpdateControlRol([FromBody] ModifyControlRolDto resource)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            if (string.IsNullOrWhiteSpace(resource.Rol)) return BadRequest(new { Message = "Rol es requerido" });

            var entity = await _unit.USR_ControlRol.GetSingleWithFilterAsync(x => x.IdControl == resource.IdControl && x.Rol == resource.Rol);
            if (entity == null) return NotFound();

            // Claves compuestas no se modifican; solo otros campos (no hay otros aquí)
            _unit.USR_ControlRol.Update(entity);
            await _unit.SaveChangesAsync();

            var dto = _mapper.Map<ReadControlRolDto>(entity);
            return Ok(new ApiRequestResultDto<ReadControlRolDto>
            {
                HttpCode = (int)HttpStatusCode.OK,
                Success = true,
                Message = "Actualización exitosa",
                Result = dto
            });
        }

        [HttpPatch(nameof(ChangeStatusControlRol))]
        public async Task<IActionResult> ChangeStatusControlRol([FromBody] ChangeStatusControlRolDto resource)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            if (resource.Status < 0) return BadRequest(new { Message = "Estado inválido" });
            if (string.IsNullOrWhiteSpace(resource.Rol)) return BadRequest(new { Message = "Rol es requerido" });

            var entity = await _unit.USR_ControlRol.GetSingleWithFilterAsync(x => x.IdControl == resource.IdControl && x.Rol == resource.Rol);
            if (entity == null) return NotFound();

            entity.Status = resource.Status;
            _unit.USR_ControlRol.Update(entity);
            await _unit.SaveChangesAsync();

            var dto = _mapper.Map<ReadControlRolDto>(entity);
            return Ok(new ApiRequestResultDto<ReadControlRolDto>
            {
                HttpCode = (int)HttpStatusCode.OK,
                Success = true,
                Message = "Cambio de estado exitoso",
                Result = dto
            });
        }

        [HttpDelete("{idControl:int}/{rol}", Name = nameof(DeleteControlRol))]
        public async Task<IActionResult> DeleteControlRol(int idControl, string rol)
        {
            var entity = await _unit.USR_ControlRol.GetSingleWithFilterAsync(x => x.IdControl == idControl && x.Rol == rol);
            if (entity == null) return NotFound();

            _unit.USR_ControlRol.Delete(entity);
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

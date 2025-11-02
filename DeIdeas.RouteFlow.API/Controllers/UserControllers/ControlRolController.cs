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

        [HttpGet("{id}", Name = nameof(GetControlRolById))]
        public async Task<IActionResult> GetControlRolById(int id)
        {
            var entity = await _unit.USR_ControlRol.FindByIdAsync(id);
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

            var entity = _mapper.Map<USR_ControlRol>(resource);
            _unit.USR_ControlRol.Create(entity);
            await _unit.SaveChangesAsync();

            var dto = _mapper.Map<ReadControlRolDto>(entity);
            return CreatedAtAction(nameof(GetControlRolById), new { id = entity.IdControl }, new ApiRequestResultDto<ReadControlRolDto>
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

            var entity = await _unit.USR_ControlRol.FindByIdAsync(resource.IdControl);
            if (entity == null) return NotFound();

            _mapper.Map(resource, entity);
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

            var entity = await _unit.USR_ControlRol.FindByIdAsync(resource.IdControl);
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

        [HttpDelete("{id}", Name = nameof(DeleteControlRol))]
        public async Task<IActionResult> DeleteControlRol(int id)
        {
            var entity = await _unit.USR_ControlRol.FindByIdAsync(id);
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

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
    public class ControlController : ControllerBase
    {
        private readonly IUnitOfWork _unit;
        private readonly IMapper _mapper;

        public ControlController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unit = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet(nameof(GetAll))]
        public async Task<IActionResult> GetAll()
        {
            var entities = await _unit.USR_Control.GetAllAsync();
            var dtos = _mapper.Map<List<ReadControlDto>>(entities);

            return Ok(new ApiRequestResultDto<List<ReadControlDto>>
            {
                HttpCode = (int)HttpStatusCode.OK,
                Success = true,
                Message = "Consulta exitosa",
                Result = dtos
            });
        }

        [HttpGet("{id}", Name = nameof(GetControlById))]
        public async Task<IActionResult> GetControlById(int id)
        {
            var entity = await _unit.USR_Control.FindByIdAsync(id);
            if (entity == null) return NotFound();

            var dto = _mapper.Map<ReadControlDto>(entity);
            return Ok(new ApiRequestResultDto<ReadControlDto>
            {
                HttpCode = (int)HttpStatusCode.OK,
                Success = true,
                Message = "Consulta exitosa",
                Result = dto
            });
        }

        // Obtiene la lista de controles filtrados por IdMaestro
        [HttpGet("maestro/{idMaestro:int}", Name = nameof(GetControlByMaeId))]
        public async Task<IActionResult> GetControlByMaeId(int idMaestro)
        {
            var entities = await _unit.USR_Control.GetListWithFilterAsync(c => c.IdMaestro == idMaestro);
            var dtos = _mapper.Map<List<ReadControlDto>>(entities);

            return Ok(new ApiRequestResultDto<List<ReadControlDto>>
            {
                HttpCode = (int)HttpStatusCode.OK,
                Success = true,
                Message = dtos.Count >0 ? "Consulta exitosa" : "Sin resultados",
                Result = dtos
            });
        }

        [HttpPost(nameof(CreateControl))]
        public async Task<IActionResult> CreateControl([FromBody] CreateControlDto resource)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var entity = _mapper.Map<USR_Control>(resource);
            _unit.USR_Control.Create(entity);
            await _unit.SaveChangesAsync();

            var dto = _mapper.Map<ReadControlDto>(entity);
            return CreatedAtAction(nameof(GetControlById), new { id = entity.IdControl }, new ApiRequestResultDto<ReadControlDto>
            {
                HttpCode = (int)HttpStatusCode.Created,
                Success = true,
                Message = "Creación exitosa",
                Result = dto
            });
        }

        [HttpPut(nameof(UpdateControl))]
        public async Task<IActionResult> UpdateControl([FromBody] ModifyControlDto resource)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var entity = await _unit.USR_Control.FindByIdAsync(resource.IdControl);
            if (entity == null) return NotFound();

            _mapper.Map(resource, entity);
            _unit.USR_Control.Update(entity);
            await _unit.SaveChangesAsync();

            var dto = _mapper.Map<ReadControlDto>(entity);
            return Ok(new ApiRequestResultDto<ReadControlDto>
            {
                HttpCode = (int)HttpStatusCode.OK,
                Success = true,
                Message = "Actualización exitosa.",
                Result = dto
            });
        }

        [HttpPatch(nameof(ChangeStatusControl))]
        public async Task<IActionResult> ChangeStatusControl([FromBody] ChangeStatusControlDto resource)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var entity = await _unit.USR_Control.FindByIdAsync(resource.IdControl);
            if (entity == null) return NotFound();

            entity.Status = resource.Status;
            _unit.USR_Control.Update(entity);
            await _unit.SaveChangesAsync();

            var dto = _mapper.Map<ReadControlDto>(entity);
            return Ok(new ApiRequestResultDto<ReadControlDto>
            {
                HttpCode = (int)HttpStatusCode.OK,
                Success = true,
                Message = "Cambio de estado exitoso",
                Result = dto
            });
        }

        [HttpDelete("{id}", Name = nameof(DeleteControl))]
        public async Task<IActionResult> DeleteControl(int id)
        {
            var entity = await _unit.USR_Control.FindByIdAsync(id);
            if (entity == null) return NotFound();

            _unit.USR_Control.Delete(entity);
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

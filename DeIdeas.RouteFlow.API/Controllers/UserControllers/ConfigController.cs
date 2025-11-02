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
    public class ConfigController : ControllerBase
    {
        private readonly IUnitOfWork _unit;
        private readonly IMapper _mapper;

        public ConfigController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unit = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet(nameof(GetAll))]
        public async Task<IActionResult> GetAll()
        {
            var entities = await _unit.USR_Config.GetAllAsync();
            var dtos = _mapper.Map<List<ReadConfigDto>>(entities);

            return Ok(new ApiRequestResultDto<List<ReadConfigDto>>
            {
                HttpCode = (int)HttpStatusCode.OK,
                Success = true,
                Message = "Consulta exitosa",
                Result = dtos
            });
        }

        [HttpGet("{id}", Name = nameof(GetConfigById))]
        public async Task<IActionResult> GetConfigById(int id)
        {
            var entity = await _unit.USR_Config.FindByIdAsync(id);
            if (entity == null) return NotFound();

            var dto = _mapper.Map<ReadConfigDto>(entity);
            return Ok(new ApiRequestResultDto<ReadConfigDto>
            {
                HttpCode = (int)HttpStatusCode.OK,
                Success = true,
                Message = "Consulta exitosa",
                Result = dto
            });
        }

        [HttpPost(nameof(CreateConfig))]
        public async Task<IActionResult> CreateConfig([FromBody] CreateConfigDto resource)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var entity = _mapper.Map<USR_Config>(resource);
            _unit.USR_Config.Create(entity);
            await _unit.SaveChangesAsync();

            var dto = _mapper.Map<ReadConfigDto>(entity);
            return CreatedAtAction(nameof(GetConfigById), new { id = entity.Id }, new ApiRequestResultDto<ReadConfigDto>
            {
                HttpCode = (int)HttpStatusCode.Created,
                Success = true,
                Message = "Creación exitosa",
                Result = dto
            });
        }

        [HttpPut(nameof(UpdateConfig))]
        public async Task<IActionResult> UpdateConfig([FromBody] ModifyConfigDto resource)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var entity = await _unit.USR_Config.FindByIdAsync(resource.Id);
            if (entity == null) return NotFound();

            _mapper.Map(resource, entity);
            _unit.USR_Config.Update(entity);
            await _unit.SaveChangesAsync();

            var dto = _mapper.Map<ReadConfigDto>(entity);
            return Ok(new ApiRequestResultDto<ReadConfigDto>
            {
                HttpCode = (int)HttpStatusCode.OK,
                Success = true,
                Message = "Actualización exitosa",
                Result = dto
            });
        }

        [HttpPatch(nameof(ChangeStatusConfig))]
        public async Task<IActionResult> ChangeStatusConfig([FromBody] ChangeStatusConfigDto resource)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var entity = await _unit.USR_Config.FindByIdAsync(resource.Id);
            if (entity == null) return NotFound();

            entity.Status = resource.Status;
            _unit.USR_Config.Update(entity);
            await _unit.SaveChangesAsync();

            var dto = _mapper.Map<ReadConfigDto>(entity);
            return Ok(new ApiRequestResultDto<ReadConfigDto>
            {
                HttpCode = (int)HttpStatusCode.OK,
                Success = true,
                Message = "Cambio de estado exitoso",
                Result = dto
            });
        }

        [HttpDelete("{id}", Name = nameof(DeleteConfig))]
        public async Task<IActionResult> DeleteConfig(int id)
        {
            var entity = await _unit.USR_Config.FindByIdAsync(id);
            if (entity == null) return NotFound();

            _unit.USR_Config.Delete(entity);
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

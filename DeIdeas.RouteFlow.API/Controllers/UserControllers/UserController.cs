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
    public class UserController : ControllerBase
    {
        private readonly IUnitOfWork _unit;
        private readonly IMapper _mapper;

        public UserController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unit = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet(nameof(GetAll))]
        public async Task<IActionResult> GetAll()
        {
            var entities = await _unit.USR_User.GetAllAsync();
            var dtos = _mapper.Map<List<ReadUserDto>>(entities);

            return Ok(new ApiRequestResultDto<List<ReadUserDto>>
            {
                HttpCode = (int)HttpStatusCode.OK,
                Success = true,
                Message = "Consulta exitosa",
                Result = dtos
            });
        }

        [HttpGet("{user}", Name = nameof(GetUserById))]
        public async Task<IActionResult> GetUserById(string user)
        {
            var entity = await _unit.USR_User.FindById(user);
            if (entity == null) return NotFound();

            var dto = _mapper.Map<ReadUserDto>(entity);
            return Ok(new ApiRequestResultDto<ReadUserDto>
            {
                HttpCode = (int)HttpStatusCode.OK,
                Success = true,
                Message = "Consulta exitosa",
                Result = dto
            });
        }

        [HttpPost(nameof(CreateUser))]
        public async Task<IActionResult> CreateUser([FromBody] CreateUserDto resource)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var entity = _mapper.Map<USR_User>(resource);
            _unit.USR_User.Create(entity);
            await _unit.SaveChangesAsync();

            var dto = _mapper.Map<ReadUserDto>(entity);

            return CreatedAtAction(nameof(GetUserById), new { user = entity.User }, new ApiRequestResultDto<ReadUserDto>
            {
                HttpCode = (int)HttpStatusCode.Created,
                Success = true,
                Message = "Creación exitosa",
                Result = dto
            });
        }

        [HttpPut(nameof(UpdateUser))]
        public async Task<IActionResult> UpdateUser([FromBody] ModifyUserDto resource)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var entity = await _unit.USR_User.FindById(resource.User);
            if (entity == null) return NotFound();

            _mapper.Map(resource, entity);
            _unit.USR_User.Update(entity);
            await _unit.SaveChangesAsync();

            var dto = _mapper.Map<ReadUserDto>(entity);
            return Ok(new ApiRequestResultDto<ReadUserDto>
            {
                HttpCode = (int)HttpStatusCode.OK,
                Success = true,
                Message = "Actualización exitosa",
                Result = dto
            });
        }

        [HttpPatch(nameof(ChangeStatusUser))]
        public async Task<IActionResult> ChangeStatusUser([FromBody] ChangeStatusUserDto resource)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var entity = await _unit.USR_User.FindById(resource.User);
            if (entity == null) return NotFound();

            entity.Status = resource.Status;
            _unit.USR_User.Update(entity);
            await _unit.SaveChangesAsync();

            var dto = _mapper.Map<ReadUserDto>(entity);
            return Ok(new ApiRequestResultDto<ReadUserDto>
            {
                HttpCode = (int)HttpStatusCode.OK,
                Success = true,
                Message = "Cambio de estado exitoso",
                Result = dto
            });
        }

        [HttpDelete("{user}", Name = nameof(DeleteUser))]
        public async Task<IActionResult> DeleteUser(string user)
        {
            var entity = await _unit.USR_User.FindById(user);
            if (entity == null) return NotFound();

            _unit.USR_User.Delete(entity);
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
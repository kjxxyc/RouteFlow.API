using AutoMapper;
using DeIdeas.RouteFlow.API.DAL.Interfaces;
using DeIdeas.RouteFlow.API.DTOs;
using DeIdeas.RouteFlow.API.DTOs.UsrDTOs;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Linq;
using System.Collections.Generic;

namespace DeIdeas.RouteFlow.API.Controllers.UserControllers
{
    [Route("api/controlrol")]
    [ApiController]
    public class ControlRolUsersController : ControllerBase
    {
        private readonly IUnitOfWork _unit;
        private readonly IMapper _mapper;

        public ControlRolUsersController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unit = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet("byrole/{rol}", Name = "GetUsersByRole")]
        public async Task<IActionResult> GetUsersByRole(string rol)
        {
            var userRoles = (await _unit.USR_UserRol.GetListWithFilterAsync(x => x.Rol == rol)).ToList();
            if (!userRoles.Any())
            {
                return Ok(new ApiRequestResultDto<List<ReadUserDto>>
                {
                    HttpCode = (int)HttpStatusCode.OK,
                    Success = true,
                    Message = "Sin resultados",
                    Result = new List<ReadUserDto>()
                });
            }

            var usersKeys = userRoles.Select(ur => ur.User).ToList();
            var users = (await _unit.USR_User.GetListWithFilterAsync(u => usersKeys.Contains(u.User))).ToList();
            var dtos = _mapper.Map<List<ReadUserDto>>(users);

            return Ok(new ApiRequestResultDto<List<ReadUserDto>>
            {
                HttpCode = (int)HttpStatusCode.OK,
                Success = true,
                Message = dtos.Count > 0 ? "Consulta exitosa" : "Sin resultados",
                Result = dtos
            });
        }
    }
}

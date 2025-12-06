using DeIdeas.RouteFlow.API.DAL.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DeIdeas.RouteFlow.API.Controllers.Legacy
{
    [Route("api/legacy/[controller]")]
    [ApiController]
    public class PendingPassController : ControllerBase
    {
        private readonly IUnitOfWork _unit;
        public PendingPassController(IUnitOfWork unit) { _unit = unit; }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var list = await _unit.PendingPass.GetAllAsync();
            return Ok(list);
        }

        [HttpGet("range")]
        public async Task<IActionResult> GetByDateRange([FromQuery] DateTime from, [FromQuery] DateTime to, CancellationToken ct)
        {
            if (from > to) return BadRequest(new { message = "El parámetro 'from' no puede ser mayor que 'to'." });

            var list = await _unit.PendingPass.GetByDateRangeAsync(from, to, ct);
            return Ok(list);
        }
    }
}

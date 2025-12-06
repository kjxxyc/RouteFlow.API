using DeIdeas.RouteFlow.API.DAL.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DeIdeas.RouteFlow.API.Controllers.Legacy
{
    [Route("api/legacy/[controller]")]
    [ApiController]
    public class BusinessPartnerController : ControllerBase
    {
        private readonly IUnitOfWork _unit;
        public BusinessPartnerController(IUnitOfWork unit) { _unit = unit; }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var list = await _unit.OCRD.GetAllAsync();
            return Ok(list);
        }

        [HttpGet("{cardCode}")]
        public async Task<IActionResult> GetById(string cardCode)
        {
            var bp = await _unit.OCRD.GetByIdAsync(cardCode);
            if (bp == null) return NotFound();
            return Ok(bp);
        }
    }
}
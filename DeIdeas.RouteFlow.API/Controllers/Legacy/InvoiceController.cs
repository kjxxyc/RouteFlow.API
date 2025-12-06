using DeIdeas.RouteFlow.API.DAL.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DeIdeas.RouteFlow.API.Controllers.Legacy
{
    [Route("api/legacy/[controller]")]
    [ApiController]
    public class InvoiceController : ControllerBase
    {
        private readonly IUnitOfWork _unit;
        public InvoiceController(IUnitOfWork unit) { _unit = unit; }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var list = await _unit.OINV.GetAllAsync();
            return Ok(list);
        }

        [HttpGet("{docEntry:int}")]
        public async Task<IActionResult> GetById(int docEntry)
        {
            var inv = await _unit.OINV.GetByIdAsync(docEntry);
            if (inv == null) return NotFound();
            return Ok(inv);
        }
    }
}
using DeIdeas.RouteFlow.API.DAL.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DeIdeas.RouteFlow.API.Controllers.Legacy
{
    [Route("api/legacy/[controller]")]
    [ApiController]
    public class PendingPaymentController : ControllerBase
    {
        private readonly IUnitOfWork _unit;
        public PendingPaymentController(IUnitOfWork unit) { _unit = unit; }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var list = await _unit.PendingPayment.GetAllAsync();
            return Ok(list);
        }
    }
}
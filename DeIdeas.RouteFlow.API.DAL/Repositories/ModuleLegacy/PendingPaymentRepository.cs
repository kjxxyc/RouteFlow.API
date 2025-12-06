using DeIdeas.RouteFlow.API.DAL.Context;
using DeIdeas.RouteFlow.API.DAL.Interfaces.LegacyInterfaces;
using DeIdeas.RouteFlow.API.DAL.Models.Legacy;
using Microsoft.EntityFrameworkCore;

namespace DeIdeas.RouteFlow.API.DAL.Repositories.ModuleLegacy
{
    public class PendingPaymentRepository : IPendingPaymentRepository
    {
        private readonly LegacyContext _context;
        public PendingPaymentRepository(LegacyContext context) { _context = context; }
        public async Task<IEnumerable<SAP_V_PendingPayment>> GetAllAsync() => await _context.SAP_V_PendingPayment.AsNoTracking().ToListAsync();
    }
}
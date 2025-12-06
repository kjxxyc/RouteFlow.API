using DeIdeas.RouteFlow.API.DAL.Context;
using DeIdeas.RouteFlow.API.DAL.Interfaces.LegacyInterfaces;
using DeIdeas.RouteFlow.API.DAL.Models.Legacy;
using Microsoft.EntityFrameworkCore;

namespace DeIdeas.RouteFlow.API.DAL.Repositories.ModuleLegacy
{
    public class PendingPassRepository : IPendingPassRepository
    {
        private readonly LegacyContext _context;
        public PendingPassRepository(LegacyContext context) { _context = context; }
        public async Task<IEnumerable<SAP_V_PendingPass>> GetAllAsync() => await _context.SAP_V_PendingPass.AsNoTracking().ToListAsync();

        public async Task<IEnumerable<SAP_V_PendingPass>> GetByDateRangeAsync(DateTime from, DateTime to, CancellationToken ct = default)
        {
            // Filter by Fecha_documento between from and to (inclusive)
            return await _context.SAP_V_PendingPass
                .AsNoTracking()
                .Where(x => x.Fecha_documento >= from.Date && x.Fecha_documento <= to.Date)
                .ToListAsync(ct);
        }
    }
}
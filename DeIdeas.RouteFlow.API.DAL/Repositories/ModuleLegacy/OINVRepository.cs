using DeIdeas.RouteFlow.API.DAL.Context;
using DeIdeas.RouteFlow.API.DAL.Interfaces.LegacyInterfaces;
using DeIdeas.RouteFlow.API.DAL.Models.Legacy;
using Microsoft.EntityFrameworkCore;

namespace DeIdeas.RouteFlow.API.DAL.Repositories.ModuleLegacy
{
    public class OINVRepository : IOINVRepository
    {
        private readonly LegacyContext _context;
        public OINVRepository(LegacyContext context) { _context = context; }
        public async Task<IEnumerable<OINV>> GetAllAsync() => await _context.OINV.AsNoTracking().ToListAsync();
        public async Task<OINV?> GetByIdAsync(int docEntry) => await _context.OINV.AsNoTracking().FirstOrDefaultAsync(x => x.DocEntry == docEntry);
    }
}
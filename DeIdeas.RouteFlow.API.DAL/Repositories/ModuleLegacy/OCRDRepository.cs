using DeIdeas.RouteFlow.API.DAL.Context;
using DeIdeas.RouteFlow.API.DAL.Interfaces.LegacyInterfaces;
using DeIdeas.RouteFlow.API.DAL.Models.Legacy;
using Microsoft.EntityFrameworkCore;

namespace DeIdeas.RouteFlow.API.DAL.Repositories.ModuleLegacy
{
    public class OCRDRepository : IOCRDRepository
    {
        private readonly LegacyContext _context;
        public OCRDRepository(LegacyContext context) { _context = context; }
        public async Task<IEnumerable<OCRD>> GetAllAsync() => await _context.OCRD.AsNoTracking().ToListAsync();
        public async Task<OCRD?> GetByIdAsync(string cardCode) => await _context.OCRD.AsNoTracking().FirstOrDefaultAsync(x => x.CardCode == cardCode);
    }
}
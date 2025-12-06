using DeIdeas.RouteFlow.API.DAL.Context;
using DeIdeas.RouteFlow.API.DAL.Interfaces.LegacyInterfaces;
using DeIdeas.RouteFlow.API.DAL.Models.Routing;
using Microsoft.EntityFrameworkCore;

namespace DeIdeas.RouteFlow.API.DAL.Repositories.ModuleLegacy
{
    public class RutaRepository : IRutaRepository
    {
        private readonly LegacyContext _context;
        public RutaRepository(LegacyContext context) { _context = context; }

        public async Task InsertAsync(Ruta entity, CancellationToken ct = default)
        {
            _context.Rutas.Add(entity);
            await _context.SaveChangesAsync(ct);
        }

        public async Task InsertDetRutaAsync(DetRuta det, CancellationToken ct = default)
        {
            _context.DetRutas.Add(det);
            await _context.SaveChangesAsync(ct);
        }

        public async Task<bool> DetRutaExistsAsync(int noDocumento, CancellationToken ct = default)
        {
            return await _context.DetRutas.AnyAsync(d => d.No_Documento == noDocumento, ct);
        }

        public async Task AssignRutaAsync(int rutaId, string usuarioAsignado, CancellationToken ct = default)
        {
            var ruta = await _context.Rutas.FindAsync(new object[] { rutaId }, ct);
            if (ruta == null) throw new InvalidOperationException("Ruta no encontrada");
            ruta.UsuarioAsignado = usuarioAsignado;
            _context.Rutas.Update(ruta);
            await _context.SaveChangesAsync(ct);
        }

        public async Task<IEnumerable<object>> GetDetRutasForUserAsync(string usuario, string? filter = null, CancellationToken ct = default)
        {
            var query = _context.DetRutas.AsQueryable().Where(d => d.Usuario == usuario);

            if (!string.IsNullOrEmpty(filter))
            {
                if (filter == "contraseñas")
                {
                    query = query.Where(d => d.No_Documento != 0) ; // placeholder: actual filter logic may join snapshot
                }
                else if (filter == "pagos")
                {
                    query = query.Where(d => d.No_Documento != 0); // placeholder
                }
            }

            return await query.Select(d => new { d.DetRutaID, d.RutaID, d.No_Documento, d.Usuario, d.Fecha }).ToListAsync(ct);
        }
    }
}
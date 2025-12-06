using DeIdeas.RouteFlow.API.DAL.Context;
using DeIdeas.RouteFlow.API.DAL.Interfaces.LegacyInterfaces;
using DeIdeas.RouteFlow.API.DAL.Models.Legacy;
using Microsoft.EntityFrameworkCore;

namespace DeIdeas.RouteFlow.API.DAL.Repositories.ModuleLegacy
{
    public class SnapshotRepository : ISnapshotRepository
    {
        private readonly LegacyContext _context;
        public SnapshotRepository(LegacyContext context) { _context = context; }

        public async Task InsertAsync(OINV_OCRD_Snapshot entity, CancellationToken ct = default)
        {
            _context.OINV_OCRD_Snapshot.Add(entity);
            await _context.SaveChangesAsync(ct);
        }

        public async Task<OINV_OCRD_Snapshot?> GetByDocumentoAsync(int noDocumento, CancellationToken ct = default)
        {
            return await _context.OINV_OCRD_Snapshot.FirstOrDefaultAsync(x => x.No_Documento == noDocumento, ct);
        }

        public async Task UpdateAsync(OINV_OCRD_Snapshot entity, CancellationToken ct = default)
        {
            var affected = await _context.OINV_OCRD_Snapshot
                .Where(x => x.No_Documento == entity.No_Documento)
                .ExecuteUpdateAsync(setters => setters
                    .SetProperty(x => x.U_forma_pago, entity.U_forma_pago)
                    .SetProperty(x => x.Total_Pagado, entity.Total_Pagado)
                    .SetProperty(x => x.UsuarioRegistro, entity.UsuarioRegistro)
                    .SetProperty(x => x.EstadoRegistro, entity.EstadoRegistro)
                    .SetProperty(x => x.FechaInsert, entity.FechaInsert)
                , ct);

            if (affected == 0)
            {
                throw new DbUpdateConcurrencyException("No rows were affected when updating snapshot.");
            }
        }

        public async Task UpdatePasswordAsync(OINV_OCRD_Snapshot entity, CancellationToken ct = default)
        {
            var affected = await _context.OINV_OCRD_Snapshot
                .Where(x => x.No_Documento == entity.No_Documento)
                .ExecuteUpdateAsync(setters => setters
                    .SetProperty(x => x.U_contrasenia, entity.U_contrasenia)
                    .SetProperty(x => x.U_fecha_contrasenia, entity.U_fecha_contrasenia)
                    .SetProperty(x => x.UsuarioRegistro, entity.UsuarioRegistro)
                    .SetProperty(x => x.FechaInsert, entity.FechaInsert)
                , ct);

            if (affected == 0)
            {
                throw new DbUpdateConcurrencyException("No rows were affected when updating snapshot password.");
            }
        }
    }
}